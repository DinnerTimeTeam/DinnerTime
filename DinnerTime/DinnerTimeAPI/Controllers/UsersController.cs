using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using DinnerTimeData;
using DinnerTimeLib;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace DinnerTimeAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : ApiController
    {
        private readonly DinnerTimeContext db = new DinnerTimeContext();

        private readonly ApplicationUserManager manager =
            HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

        public IEnumerable<User> GetUsers()
        {
            return manager.Users.ToList();
        }

        // POST: api/Accounts
        public async Task<IHttpActionResult> PostAccount(User user)
        {
            IdentityResult result = await manager.CreateAsync(user, "Password1!");
            if (result.Succeeded)
                return Ok($"{RequestContext.Principal.Identity.Name} created user: {user.UserName} with password: Password1!");

            return BadRequest(result.Errors.First());
        }

        [Route("api/users/{username}/roles/{rolename}")]
        [HttpPost]
        public async Task<IHttpActionResult> AssignUserToRole(string username, string rolename)
        {
            User user = await manager.FindByNameAsync(username);
            IdentityResult result = await manager.AddToRoleAsync(user.Id, rolename);

            if (result.Succeeded)
                return Ok($"Added {user.UserName} to role {rolename}");

            return BadRequest(result.Errors.First());
        }

        [Authorize]
        [Route("api/users/{username}/households/{householdid}")]
        [HttpPost]
        public async Task<IHttpActionResult> AssignUserToHousehold(string username, int householdid)
        {
            User user = db.Users.Include(x => x.Households).SingleOrDefault(x => x.UserName == username);
            User invokerUser = db.Users.Include(x => x.Households).SingleOrDefault(x => x.UserName == RequestContext.Principal.Identity.Name);
            Household household = await db.Households.FindAsync(householdid);

            if (user == null)
                return NotFound();

            if (household == null)
                return NotFound();

            if (invokerUser != null && invokerUser.Households.Any(x => x.Id == household.Id) == false)
                return BadRequest("User not part of the household.");
            
            user.Households.Add(household);

            await db.SaveChangesAsync();
            return Ok($"{user.UserName} added to {household.Name}");
        }
    }
}
