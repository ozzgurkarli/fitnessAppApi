using fitnessAppApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace fitnessAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationCodeController(FitnessContext context) : ControllerBase
    {
        private readonly FitnessContext db = context;

        [HttpPost("false")]
        public async void InvitationHandler(InvitationCode model)
        {
            if (db.InvitationCode.Where(x => x.Code!.Equals(model.Code)).Count() > 3)
            {
                return;
            }

            db.InvitationCode.Add(model);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
