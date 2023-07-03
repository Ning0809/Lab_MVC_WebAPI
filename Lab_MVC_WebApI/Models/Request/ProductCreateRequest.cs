namespace Lab_MVC_WebApI.Models.Request;

public class ProductCreateRequest
{
    public string? Name { get; set; }
    public string? ImgUrl { get; set; }
    public decimal Price { get; set; }
}