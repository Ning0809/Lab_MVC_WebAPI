using Lab_MVC_WebApI.Enum;
using Lab_MVC_WebApI.Models.Dtos;
using Lab_MVC_WebApI.Models.Request;
using Lab_MVC_WebApI.Models.Response;
using Lab_MVC_WebApI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Lab_MVC_WebApI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllProduct")]
        public BaseResponse<List<ProductResponse>> Index()
        {
            var productList = _service.GetProductList().Select(product =>
                new ProductResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    ImgUrl = product.ImgUrl,
                    Price = product.Price
                }).ToList();
            return new BaseResponse<List<ProductResponse>>(ErrorCode.NoError, "Success", productList);
        }

        [HttpGet]
        [Route("GetProduct")]
        public BaseResponse<ProductResponse> Detail(int id)
        {
            var product = _service.GetProduct(id);
            var productResponse = new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                ImgUrl = product.ImgUrl,
                Price = product.Price
            };
            return new BaseResponse<ProductResponse>(ErrorCode.NoError, "Success", productResponse);
        }

        [HttpPost]
        [Route("CreateProduct")]
        public BaseResponse CreateProduct(ProductCreateRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                return new BaseResponse(ErrorCode.Error, "Request InValid");
            }

            var productDto = new ProductDto
            {
                Name = request.Name,
                ImgUrl = request.ImgUrl,
                Price = request.Price
            };

            if (!_service.CreateProduct(productDto))
            {
                return new BaseResponse(ErrorCode.Error, "Create Failed");
            }

            return new BaseResponse(ErrorCode.NoError, "Success");
        }

    }
}

