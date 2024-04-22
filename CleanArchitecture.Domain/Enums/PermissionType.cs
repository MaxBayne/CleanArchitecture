using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Enums
{
    public enum PermissionType
    {
        CanInsert = 1,
        CanUpdate = 2,
        CanDelete = 3,
        CanPrint = 4,
        CanImport = 5,
        CanExport = 6,
        CanView = 7,
    }
}
