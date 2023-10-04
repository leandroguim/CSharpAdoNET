

using System.Data.SqlClient;


class Program
{
    static void Main(string[] args)
    {
        SalvarCliente("Leandro Guim", "lguim@email.com", 5);

        ListarClientes();

        Console.ReadKey();
    }


    static void ListarClientes()
    {
        string connString = getStringConn();
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from clientes order by id";

            using (SqlDataReader reader = cmd.ExecuteReader())
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
        string connString = getStringConn();
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

    static void SalvarCliente(string nome, string email, int id)
    {
        string connString = getStringConn();
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "update clientes set nome = @nome, email = @email where id  = @id";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }



    static string getStringConn()
    {
        string connString = "Server=DESKTOP-BA373RT\\SQLEXPRESS;Database=CSharpAdoNET;User Id=sa;Password=77basslg";
        return connString;

    }
}