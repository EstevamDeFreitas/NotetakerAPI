using Domain.Entities;
using Persistence.Repositories.Interfaces;
using Service.DTO.Note;
using Service.Exceptions.Note;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Implementation
{
    public class NoteService : INoteService
    {
        private readonly IRepositoryWrapper _repository;

        public NoteService(IRepositoryWrapper repository)
        {
            this._repository = repository;
        }

        public void ChangeAccess(Guid noteId, Guid userId, string userEmail, AccessLevel accessLevel)
        {
            throw new NotImplementedException();
        }

        public void Create(NoteCreateDto note, Guid userId)
        {
            var newNote = new Note
            {
                Style = note.Style,
                Description = note.Description,
                Title = note.Title
            };

            newNote.Generate();

            var newUserNote = new UserNote
            {
                AccessLevel = AccessLevel.Owner,
                NoteId = newNote.Id,
                UserId = userId
            };

            newUserNote.Generate();


            _repository.NoteRepository.Create(newNote);
            _repository.UserNoteRepository.Create(newUserNote);
            _repository.Save();
        }

        public void Delete(Guid noteId, Guid userId)
        {
            if (!HasAccess(userId, noteId, AccessLevel.Remove))
            {
                if(!HasAccess(userId, noteId, AccessLevel.View))
                {
                    throw new NoteDoNotExist();
                }

                throw new PermissionInsufficient();
            }

            var note = _repository.NoteRepository.FindByCondition(x => x.Id == noteId && x.UserNotes.Any(y => y.UserId == userId)).FirstOrDefault();

            _repository.NoteRepository.Delete(note);
            _repository.Save();

        }

        public List<NoteDto> GetNotes(Guid userId)
        {
            var notesRaw = _repository.NoteRepository.FindByCondition(x => x.UserNotes.Any(y => y.UserId == userId));

            var notes = notesRaw.Select(x => new NoteDto
            {
                AccessLevel = x.UserNotes.First(y => y.UserId == userId).AccessLevel,
                Style = x.Style,
                Description = x.Description,
                Id = x.Id,
                Title = x.Title
            }).ToList();

            return notes;
        }

        public bool HasAccess(Guid userId, Guid noteId, AccessLevel accessLevel)
        {
            var access = _repository.UserNoteRepository.FindByCondition(x => x.UserId == userId && x.NoteId == noteId).FirstOrDefault();

            if(access is not null)
            {
                return access.AccessLevel <= accessLevel;
            }

            return false;
        }

        public void RemoveAccess(Guid noteId, Guid userId, string userEmail)
        {
            throw new NotImplementedException();
        }

        public void Share(Guid noteId, Guid userId, string userEmail, AccessLevel accessLevel)
        {
            throw new NotImplementedException();
        }

        public void Update(NoteDto note, Guid userId)
        {
            if (!HasAccess(userId, note.Id, AccessLevel.Edit))
            {
                if (!HasAccess(userId, note.Id, AccessLevel.View))
                {
                    throw new NoteDoNotExist();
                }

                throw new PermissionInsufficient();
            }

            var oldNote = _repository.NoteRepository.FindByCondition(x => x.Id == note.Id && x.UserNotes.Any(x => x.UserId == userId)).FirstOrDefault();

            oldNote.Description = note.Description;
            oldNote.Title = note.Title;
            oldNote.Style = note.Style;
            oldNote.ModifiedDate = DateTime.Now;

            _repository.NoteRepository.Update(oldNote);
            _repository.Save();
        }
    }
}
