

using System.Data.SqlClient;

SalvarCliente("Denise N. Campion", "DeniseNCampion@armyspy.com");
ListarClientes();

Console.ReadKey();

static void ListarClientes()
{
    string connString = getStingConn();
    using(SqlConnection conn = new SqlConnection( connString))
    {
        conn.Open();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "select * from clientes order by id";

        using(SqlDataReader reader = cmd.ExecuteReader())
        {

            while (reader.Read())
            {
                Console.WriteLine("ID: {0}", reader["id"]);
                Console.WriteLine("Nome: {0}", reader["nome"]);
                Console.WriteLine("------------------------------------------");
            }

        }

    }
}


static void SalvarCliente(string nome, string email)
{
    string connString = getStingConn();
    using (SqlConnection conn = new SqlConnection(connString))
    {
        conn.Open();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "insert into clientes (nome, email) values (@nome, @email)";
        cmd.Parameters.AddWithValue("@nome", nome);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.ExecuteNonQuery();
    }
}

static string getStingConn()
{
    string connString = "Server=DESKTOP-BA373RT\\SQLEXPRESS;Database=CSharpAdoNET;User Id=sa;Password=77basslg";
    return connString;

}