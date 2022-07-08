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
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("ntr_password")]
        [MaxLength(255), MinLength(8)]
        public string Password { get; set; }
    }
}
