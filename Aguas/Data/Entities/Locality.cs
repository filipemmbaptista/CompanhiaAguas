namespace Aguas.Data.Entities
{
    public class Locality : IEntity
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public int ContractId { get; set; }

        public Contract Contract { get; set; }
        
        public int MeterId { get; set; }

        public Meter Meter { get; set; }
    }
}
