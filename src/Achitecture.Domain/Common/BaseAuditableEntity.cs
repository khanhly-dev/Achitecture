using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture.Domain.Common
{
    public class BaseAuditableEntity<TKey> : BaseEntity<TKey>
    {
        public DateTime CreatedTime { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModifiedTime { get; set; }

        public string LastModifiedBy { get; set; }
    }
}
