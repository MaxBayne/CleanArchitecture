using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Models.Identity.Authorization
{
    public class AssigningPermissionRequest
    {
        public int permissionId { get; set; }

        public Guid userId { get; set; }
    }
}
