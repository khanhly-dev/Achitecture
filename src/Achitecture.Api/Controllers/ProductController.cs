using Achitecture.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Achitecture.Application.BusinessCatalog.ProductHandle.Queries.GetListPagingProduct.Models;
using Achitecture.Application.BusinessCatalog.ProductHandle.Queries.GetListPagingProduct;

namespace Achitecture.Api.Controllers
{
    public class ProductController : ApplicationControllerBase
    {
        public ProductController()
        {
            
        }

        [HttpGet("get-list-product")]
        public async Task<PaginatedList<ProductDto>> GetListProduct([FromQuery] GetListPagingProductQuery request)
        {
            return await Mediator.Send(request);
        }
    }
}
