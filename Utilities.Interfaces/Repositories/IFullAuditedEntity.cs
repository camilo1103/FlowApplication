using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Interfaces.Repositories
{
    public interface IFullAuditedEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
