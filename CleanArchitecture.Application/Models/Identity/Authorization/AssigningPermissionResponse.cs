using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Models.Identity.Authorization
{
    public class AssigningPermissionResponse
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }
            
    }
}
