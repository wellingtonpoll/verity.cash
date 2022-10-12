using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verity.Cash.Domain.Enums;

namespace Verity.Cash.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; private set; }
        public double Amount { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public PaymentType PaymentType { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}