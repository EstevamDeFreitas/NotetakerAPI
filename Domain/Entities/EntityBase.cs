using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EntityBase
    {
        [Key]
        [Column("ntr_id")]
        public Guid Id { get; set; }
        [Required]
        [Column("ntr_dt_creation")]
        public DateTime CreationDate { get; set; }
        [Required]
        [Column("ntr_dt_modified")]
        public DateTime ModifiedDate { get; set; }
        
        public void Generate()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
    }
}
