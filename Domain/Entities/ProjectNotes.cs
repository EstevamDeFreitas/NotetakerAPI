using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("ntr_project_notes")]
    public class ProjectNotes : EntityBase
    {
        [Required]
        [Column("ntr_project_id")]
        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        [Required]
        [Column("ntr_note_id")]
        [ForeignKey("Note")]
        public Guid NoteId { get; set; }

        public Project Project { get; set; }
        public Note Note { get; set; }
    }
}
