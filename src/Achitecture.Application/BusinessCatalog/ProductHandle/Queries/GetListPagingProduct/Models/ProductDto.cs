using Achitecture.Application.Common.Mappings;
using Achitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture.Application.BusinessCatalog.ProductHandle.Queries.GetListPagingProduct.Models
{
    public class ProductDto : IAutoMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CategoryId { get; set; }
    }
}
