using System;
using System.Linq;
using Product.Api.DbOperations;

namespace Product.Api.ProductOperations.UpdateProduct
{
    public class UpdateProductCommand
    {
        private readonly ProductDbContext _context;
        public int ProductId { get; set; }
        public UpdateProductModel Model { get; set; }

        public UpdateProductCommand(ProductDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            Product product = _context.Products.SingleOrDefault(x => x.Id == ProductId);

            if (product is null) throw new InvalidOperationException(" Güncellenecek Kitap bulunamadı");

            product.CategoryId = Model.CategoryId != default ? Model.CategoryId : product.CategoryId;
            product.ProductName = Model.ProductName != default ? Model.ProductName : product.ProductName;

            _context.SaveChanges();
        }
        public class UpdateProductModel
        {
            public string ProductName { get; set; }
            public int CategoryId { get; set; }
        }
    }
}
