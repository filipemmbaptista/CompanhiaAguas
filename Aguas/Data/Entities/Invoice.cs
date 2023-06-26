using System;

namespace Aguas.Data.Entities
{
    public class Invoice : IEntity
    {
        public int Id { get; set; }

        public int ContractId { get; set; }

        public Contract Contract { get; set; }

        public DateTime Date { get; set; }

        public double Consumption { get; set; }

        public double Cost { get; set; }
    }
}
