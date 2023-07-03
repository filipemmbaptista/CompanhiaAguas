using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aguas.Data.Entities
{
    public class Meter : IEntity
    {
        [Key]
        public int Id { get; set; }

        public enum MeterStatus
        {
            InRepair,
            Normal,
            Damaged
        }
        
        public string Model { get; set; }

        public MeterStatus Status { get; set; }

        public List<Locality> Locality { get; set; } = new List<Locality>();
    }
}
