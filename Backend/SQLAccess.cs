using Microsoft.Data.SqlClient;
using System.Net.WebSockets;

namespace Backend
{
    public class SQLAccess
    {
        private string connectionString = @"Server=localhost;Database=DDDTest;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<object> readFromDatabase(string SQL)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                List<object> result = new List<object>();
                conn.Open();
                using (var cmd = new SqlCommand(SQL, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            try
                            {
                                result.Add(reader.GetString(0));
                            }
                            catch
                            {
                                try
                                {
                                    result.Add(reader.GetInt32(0));
                                }
                                catch
                                {
                                    try
                                    {
                                        result.Add(reader.GetDateTime(0));
                                    }
                                    catch
                                    {
                                        /*try
                                        {
                                            result.Add(reader.GetSqlByte(0));
                                        }
                                        catch
                                        { }*/
                                    }
                                }
                            }
                        }
                        return result;
                    }
                }
            }
        }

        public void writeToDatabase(string SQL)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(SQL, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
