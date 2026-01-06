using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;


namespace PersonalFinanceTracker.Models
{
    public class Budget
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyLimit { get; set; }

        [Required]
        public DateTime Month { get; set; }   // 👈 FIXED

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
