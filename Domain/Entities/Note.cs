﻿using System;
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
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        [Column("ntr_description")]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [Column("ntr_style")]
        public int Style { get; set; }

        public IEnumerable<UserNote> UserNotes { get; set; }
        public IEnumerable<ProjectNotes> ProjectNotes { get; set; }
    }
}
