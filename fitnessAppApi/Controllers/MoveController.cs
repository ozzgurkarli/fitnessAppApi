using AutoMapper;
using fitnessAppApi.Constants;
using fitnessAppApi.DTO;
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

        #region public methods

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

        [HttpPost("GetMovesByMuscle")]
        public async Task<IActionResult> GetMovesByMuscle(DTOMove dto)
        {
            Move model = mapper.Map<Models.Move>(dto);

            if (model.Muscle == null)
            {
                return BadRequest();
            }

            List<Move> list = await database.Move.Where(x => x.Muscle.Equals(model.Muscle)).ToListAsync();

            if (list.IsNullOrEmpty())
            {
                return BadRequest();
            }

            return Ok(list);
        }

        #endregion public methods

        #region private methods
        #endregion private methods
    }
}
