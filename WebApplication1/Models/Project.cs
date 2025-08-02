using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Project
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty; // string is non-nullable by default in C# 8.0+

        public string? Description { get; set; }



        [Timestamp]
        public byte[]? RowVersion { get; set; } // byte[] is nullable

        public List<Package> Packages { get; set; } = new();
    }
}