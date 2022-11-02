using CKK.DB.Interfaces;
using CKK.Logic.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly string _tableName = "Orders";

        public OrderRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(Order entity)
        {
            var sql = $"INSERT INTO {_tableName} (OrderId, OrderNumber, CustomerId, ShoppingCartId) " +
                $"VALUES (@OrderId, @OrderNumber, @CustomerId, @ShoppingCartId)";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public int Add(Order entity)
        {
            var sql = $"INSERT INTO {_tableName} (OrderId, OrderNumber, CustomerId, ShoppingCartId) " +
                $"VALUES (@OrderId, @OrderNumber, @CustomerId, @ShoppingCartId)";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }

        public async Task<IReadOnlyList<Order>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {_tableName}";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = await SqlMapper.QueryAsync<Order>(connection, sql);
                connection.Close();
                return result.ToList();
            }
        }

        public Order GetOrderByCustomer(int Id)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                var query = SqlMapper.QuerySingleOrDefault<Order>(conn, $"SELECT * FROM {_tableName} WHERE Id = @OrderId", new { ID = Id });
                if (query == null)
                {
                    throw new KeyNotFoundException($"{_tableName} with id [{Id}] could not be found.");
                }
                return query;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = $"DELETE FROM {_tableName} WHERE OrderId = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { ID = id });
                return result;
            }
        }

        public int Delete(int id)
        {
            var sql = $"DELETE FROM {_tableName} WHERE OrderId = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, new { ID = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Order entity)
        {
            var sql = "UPDATE Orders SET OrderNumber = @OrderNumber, ShoppingCartId = @ShoppingCartId, WHERE Id = @OrderId";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var sql = $"SELECT * FROM {_tableName} WHERE OrderId = {id}";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Order>(sql);
                return result;
            }
        }
    }
}
