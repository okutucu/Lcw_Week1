using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Product.Api.Common;
using Product.Api.DbOperations;

namespace Product.Api.ProductOperations.GetProducts
{
    public class GetProductsQuery
    {
        private readonly ProductDbContext _dbContenxt;
        private readonly IMapper _mapper;

        public GetProductsQuery(ProductDbContext dbContenxt, IMapper mapper)
        {
            _dbContenxt = dbContenxt;
            _mapper = mapper;
        }

        public List<ProductViewModel> Handle()
        {
            List<Product> productList = _dbContenxt.Products.OrderBy(x => x.Id).ToList<Product>();
            List<ProductViewModel> vm = _mapper.Map <List<ProductViewModel>>(productList);


            return vm;
        }
    }

    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public string CreatedDate { get; set; }
    }
}
