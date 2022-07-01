using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("ntr_user")]
    public class User : EntityBase
    {
        [Required]
        [Column("ntr_email")]
        public string Email { get; set; }
        [Required]
        [Column("ntr_password")]
        [MaxLength(25, ErrorMessage = "Password must be 25 characters or less"), MinLength(8,ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }
    }
}
