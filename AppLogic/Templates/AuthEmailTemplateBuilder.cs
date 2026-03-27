using DTO;

namespace AppLogic.Templates
{
    public static class AuthEmailTemplateBuilder
    {
        public static EmailMessage BuildPasswordResetEmail(User user, string resetLink)
        {
            return new EmailMessage
            {
                Subject = "Restablecer contraseña",

                PlainTextBody = $@"
Hola {user.FullName},

Recibimos una solicitud para restablecer su contraseña.

Use este enlace para crear una nueva contraseña:
{resetLink}

Este enlace expirará en 30 minutos.

Si usted no solicitó este cambio, puede ignorar este correo.
",

                HtmlBody = $@"
<!DOCTYPE html>
<html lang=""es"" xmlns=""http://www.w3.org/1999/xhtml"">
<head>
  <meta charset=""utf-8"" />
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
  <title>BioPagos - Restablecer contraseña</title>
</head>
<body style=""margin:0;padding:0;background-color:#f4f1eb;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;-webkit-font-smoothing:antialiased;"">

  <table role=""presentation"" width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0"" style=""background-color:#f4f1eb;"">
    <tr>
      <td align=""center"" style=""padding:40px 16px;"">

        <table role=""presentation"" width=""600"" cellpadding=""0"" cellspacing=""0"" border=""0"" style=""max-width:600px;width:100%;background-color:#ffffff;border-radius:12px;overflow:hidden;box-shadow:0 2px 16px rgba(13,43,26,0.06);"">

          <tr>
            <td style=""height:4px;background:linear-gradient(90deg,#1e5c38,#2d8653,#4caf7d);font-size:0;line-height:0;"">&nbsp;</td>
          </tr>

          <tr>
            <td style=""padding:36px 48px 28px;"">
              <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" border=""0"">
                <tr>
                  <td style=""width:40px;height:40px;background-color:#2d8653;border-radius:10px;text-align:center;vertical-align:middle;"">
                    <span style=""color:#ffffff;font-size:18px;font-weight:bold;"">&#128274;</span>
                  </td>
                  <td style=""padding-left:14px;"">
                    <span style=""font-size:24px;font-weight:700;color:#0d2b1a;letter-spacing:-0.5px;"">Bio<span style=""color:#2d8653;font-style:italic;"">Pagos</span></span>
                  </td>
                </tr>
              </table>
            </td>
          </tr>

          <tr>
            <td style=""padding:0 48px;"">
              <div style=""height:1px;background-color:#e8e4df;""></div>
            </td>
          </tr>

          <tr>
            <td style=""padding:32px 48px 0;"">
              <h1 style=""margin:0 0 8px;font-size:22px;font-weight:700;color:#0d2b1a;line-height:1.3;"">
                Restablecer su contraseña
              </h1>
              <p style=""margin:0;font-size:15px;color:#5c6b60;line-height:1.7;"">
                Estimado <strong style=""color:#0d2b1a;"">{user.FullName}</strong>,
              </p>
            </td>
          </tr>

          <tr>
            <td style=""padding:20px 48px 0;"">
              <p style=""margin:0;font-size:15px;color:#5c6b60;line-height:1.75;"">
                Recibimos una solicitud para restablecer la contraseña de su cuenta en <strong style=""color:#0d2b1a;"">BioPagos</strong>.
              </p>
            </td>
          </tr>

          <tr>
            <td style=""padding:16px 48px 0;"">
              <p style=""margin:0;font-size:15px;color:#5c6b60;line-height:1.75;"">
                Para continuar, haga clic en el siguiente botón y podrá crear una nueva contraseña de forma segura.
              </p>
            </td>
          </tr>

          <tr>
            <td style=""padding:32px 48px 0;"">
              <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" border=""0"">
                <tr>
                  <td style=""background-color:#2d8653;border-radius:99px;"">
                    <a href=""{resetLink}"" target=""_blank"" style=""display:inline-block;padding:14px 36px;color:#ffffff;font-size:15px;font-weight:600;text-decoration:none;letter-spacing:0.3px;"">
                      Restablecer contraseña &rarr;
                    </a>
                  </td>
                </tr>
              </table>
            </td>
          </tr>

          <tr>
            <td style=""padding:28px 48px 0;"">
              <p style=""margin:0;font-size:14px;color:#5c6b60;line-height:1.7;"">
                Si el botón no funciona, copie y pegue este enlace en su navegador:
              </p>
              <p style=""margin:12px 0 0;font-size:13px;line-height:1.7;word-break:break-all;"">
                <a href=""{resetLink}"" target=""_blank"" style=""color:#2d8653;text-decoration:underline;"">{resetLink}</a>
              </p>
            </td>
          </tr>

          <tr>
            <td style=""padding:24px 48px 0;"">
              <p style=""margin:0;font-size:14px;color:#0d2b1a;font-weight:600;"">
                El equipo de BioPagos
              </p>
              <p style=""margin:4px 0 0;font-size:12px;color:#8a9a8e;"">
                FONAFIFO · SINAC · Costa Rica
              </p>
            </td>
          </tr>

          <tr>
            <td style=""padding:32px 48px 0;"">
              <div style=""height:1px;background-color:#e8e4df;""></div>
            </td>
          </tr>

          <tr>
            <td style=""padding:24px 48px 0;"">
              <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"">
                <tr>
                  <td style=""font-size:12px;font-weight:700;color:#2d8653;letter-spacing:2px;text-transform:uppercase;padding-bottom:16px;"">
                    Detalle de seguridad
                  </td>
                </tr>
                <tr>
                  <td>
                    <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"">
                      <tr>
                        <td style=""font-size:13px;font-weight:700;color:#0d2b1a;padding:6px 0;"">Acción:</td>
                        <td style=""font-size:13px;color:#5c6b60;text-align:right;padding:6px 0;"">Restablecimiento de contraseña</td>
                      </tr>
                      <tr>
                        <td style=""font-size:13px;font-weight:700;color:#0d2b1a;padding:6px 0;"">Vigencia del enlace:</td>
                        <td style=""font-size:13px;color:#5c6b60;text-align:right;padding:6px 0;"">30 minutos</td>
                      </tr>
                      <tr>
                        <td style=""font-size:13px;font-weight:700;color:#0d2b1a;padding:6px 0;"">Cuenta:</td>
                        <td style=""font-size:13px;color:#5c6b60;text-align:right;padding:6px 0;"">{user.Email}</td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </td>
          </tr>

          <tr>
            <td style=""padding:20px 48px 0;"">
              <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""background-color:#fdf3e3;border-radius:8px;border:1px solid #f0ddb8;"">
                <tr>
                  <td style=""padding:16px 20px;"">
                    <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" border=""0"">
                      <tr>
                        <td style=""vertical-align:top;padding-right:12px;"">
                          <span style=""font-size:18px;"">&#9888;</span>
                        </td>
                        <td>
                          <p style=""margin:0;font-size:13px;font-weight:700;color:#0d2b1a;"">¿No solicitó este cambio?</p>
                          <p style=""margin:4px 0 0;font-size:12px;color:#5c6b60;line-height:1.6;"">
                            Si usted no solicitó restablecer su contraseña, puede ignorar este mensaje. Su cuenta permanecerá igual.
                          </p>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </td>
          </tr>

          <tr>
            <td style=""height:40px;""></td>
          </tr>

          <tr>
            <td style=""height:4px;background:linear-gradient(90deg,#4caf7d,#2d8653,#1e5c38);font-size:0;line-height:0;"">&nbsp;</td>
          </tr>
        </table>

        <table role=""presentation"" width=""600"" cellpadding=""0"" cellspacing=""0"" border=""0"" style=""max-width:600px;width:100%;"">
          <tr>
            <td style=""padding:28px 48px;text-align:center;"">
              <p style=""margin:0;font-size:12px;color:#8a9a8e;line-height:1.8;"">
                Sistema de Gestión de Pagos por Servicios Ambientales<br>
                FONAFIFO · SINAC · Costa Rica
              </p>
              <p style=""margin:12px 0 0;font-size:11px;color:#b8c4bc;"">
                © 2026 BioPagos. Todos los derechos reservados.
              </p>
            </td>
          </tr>
        </table>

      </td>
    </tr>
  </table>

</body>
</html>"
            };
        }

        public static EmailMessage BuildPasswordResetSuccessEmail(User user)
        {
            return new EmailMessage
            {
                Subject = "Su contraseña fue restablecida",
                PlainTextBody = $@"
Hola {user.FullName},

Le confirmamos que la contraseña de su cuenta ha sido restablecida exitosamente.

Si usted no realizó este cambio, comuníquese con soporte inmediatamente.
",
                HtmlBody = $@"
<html>
<body style='font-family:Arial,sans-serif;'>
    <h2>Contraseña actualizada</h2>
    <p>Hola {user.FullName},</p>
    <p>Le confirmamos que la contraseña de su cuenta ha sido restablecida exitosamente.</p>
    <p>Si usted no realizó este cambio, comuníquese con soporte inmediatamente.</p>
</body>
</html>"
            };
        }
    }
}
    
