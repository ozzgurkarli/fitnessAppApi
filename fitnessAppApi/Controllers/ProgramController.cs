using fitnessAppApi.DTO;
using fitnessAppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace fitnessAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController(FitnessContext context) : ControllerBase
    {
        private readonly FitnessContext db = context;

        #region public methods

        [HttpGet("GetProgramsById")] 
        public async Task<IActionResult> GetProgramsById(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Models.Program? model = await db.Program.FirstOrDefaultAsync(x => x.Id.Equals(id));
             
            if(model == null)
            {
                return NotFound();
            }
            model.Moves = [new ProgramMove {Id = 5, MoveName = "ananınamı" }];

            return Ok(modelToDto(model));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(DTOProgram dto)
        {
            Models.Program model = dtoToModel(dto);

            db.Program.Add(model);

            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetProgramsById), new { Id = model.Id }, model);
        }

        #endregion public methods


        #region private methods

        private Models.Program dtoToModel(DTOProgram dto)
        {
            return new Models.Program { Id = dto.Id, UserId = dto.UserId, ProgramName = dto.ProgramName, RecordDate = DateTime.Now, Moves = dto.Moves };
        }

        private DTOProgram modelToDto(Models.Program model)
        {
            return new DTOProgram { Id = model.Id, UserId = model.UserId, ProgramName = model.ProgramName, Moves = model.Moves };
        }

        #endregion private methods
    }
}
