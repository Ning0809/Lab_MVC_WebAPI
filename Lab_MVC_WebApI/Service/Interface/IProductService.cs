using Lab_MVC_WebApI.Models.Dtos;

namespace Lab_MVC_WebApI.Service.Interface
{
    public interface IProductService
    {
        List<ProductDto> GetProductList();
        ProductDto GetProduct(int id);
        bool CreateProduct(ProductDto productDto);
    }
}