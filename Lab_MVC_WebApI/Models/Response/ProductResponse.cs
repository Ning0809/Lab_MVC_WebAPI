namespace Lab_MVC_WebApI.Models.Response;

public class ProductResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ImgUrl { get; set; }
    public decimal Price { get; set; }
}