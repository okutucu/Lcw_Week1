using System;
using System.Linq;
using AutoMapper;
using Product.Api.DbOperations;

namespace Product.Api.ProductOperations.CreateProduct
{
    public class CreateProductCommand
    {
        public CreateProductModel Model { get; set; }

        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateProductCommand(ProductDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            Product product = _dbContext.Products.SingleOrDefault(x => x.ProductName == Model.ProductName);

            if (product is not null) throw new InvalidOperationException("Ürün zaten mevcut");
            product = _mapper.Map<Product>(Model);
            _dbContext.Add(product);
            _dbContext.SaveChanges();
        }

        
    }
    public class CreateProductModel
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedDate { get; set; }
        
        
    }
}
