﻿using Application.Product.Command.AddProductAdditive;
using Application.Product.Command.AddProductCategory;
using Application.Product.Query.GetProductAdditive;
using Application.Product.Query.GetProductCategory;
using Appliction.Product.Shared.Model.ProductAdditive;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Product.Shared.ProductAdditive.Vm;
using Services.Product.Shared.ProductCategory;

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
        #region Product
        [HttpGet("[action]")]
        public async Task<object> GetProducts()
        {
            return new object();
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
        public async Task<ServiceResult<List<ProductAddivesVm>>> GetProductAdditive(string? title ,string? categoryTitle)
        {
            var result = await _mediator.Send(new GetProductAdditiveQuery(title,categoryTitle));
            return result;
        }
        #endregion
    }
}