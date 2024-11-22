using Microsoft.Data.Sqlite;
using models;

public class ProductosRepository
{
    string connectionString = "Data Source=DB/Tienda.db;Cache=Shared";

    public void CrearPoducto(Producto producto)
    {
        string query = "INSERT INTO Productos (Descripcion, Precio) VALUES (@Descripcion, @Precio)";

        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            SqliteCommand command = new SqliteCommand(query, connection);
            
            connection.Open();

            command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            command.Parameters.AddWithValue("@Precio", producto.Precio);
            command.ExecuteNonQuery();

            connection.Close();
        }
    }

    public List<Producto> ListarProductos()
    {
        List<Producto> productos = new List<Producto>();
        string query = "SELECT * FROM Productos";

        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            SqliteCommand command = new SqliteCommand(query, connection);

            connection.Open();

            using(SqliteDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    var producto= new Producto();
                    producto.IdProducto = Convert.ToInt32(reader["idProducto"]);
                    producto.Descripcion = reader["Descripcion"].ToString();
                    producto.Precio = Convert.ToInt32(reader["Precio"]);

                    productos.Add(producto);
                }
            }

            connection.Close();
        }

        return productos;
    }
}