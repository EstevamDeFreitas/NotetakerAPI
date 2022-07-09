using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("ntr_notes")]
    public class Note : EntityBase
    {
        [Required]
        [Column("ntr_title")]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [Column("ntr_description")]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        [Column("ntr_owner_id")]
        [ForeignKey("Owner")]
        public Guid OwnerId { get; set; }
        [Required]
        [Column("ntr_style")]
        public int Style { get; set; }

        public User Owner { get; set; }
    }
}
