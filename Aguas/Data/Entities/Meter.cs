using System;
using System.Collections.Generic;

namespace Aguas.Data.Entities
{
    public class Meter : IEntity
    {
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
