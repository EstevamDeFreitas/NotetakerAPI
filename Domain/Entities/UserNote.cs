using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("ntr_user_notes")]
    public class UserNote : EntityBase
    {
        [Required]
        [Column("ntr_user_id")]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [Required]
        [Column("ntr_note_id")]
        [ForeignKey("Note")]
        public Guid NoteId { get; set; }
        [Required]
        [Column("ntr_access_level")]
        public AccessLevel AccessLevel { get; set; }

        public User User { get; set; }
        public Note Note { get; set; }
    }
}
