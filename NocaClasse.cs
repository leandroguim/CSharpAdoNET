using System;

public class Class1
{
	public Class1()
	{
	}

    public void SalvarCliente(string nome, string email)
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

    public void SalvarCliente(string nome, string email, int id)
    {
        string connString = getStingConn();
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

}
