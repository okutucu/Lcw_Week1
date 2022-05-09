using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Api.DbOperations;
using Product.Api.ProductOperations.CreateProduct;
using Product.Api.ProductOperations.DeleteProduct;
using Product.Api.ProductOperations.GetProductDetail;
using Product.Api.ProductOperations.GetProducts;
using Product.Api.ProductOperations.SearchProduct;
using Product.Api.ProductOperations.UpdateProduct;
using static Product.Api.ProductOperations.UpdateProduct.UpdateProductCommand;

namespace Product.Api.Controllers
{
    [ApiController]
    [Route("[controller]s")]

    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;

        private readonly IMapper _mapper;

        public ProductController(ProductDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetProducts() {

            GetProductsQuery query = new GetProductsQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ProductDetailViewModel result;
            try
            {
                GetProductDetailQuery query = new GetProductDetailQuery(_context, _mapper);
                query.ProductId = id;
                GetProductQueryValidator validator = new GetProductQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Product>>> Search([FromQuery] SearchProduct search)
        {
            try
            {
                IQueryable<Product> query = _context.Products;

                if (!string.IsNullOrEmpty(search.Name))
                {
                    query = query.Where(e => e.ProductName.Contains(search.Name));
                }

                if(query.Count()==0)
                {
                    return NotFound("Ürün Bulunamadı");
                }

                return await query.ToListAsync();


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

           
          

            
        }




        [HttpPost]
        public IActionResult AddProduct([FromBody] CreateProductModel newProduct)
        {
            CreateProductCommand command = new CreateProductCommand(_context,_mapper);
            try
            {
                command.Model = newProduct;
                CreateProductCommandValidator validator = new CreateProductCommandValidator();

                validator.ValidateAndThrow(command);


                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
           
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductModel updatedProduct)
        {
            try
            {
                UpdateProductCommand command = new UpdateProductCommand(_context);
                command.ProductId = id;
                command.Model = updatedProduct;

                UpdateProductCommandValidator validator = new UpdateProductCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeletedProduct(int id)
        {
            try
            {
                DeleteProductCommand command = new DeleteProductCommand(_context);
                command.ProductId = id;
                DeleteProductCommandValidator validator = new DeleteProductCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }

    }
}
