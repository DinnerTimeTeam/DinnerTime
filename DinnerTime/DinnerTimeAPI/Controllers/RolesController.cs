using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using DinnerTimeLib;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace DinnerTimeAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : ApiController
    {
        private readonly ApplicationRoleManager manager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

        public IEnumerable<CustomRole> GetRoles()
        {
            return manager.Roles.ToList();
        }

        [AllowAnonymous]
        public async Task<IHttpActionResult> PostRole(CustomRole role)
        {
            IdentityResult result = await manager.CreateAsync(role);
            if (result.Succeeded)
                return Ok($"{RequestContext.Principal.Identity.Name} created role: {role.Name}");

            return BadRequest(result.Errors.First());
        }
    }
}
