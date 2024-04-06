using AutoMapper;
using fitnessAppApi.DTO;
using fitnessAppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace fitnessAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController(FitnessContext context, IMapper _mapper) : ControllerBase
    {
        private readonly FitnessContext db = context;
        private readonly IMapper mapper = _mapper;

        #region public methods

        [HttpGet("GetProgramById")]
        public async Task<IActionResult> GetProgramById(int? id)
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

            List<Models.Program> model = await db.Program.Where(x => x.UserId.Equals(id)).Include(x => x.ProgramMoves).ToListAsync();

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(DTOProgram dto)
        {
            Models.Program model = mapper.Map<Models.Program>(dto);

            db.Program.Add(model);

            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetProgramById), new { Id = model.Id }, model);
        }

        #endregion public methods


        #region private methods

        #endregion private methods
    }
}
