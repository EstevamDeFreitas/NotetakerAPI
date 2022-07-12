using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO.Note
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Style { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }

    public class NoteEditDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Style { get; set; }
    }

    public class NoteCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Style { get; set; }
    }
}
