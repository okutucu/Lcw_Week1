using System;
using System.Linq;
using Product.Api.DbOperations;

namespace Product.Api.ProductOperations.DeleteProduct
{
    public class DeleteProductCommand
    {
        private readonly ProductDbContext _context;
        public int ProductId { get; set; }

        public DeleteProductCommand(ProductDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            Product product = _context.Products.SingleOrDefault(x => x.Id == ProductId);
            if (product is null) throw new InvalidOperationException("Silinecek Urun bulunamadı");

            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
