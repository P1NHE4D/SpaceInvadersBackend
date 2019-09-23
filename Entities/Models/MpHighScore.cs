using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("MpHighScore")]
    public class MpHighScore
    {
        [Key]
        public Guid Id { get; set; }
        
        [StringLength(20, ErrorMessage = "PlayerOneName may not exceed 20 characters")]
        [Required(ErrorMessage = "PlayerOneName is required")]
        public string PlayerOneName { get; set; }
        
        [StringLength(20, ErrorMessage = "PlayerTwoName may not exceed 20 characters")]
        [Required(ErrorMessage = "PlayerTwoName is required")]
        public string PlayerTwoName { get; set; }
        
        [Required(ErrorMessage = "Score is required")]
        public int Score { get; set; }
    }
}