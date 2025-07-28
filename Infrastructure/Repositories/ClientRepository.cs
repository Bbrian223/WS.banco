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
        private readonly string getAllQuery = "SELECT*FROM UserAccount";
        private readonly string getByIdQuery = "SELECT*FROM UserAccount WHERE id = ";


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
            Client client;

            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    await connection.OpenAsync();
                    using SqlCommand command = new SqlCommand(getByIdQuery + id, connection);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        await reader.ReadAsync();

                        client = new Client()
                        {
                                id = reader.GetInt64("id"),
                                name = reader.GetString("username"),
                                pass = reader.GetString("password"),
                                type = reader.GetString("user_type"),
                                status = reader.GetBoolean("status")
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtner los datos del cliente: " + id, ex);
            }

            return client;
        }
    }
}
