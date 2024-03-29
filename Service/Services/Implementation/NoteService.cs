﻿using Domain.Entities;
using Persistence.Repositories.Interfaces;
using Service.DTO.Note;
using Service.Exceptions.Note;
using Service.Exceptions.User;
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

        public void ChangeAccess(UserNoteDto userNoteUpdate, Guid userId)
        {
            HasAccess(userId, userNoteUpdate.NoteId, AccessLevel.Owner);

            var userShared = _repository.UserRepository.FindByCondition(x => x.Email == userNoteUpdate.UserEmail).FirstOrDefault();

            if (userShared is null)
            {
                throw new UserDoNotExist();
            }

            if(userShared.Id == userId)
            {
                throw new UserCantChangeHisAccessLevel();
            }

            var userNote = _repository.UserNoteRepository.FindByCondition(x => x.UserId == userShared.Id && x.NoteId == userNoteUpdate.NoteId).FirstOrDefault();

            if(userNote is not null)
            {
                userNote.AccessLevel = userNoteUpdate.AccessLevel;

                _repository.UserNoteRepository.Update(userNote);
                _repository.Save();
            }
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
            HasAccess(userId, noteId, AccessLevel.Remove);

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

        public List<UserNoteDto> GetUsersWithAccess(Guid noteId, Guid userid)
        {
            HasAccess(userid, noteId, AccessLevel.View);

            var usersNote = _repository.UserNoteRepository.GetUsersWithAccess(noteId);

            return usersNote.Select(x => new UserNoteDto
            {
                AccessLevel = x.AccessLevel,
                NoteId = x.NoteId,
                UserEmail = x.User.Email
            }).ToList();
        }

        public void HasAccess(Guid userId, Guid noteId, AccessLevel accessLevel)
        {
            var access = _repository.UserNoteRepository.FindByCondition(x => x.UserId == userId && x.NoteId == noteId).FirstOrDefault();

            if(access is not null)
            {
                if(accessLevel >= access.AccessLevel) 
                { 
                    return; 
                }
                else
                {
                    throw new PermissionInsufficient();
                }
            }
            throw new NoteDoNotExist();
        }

        public void RemoveAccess(Guid noteId, Guid userId, string userEmail)
        {
            HasAccess(userId, noteId, AccessLevel.Owner);

            var userShared = _repository.UserRepository.FindByCondition(x => x.Email == userEmail).FirstOrDefault();

            if (userShared is null)
            {
                throw new UserDoNotExist();
            }

            if (userShared.Id == userId)
            {
                throw new UserCantChangeHisAccessLevel();
            }

            var userNote = _repository.UserNoteRepository.FindByCondition(x => x.UserId == userShared.Id && x.NoteId == noteId).FirstOrDefault();

            if(userNote is not null)
            {
                _repository.UserNoteRepository.Delete(userNote);
                _repository.Save();
            }
        }

        public void Share(UserNoteDto userNoteCreate, Guid userId)
        {
            HasAccess(userId, userNoteCreate.NoteId, AccessLevel.Owner);

            var userShared = _repository.UserRepository.FindByCondition(x => x.Email == userNoteCreate.UserEmail).FirstOrDefault();

            if(userShared is null)
            {
                throw new UserDoNotExist();
            }

            var userNote = _repository.UserNoteRepository.FindByCondition(x => x.UserId == userShared.Id && x.NoteId == userNoteCreate.NoteId).FirstOrDefault();

            if(userNote is not null)
            {
                throw new UserAlreadyHasAccess(userNoteCreate.UserEmail);
            }

            var newUserNote = new UserNote
            {
                AccessLevel = userNoteCreate.AccessLevel,
                NoteId = userNoteCreate.NoteId,
                UserId = userShared.Id
            };

            newUserNote.Generate();

            _repository.UserNoteRepository.Create(newUserNote);
            _repository.Save();
        }

        public void Update(NoteDto note, Guid userId)
        {
            HasAccess(userId, note.Id, AccessLevel.Edit);

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
