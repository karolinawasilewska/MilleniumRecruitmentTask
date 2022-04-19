using System;

namespace MilleniumRecruitmentTask.Domain.Models
{
    public class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreateDate { get; private set; }

        public static Product Create(string name,
            decimal price)
        {
            return new Product
            {
                Name = name,
                Price = price,
                CreateDate = DateTime.Now
            };
        }

        public static Product Update(string name,
            decimal price, 
            Product current)
        {
            current.Name = name;
            current.Price = price;

            return current;
        }
    }
}
