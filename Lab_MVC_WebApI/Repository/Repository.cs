using Lab_MVC_WebApI.Models;
using Lab_MVC_WebApI.Repository.Interface;

namespace Lab_MVC_WebApI.Repository
{
    public class Repository : IRepository
    {
        private List<Product> Products { get; set; }

        public List<Product> Query()
        {
            return Products ??= InitProduct();
        }

        private static List<Product> InitProduct()
        {
            return  new List<Product>()
            {
                new()
                {
                    Id = 1,
                    Name = "MX Master 3S",
                    Price = 3690,
                    ImgUrl = "https://i2.momoshop.com.tw/1687155229/goodsimg/0010/254/365/10254365_R1.webp",
                },
                new()
                {
                    Id = 2,
                    Name = "G502 Hero",
                    Price = 1990,
                    ImgUrl = "https://i3.momoshop.com.tw/1683165651/goodsimg/0010/649/651/10649651_R1.webp",
                }
            };
        }

        public bool Create(Product product)
        {
            try
            {
                Products.Add(product);
                return true;    
            }
            catch
            {
                return false;
            }
        }
        
        public bool Delete(int productId)
        {
            try
            {
                var target = Products.Single(product => product.Id == productId);
                Products.Remove(target);
                return true;    
            }
            catch
            {
                return false;
            }
        }
    }
}