using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Verity.Cash.Domain.Entities;
using Verity.Cash.Domain.Interfaces;

namespace Verity.Cash.Infra.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        // TODO: Add vault to rescue database settings
        private const string _connectionStringName = "VerityCash";
        private const string _databaseName = "veritycash";
        private const string _collectionName = "payments";

        private IMongoCollection<Payment> PaymentCollection { get; }

        public PaymentRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString(_connectionStringName));
            var database = client.GetDatabase(_databaseName);
            PaymentCollection = database.GetCollection<Payment>(_collectionName);
        }

        public async Task AddAsync(Payment payment)
        {
            await PaymentCollection.InsertOneAsync(payment);
        }
    }
}