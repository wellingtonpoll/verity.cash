using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Verity.Cash.Domain.Entities;
using Verity.Cash.Domain.Interfaces;

namespace Verity.Cash.Infra.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
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

        public async Task<Payment> AddAsync(Payment payment)
        {
            await PaymentCollection.InsertOneAsync(payment);
            return payment;
        }

        public async Task<IEnumerable<Payment>> GetDailyConsolidatedAsync(DateTime date)
        {
            var initDate = date.Date;
            var endDate = date.Date.AddDays(1);

            var filter = Builders<Payment>.Filter.Where(c => c.CreatedAt >= initDate && c.CreatedAt < endDate.Date);
            var cursor = await PaymentCollection.FindAsync(filter);
            return await cursor.ToListAsync();
        }
    }
}