using Microsoft.Data.SqlClient;

namespace DataAccess.Dao
{
    public class SqlDao
    {
        private string connectionString = "Server=tcp:spsadb.database.windows.net,1433;Initial Catalog=spsadb;Persist Security Info=False;User ID=spsadmin;Password=Password!123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private static SqlDao? instance;

        public static SqlDao GetInstance()
        {
            if (instance is null)
            {
                instance = new SqlDao();
            }
            return instance;
        }

        public void ExecuteProcedure(SqlOperation pOperation)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = pOperation.ProcedureName;

                foreach (var param in pOperation.Parameters)
                {
                    cmd.Parameters.Add(param);
                }

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object ExecuteProcedureScalar(SqlOperation pOperation)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = pOperation.ProcedureName;

                foreach (var param in pOperation.Parameters)
                {
                    cmd.Parameters.Add(param);
                }

                sqlConnection.Open();
                var result = cmd.ExecuteScalar();
                sqlConnection.Close();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Dictionary<string, object>> ExecuteProcedureWithQuery(SqlOperation pOperation)
        {
            try
            {
                List<Dictionary<string, object>> lstResults = new List<Dictionary<string, object>>();
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = pOperation.ProcedureName;

                foreach (var param in pOperation.Parameters)
                {
                    cmd.Parameters.Add(param);
                }

                sqlConnection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row.Add(reader.GetName(i), reader.GetValue(i));
                        }
                        lstResults.Add(row);
                    }
                }

                sqlConnection.Close();
                return lstResults;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

