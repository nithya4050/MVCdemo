using Microsoft.Data.SqlClient;


namespace MVCDemo.DA
{
    public class SqlHelper
    {
        public readonly string ConnectionString;

       public SqlHelper()
       {
            ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=mvcdemo;Data Source=NITHYA\\SQLEXPRESS;Encrypt=False";
       }

        public SqlConnection GetConnection()
        {

            return new SqlConnection(ConnectionString);
        }
        public int SqlExcuteNonQuery(string sqlQuery, SqlParameter[] parameters)
        {
            int output = 0;
            using (SqlConnection sqlConnection = GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddRange(parameters);
                    output = sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            return output;
        }








    }
}
