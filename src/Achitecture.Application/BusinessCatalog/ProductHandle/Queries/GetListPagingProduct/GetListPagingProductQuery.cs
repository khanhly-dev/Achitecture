using AutoMapper;
using Achitecture.Application.BusinessCatalog.ProductHandle.Queries.GetListPagingProduct.Models;
using Achitecture.Application.Common.Models;
using Achitecture.Repository.Common.Interface;
using Achitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Achitecture.Application.BusinessCatalog.ProductCategories.Queries.GetProductCategory.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Achitecture.Application.Common.Mappings;

namespace Achitecture.Application.BusinessCatalog.ProductHandle.Queries.GetListPagingProduct
{
    public class GetListPagingProductQuery : IRequest<PaginatedList<ProductDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetListPagingProductQueryHandler : IRequestHandler<GetListPagingProductQuery, PaginatedList<ProductDto>>
    {
        private readonly IBaseRepo<Product, int> _producRepo;
        private readonly IMapper _mapper;
        public GetListPagingProductQueryHandler(IBaseRepo<Product, int> producRepo, IMapper mapper)
        {
            _producRepo = producRepo;
            _mapper = mapper;
        }

        // Business logic
        public async Task<PaginatedList<ProductDto>> Handle(GetListPagingProductQuery request, CancellationToken cancellationToken)
        {
            var product = _producRepo.GetDbSet();
            var result = await product
                .Where(x => x.IsDeleted == false)
                .AsNoTracking()
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }
    }
}
