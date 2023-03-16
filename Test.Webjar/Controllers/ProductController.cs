using Application.Product.Command.AddPriceOptionValue;
using Application.Product.Command.AddProduct;
using Application.Product.Command.AddProductAdditive;
using Application.Product.Command.AddProductCategory;
using Application.Product.Command.AddProductPrice;
using Application.Product.Command.AddProductPriceOption;
using Application.Product.Query.GetProduct;
using Application.Product.Query.GetProductAdditive;
using Application.Product.Query.GetProductCategory;
using Appliction.Product.Shared.Model.ProductAdditive;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Product.Shared.Product;
using Services.Product.Shared.ProductAdditive.Vm;
using Services.Product.Shared.ProductCategory;
using Services.Product.Shared.ProductPrice;
using Services.Product.Shared.ProductPriceOption;

namespace Test.Webjar.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //public IActionResult GetProduct2(string productName, List<string> optionValueNames)
        //{
        //    var query = _context.Product
        //        .Include(p => p.PriceHistories)
        //        .ThenInclude(ph => ph.OptionValue)
        //        .ThenInclude(ov => ov.Option)
        //        .AsQueryable();

        //    // apply filters
        //    if (!string.IsNullOrEmpty(productName))
        //    {
        //        query = query.Where(p => p.Name.Contains(productName));
        //    }

        //    if (optionValueNames != null && optionValueNames.Any())
        //    {
        //        query = query.Where(p =>
        //            p.OptionValues.Any(ov => optionValueNames.Contains(ov.Value))
        //            && p.OptionValues.Count() == optionValueNames.Count
        //        );
        //    }

        //    var result = query.Select(p => new
        //    {
        //        ProductName = p.Name,
        //        OptionValues = p.OptionValues.Select(ov => new
        //        {
        //            OptionName = ov.Option.Name,
        //            Value = ov.Value
        //        }).ToList(),
        //        Price = p.PriceHistories.OrderByDescending(ph => ph.CreatedAt).FirstOrDefault().Price,
        //        Inventory = p.PriceHistories.OrderByDescending(ph => ph.CreatedAt).FirstOrDefault().Inventory,
        //        Discount = p.PriceHistories.OrderByDescending(ph => ph.CreatedAt).FirstOrDefault().Discount
        //    }).ToList();

        //    return Ok(result);
        //}
        #region Product
        [HttpGet("[action]")]
        public async Task<ServiceResult> GetProduct(string? productTitle, string? catgoryTitle)
        {
            var result = await _mediator.Send(new GetProductQuery(productTitle, catgoryTitle));
            return result;
        }

        [HttpPost("[action]")]
        public async Task<ServiceResult> AddProduct([FromForm] ProductModel model)
        {
            var result = await _mediator.Send(new AddProductCommand(model));
            return result;
        }
        #endregion

        #region ProductCategory
        [HttpPost("[action]")]
        public async Task<ServiceResult> AddProductCategory(string Title)
        {
            var result = await _mediator.Send(new AddProductCategoryCommand(Title));
            return result;
        }

        [HttpGet("[action]")]
        public async Task<ServiceResult<List<ProductCategoryVm>>> GetProductCategory(string? filter)
        {
            var result = await _mediator.Send(new GetProductCategoryQuery(filter));
            return result;
        }
        #endregion

        #region ProductAdditive
        [HttpPost("[action]")]
        public async Task<ServiceResult> AddProductAdditive([FromBody] ProductAdditvieModel model)
        {
            var result = await _mediator.Send(new AddProductAdditiveCommand(model));
            return result;
        }

        [HttpGet("[action]")]
        public async Task<ServiceResult<List<ProductAddivesVm>>> GetProductAdditive(string? title, string? categoryTitle)
        {
            var result = await _mediator.Send(new GetProductAdditiveQuery(title, categoryTitle));
            return result;
        }
        #endregion

        #region ProductPriceOption
        [HttpPost("[action]")]
        public async Task<ServiceResult> AddProductPriceOption([FromBody] PriceOptionModel Model)
        {
            var result = await _mediator.Send(new AddProductPriceOptionCommand(Model));
            return result;
        }
        #endregion

        #region ProductPriceOptionValue
        [HttpPost("[action]")]
        public async Task<ServiceResult> AddProductPriceOptionValue([FromBody] PriceOptionValueModel Model)
        {
            var result = await _mediator.Send(new AddPriceOptionValueCommand(Model));
            return result;
        }
        #endregion

        #region ProductPrice
        [HttpPost("[action]")]
        public async Task<ServiceResult> AddProductPrice([FromBody] ProductPriceModel model)
        {
            var result = await _mediator.Send(new AddProductPriceCommand(model));
            return result;
        }
        #endregion

    }
}
