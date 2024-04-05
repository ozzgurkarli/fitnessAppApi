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

            Models.Program? model = await db.Program.Include(x=> x.ProgramMoves).FirstOrDefaultAsync(x=> x.Id.Equals(id));

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpGet("GetProgramsByUserId")]
        public async Task<IActionResult> GetProgramsByUserId(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Models.Program?> model = await db.Program.Where(x => x.UserId.Equals(id)).Include(x => x.ProgramMoves).ToListAsync();

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
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
            Models.Program model = new Models.Program{ Id = dto.Id, UserId = dto.UserId, ProgramName = dto.ProgramName, RecordDate = DateTime.Now, ProgramMoves = new List<ProgramMove>() };

            dto.ProgramMoves.ForEach(_ =>
            {
                model.ProgramMoves.Add(new ProgramMove { Id = _.Id, Index = _.Index, MoveId = _.MoveId, MoveName = _.MoveName, Muscle = _.Muscle, ProgramId = model.Id });
            });

            return model;
        }


        #endregion private methods
    }
}
