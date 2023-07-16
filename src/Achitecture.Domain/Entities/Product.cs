using Achitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture.Domain.Entities
{
    public class Product : BaseAuditableEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int CategoryId { get; set; }
        public bool Publish { get; set; }
    }
}
