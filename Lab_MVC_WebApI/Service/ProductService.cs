using Lab_MVC_WebApI.Models;
using Lab_MVC_WebApI.Models.Dtos;
using Lab_MVC_WebApI.Repository.Interface;
using Lab_MVC_WebApI.Service.Interface;

namespace Lab_MVC_WebApI.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public List<ProductDto> GetProductList()
        {
            var productDtos = _repository.Query().Select(product=> new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                ImgUrl = product.ImgUrl,
                Price = product.Price
            }).ToList();
            return productDtos;
        }

        public ProductDto GetProduct(int id)
        {
            var productDto =  _repository.Query()
                .Where(product => product.Id == id)
                .Select(product=>new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    ImgUrl = product.ImgUrl,
                    Price = product.Price
                })
                .Single();
            return productDto;
        }

        public bool CreateProduct(ProductDto productDto)
        {
            var currentProductCount = _repository.Query().Count;
            var product = new Product
            {
                Id = currentProductCount+1,
                Name = productDto.Name,
                ImgUrl = productDto.ImgUrl,
                Price = productDto.Price
            };
            return _repository.Create(product);
        }
    }
}
