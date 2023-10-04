

using System;
using System.Data.SqlClient;


class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("============================== CONTROLE DE CLIENTES ==============================\n");
        Console.WriteLine("Selecione uma opção:");
        Console.WriteLine("1 - Listar");
        Console.WriteLine("2 - Cadastrar");
        Console.WriteLine("3 - Editar");
        Console.WriteLine("4 - Excluir");
        Console.WriteLine("5 - Visualizar");
        Console.Write("Opção: ");
        int opc = Convert.ToInt32(Console.ReadLine());
        Console.Clear(); ;

        switch (opc)
        {
            case 1: 
                Console.Title = "Listagem de Clientes";
                Console.WriteLine("============================== LISTAGEM DE CLIENTES ==============================");
                ListarClientes();
                break;
            case 2:
                Console.Title = "Novo Cliente";
                Console.WriteLine("============================== CADASTRO DE NOVO CLIENTE ==============================");
                break;
            case 3:
                Console.Title = "Alteração de Cliente";
                Console.WriteLine("============================== ALTERAÇÃO DE CLIENTE ==============================");
                break;
            case 4:
                Console.Title = "Exclusão de Cliente";
                Console.WriteLine("============================== EXCLUSÃO DE CLIENTE ==============================");
                break;
            case 5:
                Console.Title = "Visualização de Clientes";
                Console.WriteLine("============================== VER DETALHES DE CLIENTES ==============================");
                break;
            default:
                Console.Title = "Opção inválida";
                Console.WriteLine("============================== SELECIONE UMA OPÇÃO VÁLIDA! ==============================");
                break;
        }

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

    static void DeletarCliente(int id)
    {
        string connString = getStringConn();
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "delete from clientes where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }

    static (int, string, string) SelecionarCliente(int id)
    {
        string connString = getStringConn();
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from clientes where id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                return (Convert.ToInt32(reader["id"].ToString()), reader["nome"].ToString(), reader["email"].ToString());
            }
        }
    }

    static string getStringConn()
    {
        string connString = "Server=DESKTOP-BA373RT\\SQLEXPRESS;Database=CSharpAdoNET;User Id=sa;Password=77basslg";
        return connString;
    }
}