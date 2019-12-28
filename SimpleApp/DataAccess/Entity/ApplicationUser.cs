using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SimpleApp.DataAccess.Entity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public virtual ICollection<IdentityUserRole<Guid>> UserRoles { get; set; }

    }
}
