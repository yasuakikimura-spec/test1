using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Production
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Quantity { get; set; }

        public string? Description { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}