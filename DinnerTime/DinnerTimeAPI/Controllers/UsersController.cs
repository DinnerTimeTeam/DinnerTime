using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using DinnerTimeData;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace DinnerTimeAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : ApiController
    {
        private readonly ApplicationUserManager manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

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
        public async Task<IHttpActionResult> AssignUserToRole(string username, string rolename)
        {
            User user = await manager.FindByNameAsync(username);
            IdentityResult result = await manager.AddToRoleAsync(user.Id, rolename);

            if (result.Succeeded)
                return Ok($"Added {user.UserName} to role {rolename}");

            return BadRequest("Åh nej");
        }
    }
}
