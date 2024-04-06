using AutoMapper;
using fitnessAppApi.DTO;
using fitnessAppApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fitnessAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController(FitnessContext context, IMapper _mapper) : ControllerBase
    {
        private readonly FitnessContext db = context;
        private readonly IMapper mapper = _mapper;

        #region public methods

        [HttpGet("GetWorkoutById")]
        public async Task<IActionResult> GetWorkoutById(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Workout? model = await db.Workout.Where(x => x.Id.Equals(id)).Include(x => x.WorkoutMoves).FirstOrDefaultAsync();

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpGet("GetWorkoutsByUserId")]
        public async Task<IActionResult> GetWorkoutsByUserId(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Workout> models = await db.Workout.Where(x => x.UserId.Equals(id)).Include(x => x.WorkoutMoves).ToListAsync();

            if (models == null || models.Count == 0)
            {
                return NotFound();
            }

            return Ok(models);
        }

        [HttpPost("CreateByProgramId")]
        public async Task<IActionResult> CreateByProgramId(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Models.Program? program = await db.Program.Where(x => x.Id.Equals(id)).Include(x => x.ProgramMoves).FirstOrDefaultAsync();

            if (program == null)
            {
                return NotFound();
            }

            Workout model = new Workout { Completed = false, Duration = 0, ProgramId = program.Id, ProgramName = program.ProgramName, RecordDate = DateTime.Now, UserId = program.UserId, WorkoutMoves = new List<WorkoutMove>() };

            program.ProgramMoves.ForEach(_ =>
                model.WorkoutMoves.Add(new WorkoutMove { Index = _.Index, MoveId = _.MoveId, MoveName = _.MoveName, Repeat = 0, SetCount = 0, Weight = 0 })
            );

            db.Workout.Add(model);

            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetWorkoutById), new { Id = model.Id }, model);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(DTOWorkout dto)
        {
            Workout model = mapper.Map<Workout>(dto);

            db.Workout.Add(model);

            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetWorkoutById), new { Id = model.Id }, model);
        }

        #endregion public methods

        #region private methods
        #endregion private methods
    }
}
