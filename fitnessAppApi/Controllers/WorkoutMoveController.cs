using AutoMapper;
using fitnessAppApi.DTO;
using fitnessAppApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fitnessAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutMoveController(FitnessContext context, IMapper _mapper) : ControllerBase
    {
        private readonly FitnessContext db = context;
        private readonly IMapper mapper = _mapper;

        #region public methods


        [HttpPut("UpdateWorkoutMove")]
        public async Task<IActionResult> UpdateWorkoutMove(DTOWorkoutMove move)
        {
            WorkoutMove model = db.WorkoutMove.Where(x => x.Id == move.Id).First();

            model.SetCount++;
            model.Repeat += move.Repeat;
            model.Weight += (move.Repeat * move.Weight);

            if (move.Weight > model.HighestWeight)
            {
                model.HighestWeight = move.Weight;
            }

            await db.SaveChangesAsync();

            return Ok();
        }

        #endregion public methods
    }
}
