using AutoMapper;
using Product.Api.ProductOperations.CreateProduct;
using Product.Api.ProductOperations.GetProductDetail;
using Product.Api.ProductOperations.GetProducts;

namespace Product.Api.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductModel, Product>();
            CreateMap<Product, ProductDetailViewModel>().ForMember(dest=> dest.Category, opt=> opt.MapFrom(src=> ((CategoryEnum)src.CategoryId).ToString()));
            CreateMap<Product, ProductViewModel>().ForMember(dest=> dest.Category, opt=> opt.MapFrom(src=> ((CategoryEnum)src.CategoryId).ToString()));
        }
    }
}  
 