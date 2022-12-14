using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.MemoryDb.Entities
{
    public class Register
    {
        public Register()
        {
            CreatedAt = DateTime.Now;
        }
        public Guid Id { get; set; }
        public float Value { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
