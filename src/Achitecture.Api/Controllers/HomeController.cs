using Achitecture.Application.BusinessCatalog.ProductCategories.Queries.GetProductCategory;
using Achitecture.Application.BusinessCatalog.ProductCategories.Queries.GetProductCategory.Models;
using Achitecture.Application.Common.Models;
using Achitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Achitecture.Api.Controllers
{
    public class HomeController : ApplicationControllerBase
    {
        public HomeController()
        {
            
        }

        [HttpGet]
        public async Task<PaginatedList<ProductCategoryDto>> GetProductCategory([FromQuery] GetListProductCategoryQuery request)
        {
            return await Mediator.Send(request);
        }
    }
}
