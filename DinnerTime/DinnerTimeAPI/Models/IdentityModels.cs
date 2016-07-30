using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DinnerTimeData;
using DinnerTimeLib;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DinnerTimeAPI.Models
{
    public class CustomUserStore : UserStore<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(DinnerTimeContext context) : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(DinnerTimeContext context) : base(context)
        {
        }
    }
}