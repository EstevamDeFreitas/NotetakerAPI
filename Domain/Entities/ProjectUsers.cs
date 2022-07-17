using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("ntr_project_users")]
    public class ProjectUsers : EntityBase
    {
        [Required]
        [Column("ntr_user_id")]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [Required]
        [Column("ntr_project_id")]
        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        [Required]
        [Column("ntr_access_level")]
        public AccessLevel AccessLevel { get; set; }

        public Project Project { get; set; }
        public User User { get; set; }
    }
}
