using Domain.Entities;
using Service.DTO.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface INoteService
    {
        void Create(NoteCreateDto note, Guid userId);
        void Update(NoteDto note, Guid userId);
        void Delete(Guid noteId, Guid userId);
        void Share(Guid noteId, Guid userId, string userEmail, AccessLevel accessLevel);
        void RemoveAccess(Guid noteId, Guid userId, string userEmail);
        void ChangeAccess(Guid noteId, Guid userId, string userEmail, AccessLevel accessLevel);
        List<NoteDto> GetNotes(Guid userId);
        bool HasAccess(Guid userId, Guid noteId, AccessLevel accessLevel);
    }
}
