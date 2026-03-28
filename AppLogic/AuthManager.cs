            using AppLogic.Interfaces;
            using AppLogic.Templates;
            using DataAccess.Crud;
            using DTO;
            using System;
            using System.Security.Cryptography;
            using System.Text;

            namespace AppLogic
            {
                public class AuthManager : IAuthManager
                {
                    private readonly IEmailService _emailService;

                    public AuthManager(IEmailService emailService)
                    {
                        _emailService = emailService;
                    }

                    public void ForgotPassword(string email)
                    {
                        var userCrud = new UserCrud();
                        var tokenCrud = new PasswordResetTokenCrudFactory();

                        var user = userCrud.RetrieveByEmail<User>(email);

                        if (user == null || !user.Active)
                            return;

                        var token = GenerateToken();
                        var tokenHash = HashToken(token);

                        var resetToken = new PasswordResetToken
                        {
                            UserId = user.Id,
                            TokenHash = tokenHash,
                            Expiration = DateTime.UtcNow.AddMinutes(30),
                            Used = false
                        };

                        tokenCrud.Create(resetToken);

                        var resetLink = $"https://biopagos.azurewebsites.net/Login/ResetPassword?token={Uri.EscapeDataString(token)}";

                        var emailMessage = AuthEmailTemplateBuilder.BuildPasswordResetEmail(user, resetLink);

                        // 📧 Send email with debug safety
                        try
                        {
                            if (string.IsNullOrWhiteSpace(user.Email))
                                throw new Exception("User email is empty");

                            if (string.IsNullOrWhiteSpace(emailMessage.Subject))
                                throw new Exception("Email subject is empty");

                            if (string.IsNullOrWhiteSpace(emailMessage.HtmlBody) &&
                                string.IsNullOrWhiteSpace(emailMessage.PlainTextBody))
                                throw new Exception("Email body is empty");

                            _emailService.Send(
                                user.Email,
                                emailMessage.Subject,
                                emailMessage.PlainTextBody,
                                emailMessage.HtmlBody
                            );
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("ForgotPassword email failed: " + ex.Message);
                        }
                    }

                    public void ResetPassword(string token, string newPassword)
                    {
                        var tokenCrud = new PasswordResetTokenCrudFactory();
                        var userCrud = new UserCrud();

                        var tokenHash = HashToken(token);
                        var storedToken = tokenCrud.RetrieveByHash(tokenHash);

                        if (storedToken == null)
                            throw new Exception("Invalid or expired token");

                        // 🔍 Get user first
                        var users = userCrud.RetrieveById<User>(storedToken.UserId);

                        if (users == null || users.Count == 0)
                            throw new Exception("User not found");

                        var user = users[0];

                        // 🔐 Update password
                        var passwordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                        userCrud.UpdatePassword(storedToken.UserId, passwordHash);

                        // 🧾 Mark token as used
                        tokenCrud.Update(storedToken);

                        var emailMessage = AuthEmailTemplateBuilder.BuildPasswordResetSuccessEmail(user);

                        // 📧 Send confirmation email with debug safety
                        try
                        {
                            if (string.IsNullOrWhiteSpace(user.Email))
                                throw new Exception("User email is empty");

                            if (string.IsNullOrWhiteSpace(emailMessage.Subject))
                                throw new Exception("Email subject is empty");

                            if (string.IsNullOrWhiteSpace(emailMessage.HtmlBody) &&
                                string.IsNullOrWhiteSpace(emailMessage.PlainTextBody))
                                throw new Exception("Email body is empty");

                            _emailService.Send(
                                user.Email,
                                emailMessage.Subject,
                                emailMessage.PlainTextBody,
                                emailMessage.HtmlBody
                            );
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("ResetPassword confirmation email failed: " + ex.Message);
                        }
                    }

                    private string GenerateToken()
                    {
                        var bytes = RandomNumberGenerator.GetBytes(32);
                        return Convert.ToBase64String(bytes);
                    }

                    private string HashToken(string token)
                    {
                        using var sha256 = SHA256.Create();
                        var bytes = Encoding.UTF8.GetBytes(token);
                        return Convert.ToBase64String(sha256.ComputeHash(bytes));
                    }
                }
            }