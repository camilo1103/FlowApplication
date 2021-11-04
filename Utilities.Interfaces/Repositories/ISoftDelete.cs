using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Interfaces.Repositories
{
    public interface ISoftDelete
    {
        public bool IsDelete { get; set; }
    }
}
