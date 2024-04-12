using AutoMapper;
using fitnessAppApi.Constants;
using fitnessAppApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace fitnessAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveController(FitnessContext context, IMapper _mapper) : ControllerBase
    {
        private readonly FitnessContext database = context;
        private readonly IMapper mapper = _mapper;

        [HttpGet("GetMoves")]
        public async Task<IActionResult> GetMoves()
        {
            List<Move> model = await database.Move.ToListAsync();

            if (model.IsNullOrEmpty())
            {
                return BadRequest();
            }

            return Ok(model);
        }

        [HttpGet("GetMovesByMuscleId")]
        public async Task<IActionResult> GetMovesByMuscleId(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            List<Move> model = await database.Move.Where(x => x.MuscleId.Equals(id)).ToListAsync();

            if(model.IsNullOrEmpty())
            {
                return BadRequest();
            }

            return Ok(model);
        }
    }
}
