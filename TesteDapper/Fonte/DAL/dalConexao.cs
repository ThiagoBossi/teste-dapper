using System.Data;
using System.Data.SqlClient;

namespace TesteDapper.Fonte.DAL
{
    public class dalConexao
    {
        public static SqlConnection conexao { get; set; }
        public static IDbConnection conexaoIdb { get; set; }

        public static bool realizarConexao()
        {
            try
            {
                conexao = new SqlConnection();

                conexao.ConnectionString = $"" +
                    $"Data Source=127.0.0.1;" +
                    $"Initial Catalog=EmployeesTestAPI;" +
                    $"User Id=sa;" +
                    $"Password=;" +
                    $"MultipleActiveResultSets=true;" +
                    $"";

                conexao.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
