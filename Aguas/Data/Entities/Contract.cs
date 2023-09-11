using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aguas.Data.Entities
{
    public class Contract : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int TypeId { get; set; }

        public ContractType Type { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<Invoice> Invoices { get; set; } = new List<Invoice>();

        public List<Locality> Locality { get; set; } = new List<Locality>();
    }
}
