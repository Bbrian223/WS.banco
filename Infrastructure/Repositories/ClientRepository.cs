using System.Data;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private readonly string getAllQuery = @"SELECT*FROM UserAccount";
        private readonly string getByIdQuery = @"SELECT*FROM UserAccount WHERE id = @id";
        private readonly string setQuery = @"INSERT INTO UserAccount (username, password, user_type) 
                                             VALUES(@name, @pass, @type)";
        private readonly string updateByIdQuery = @"UPDATE UserAccount SET [username] = @name, [password] = @pass
                                                    [user_type] = @type, [status] = @status WHERE [id] = @id";
        private readonly string removeByIdQuery = @"UPDATE UserAccount SET [status] = 0 WHERE [id] = @id";

        public ClientRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            List<Client> list = new List<Client>();

            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    await connection.OpenAsync();
                    using SqlCommand command = new SqlCommand(getAllQuery, connection);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            list.Add(new Client()
                            {
                                id = reader.GetInt64("id"),
                                name = reader.GetString("username"),
                                pass = reader.GetString("password"),
                                type = reader.GetString("user_type"),
                                status = reader.GetBoolean("status")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los datos de clientes",ex);
            }

            return list;
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    await connection.OpenAsync();
                    using SqlCommand command = new SqlCommand(getByIdQuery, connection);
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        await reader.ReadAsync();

                        Client client = new Client()
                        {
                                id = reader.GetInt64("id"),
                                name = reader.GetString("username"),
                                pass = reader.GetString("password"),
                                type = reader.GetString("user_type"),
                                status = reader.GetBoolean("status")
                        };

                        return client;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtner los datos del cliente: " + id, ex);
            }
        }

        public async Task<bool> SetAsync(Client client)
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand(setQuery, connection)) 
                    {
                        command.Parameters.AddWithValue("@name", client.name);
                        command.Parameters.AddWithValue("@pass", client.pass);
                        command.Parameters.AddWithValue("@type", client.type);

                        return await command.ExecuteNonQueryAsync() > 0;
                    } 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo registrar el cliente",ex);
            }
        }

        public async Task<bool> UpdateByIdAsync(Client client)
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand(updateByIdQuery,connection))
                    {
                        command.Parameters.AddWithValue("@name", client.name);
                        command.Parameters.AddWithValue("@pass", client.pass);
                        command.Parameters.AddWithValue("@type", client.type);
                        command.Parameters.AddWithValue("@status", client.status);

                        return await command.ExecuteNonQueryAsync() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el cliente: " + client.id, ex);
            }
        }


        public async Task<bool> RemoveByIdAsync(int id)
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand(removeByIdQuery,connection))
                    {
                        command.Parameters.AddWithValue("@id",id);

                        return await command.ExecuteNonQueryAsync() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo dar de baja al cliente: " + id, ex);
            }
        }
    }
}
