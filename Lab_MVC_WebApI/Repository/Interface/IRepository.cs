using Lab_MVC_WebApI.Models;

namespace Lab_MVC_WebApI.Repository.Interface
{
    public interface IRepository
    {
        List<Product> Query();
        bool Create(Product product);
        bool Delete(int productId);
    }
}