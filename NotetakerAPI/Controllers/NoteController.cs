using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO.Note;
using Service.Notations;
using Service.Response;
using Service.Services.Interfaces;

namespace NotetakerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IServiceWrapper _services;
        public NoteController(IServiceWrapper services)
        {
            _services = services;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetNotes()
        {
            try
            {
                var userId = Guid.Parse(HttpContext.Items["User"].ToString());

                var notes = _services.NoteService.GetNotes(userId);

                return Ok(new Response<List<NoteDto>>
                {
                    Message = "Notes found",
                    Data = notes
                });
            }
            catch( Exception ex)
            {
                return BadRequest(new Response<object>
                {
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateNote([FromBody] NoteCreateDto note)
        {
            try
            {
                var userId = Guid.Parse(HttpContext.Items["User"].ToString());

                _services.NoteService.Create(note, userId);

                return Ok(new Response<object>
                {
                    Message = "Note created"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object>
                {
                    Message = ex.Message,
                });
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdateNote([FromBody] NoteDto note)
        {
            try
            {
                var userId = Guid.Parse(HttpContext.Items["User"].ToString());

                _services.NoteService.Update(note, userId);

                return Ok(new Response<object>
                {
                    Message = "Note updated"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object>
                {
                    Message = ex.Message,
                });
            }
        }

        [HttpDelete]
        [Authorize]
        public IActionResult DeleteNote([FromQuery] Guid noteId)
        {
            try
            {
                var userId = Guid.Parse(HttpContext.Items["User"].ToString());

                _services.NoteService.Delete(noteId, userId);

                return Ok(new Response<object>
                {
                    Message = "Note deleted"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object>
                {
                    Message = ex.Message,
                });
            }
        }

        [Route("share")]
        [HttpPost]
        [Authorize]
        public IActionResult ShareNote([FromBody] UserNoteDto userNote)
        {
            try
            {
                var userId = Guid.Parse(HttpContext.Items["User"].ToString());

                _services.NoteService.Share(userNote, userId);

                return Ok(new Response<object>
                {
                    Message = "Note shared"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new Response<object>
                {
                    Message = ex.Message,
                });
            }
        }

        [Route("share")]
        [HttpPut]
        [Authorize]
        public IActionResult ChangeAccessNote([FromBody] UserNoteDto userNote)
        {
            try
            {
                var userId = Guid.Parse(HttpContext.Items["User"].ToString());

                _services.NoteService.ChangeAccess(userNote, userId);

                return Ok(new Response<object>
                {
                    Message = "Access changed"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object>
                {
                    Message = ex.Message,
                });
            }
        }

        [Route("share")]
        [HttpDelete]
        [Authorize]
        public IActionResult RemoveAccessNote([FromQuery] Guid noteId, [FromQuery] string userEmail)
        {
            try
            {
                var userId = Guid.Parse(HttpContext.Items["User"].ToString());

                _services.NoteService.RemoveAccess(noteId, userId, userEmail);

                return Ok(new Response<object>
                {
                    Message = "Access removed"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object>
                {
                    Message = ex.Message,
                });
            }
        }

        [Route("shared/{noteId}")]
        [HttpGet]
        [Authorize]
        public IActionResult GetNoteAccesses(Guid noteId)
        {
            try
            {
                var userId = Guid.Parse(HttpContext.Items["User"].ToString());

                var userNotes = _services.NoteService.GetUsersWithAccess(noteId, userId);

                return Ok(new Response<List<UserNoteDto>>
                {
                    Message = "Accesses found",
                    Data = userNotes
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object>
                {
                    Message = ex.Message,
                });
            }
        }

    }
}
