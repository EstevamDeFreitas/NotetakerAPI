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
        void Share(UserNoteDto userNote, Guid userId);
        void RemoveAccess(Guid noteId, Guid userId, string userEmail);
        void ChangeAccess(UserNoteDto userNoteUpdate, Guid userId);
        List<UserNoteDto> GetUsersWithAccess(Guid noteId, Guid userid);
        List<NoteDto> GetNotes(Guid userId);
        void HasAccess(Guid userId, Guid noteId, AccessLevel accessLevel);
    }
}
