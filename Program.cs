using Npgsql;

string connectionString = "Server=YourServerName.amazonaws.com;Port=YourPort;Database=YourDatabase;User Id=YourUser;Password='YourPassword';";

//Establish Connection
//await using var connection = new NpgsqlConnection(connectionString);
//await connection.OpenAsync();
//Console.WriteLine("Connected");
//await connection.CloseAsync();

//Execute SQL Queries
await using var connection = new NpgsqlConnection(connectionString);
await connection.OpenAsync();

string query = "SELECT * FROM my_table";
await using (var cmd = new NpgsqlCommand(query, connection))
await using (var reader = await cmd.ExecuteReaderAsync())
{
    while (await reader.ReadAsync())
    {
        //Do whatever you need
        Console.WriteLine($"{reader.GetString(0)} {reader.GetString(1)}");
    }
}

await connection.CloseAsync();