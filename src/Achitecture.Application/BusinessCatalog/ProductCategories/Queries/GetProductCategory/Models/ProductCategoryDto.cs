using Achitecture.Application.Common.Mappings;
using Achitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture.Application.BusinessCatalog.ProductCategories.Queries.GetProductCategory.Models
{
    public class ProductCategoryDto : IAutoMapFrom<ProductCategory>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
