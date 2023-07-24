using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aguas.Data.Entities
{
    public class ContractType : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        public List<Contract>? Contracts { get; set; } = new List<Contract>();
    }
}
