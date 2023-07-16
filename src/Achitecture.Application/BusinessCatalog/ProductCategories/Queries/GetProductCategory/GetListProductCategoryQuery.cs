using AutoMapper;
using AutoMapper.QueryableExtensions;
using Achitecture.Application.BusinessCatalog.ProductCategories.Queries.GetProductCategory.Models;
using Achitecture.Application.Common.Mappings;
using Achitecture.Application.Common.Models;
using Achitecture.Domain.Entities;
using Achitecture.Repository.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture.Application.BusinessCatalog.ProductCategories.Queries.GetProductCategory
{
    // Request params
    public record GetListProductCategoryQuery : IRequest<PaginatedList<ProductCategoryDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
    public class GetListProductCategoryQueryHandler : IRequestHandler<GetListProductCategoryQuery, PaginatedList<ProductCategoryDto>>
    {
        private readonly IBaseRepo<ProductCategory, int> _productCategoryRepo;
        private readonly IMapper _mapper;
        public GetListProductCategoryQueryHandler(IBaseRepo<ProductCategory, int> productCategoryRepo, IMapper mapper)
        {
            _productCategoryRepo = productCategoryRepo;
            _mapper = mapper;
        }

        // Business logic
        public async Task<PaginatedList<ProductCategoryDto>> Handle(GetListProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var productCategory = _productCategoryRepo.GetDbSet();
            var result = await productCategory
                .AsNoTracking()
                .ProjectTo<ProductCategoryDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }
    }
}
