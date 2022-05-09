using System;
using System.Linq;
using AutoMapper;
using Product.Api.Common;
using Product.Api.DbOperations;

namespace Product.Api.ProductOperations.GetProductDetail
{
    public class GetProductDetailQuery
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;
        public int ProductId { get; set; }
        public GetProductDetailQuery(ProductDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ProductDetailViewModel Handle()
        {
            Product product = _dbContext.Products.Where(product => product.Id == ProductId).FirstOrDefault();
            if (product is null) throw new InvalidOperationException("Ürün bulunamadı");
            ProductDetailViewModel vm = _mapper.Map<ProductDetailViewModel>(product); 
          


            return vm ;
        }
    }
    public class ProductDetailViewModel
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string CreatedDate { get; set; }
        public int Stock { get; set; }
    }
}
