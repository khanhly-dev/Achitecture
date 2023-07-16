using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture.Application.BusinessCatalog.ProductCategories.Queries.GetProductCategory.Validators
{
    public class GetListProductCategoryValidator : AbstractValidator<GetListProductCategoryQuery>
    {
        public GetListProductCategoryValidator()
        {
            RuleFor(x => x.PageNumber)
                .NotEmpty().WithMessage("Page number is required.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .NotEmpty().WithMessage("Page number is required.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
