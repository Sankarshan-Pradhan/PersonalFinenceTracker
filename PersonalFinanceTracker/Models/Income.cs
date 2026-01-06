using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceTracker.Models
{
    public class Income
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }  // Foreign key to ApplicationUser.Id

        [Required]
        [StringLength(255)]  // e.g., "salary", "freelance"
        public string Source { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]  // e.g., "monthly", "weekly"
        public string Frequency { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        // Navigation property
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
