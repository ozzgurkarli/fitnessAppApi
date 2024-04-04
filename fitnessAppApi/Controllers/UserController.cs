using fitnessAppApi.DTO;
using fitnessAppApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace fitnessAppApi.Controllers
{
    #region public methods
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(FitnessContext context) : ControllerBase
    {
        private readonly FitnessContext db = context;

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User? model = await db.User.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (model == null)
            {
                return NotFound();
            }

            return Ok(modelToDto(model));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(DTOUser dto)
        {
            User model = dtoToModel(dto);

            string? tempInvitationCode = null;

            if (!string.IsNullOrEmpty(model.InvitationCode))
            {
                tempInvitationCode = model.InvitationCode;
            }

            model.InvitationCode = codeGenerator();
            db.User.Add(model);

            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }

            if (!string.IsNullOrEmpty(tempInvitationCode))
            {
                InvitationCodeController tmp = new InvitationCodeController(context);
                tmp.InvitationHandler(new InvitationCode { Code = tempInvitationCode, UsedById = model.Id});
            }

            return CreatedAtAction(nameof(GetUser), new { id = model.Id }, model);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(DTOUser dto)
        {
            User? model = await db.User.FirstOrDefaultAsync(x => x.Email!.Equals(dto.Email));

            if (model == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetUser), new { id = model.Id }, model);
        }
        #endregion public methods

        #region private methods
        private User dtoToModel(DTOUser dto)
        {
            return new User { Name = dto.Name, Surname = dto.Surname, Email = dto.Email, BirthDate = Convert.ToDateTime(dto.BirthDate), Gender = dto.Gender, InvitationCode = dto.InvitationCode, RecordDate = DateTime.Now };
        }

        private DTOUser modelToDto(User model)
        {
            return new DTOUser {Id = model.Id, BirthDate = model.BirthDate.ToShortDateString(), Email = model.Email, Gender = model.Gender, InvitationCode = model.InvitationCode, Name = model.Name, Surname = model.Surname };
        }

        private string codeGenerator()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder stringBuilder = new StringBuilder(12);
            Random random = new Random();

            for (int i = 0; i < 12; i++)
            {
                stringBuilder.Append(chars[random.Next(chars.Length)]);
            }

            if (db.User.Any(x => x.InvitationCode != null && x.InvitationCode.Equals(stringBuilder.ToString())))
            {
                return codeGenerator();
            }

            return stringBuilder.ToString();
        }
        #endregion private methods
    }
}
