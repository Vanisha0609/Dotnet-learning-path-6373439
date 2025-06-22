using System;

namespace EcommerceSearch
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public void Display()
        {
            Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Category: {Category}");
        }
    }

    class Program
    {
        static Product LinearSearch(Product[] products, string name)
        {
            foreach (var product in products)
            {
                if (product.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return product;
                }
            }
            return null;
        }

        static Product BinarySearch(Product[] products, string name)
        {
            int left = 0;
            int right = products.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int comparison = string.Compare(products[mid].ProductName, name, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                    return products[mid];
                else if (comparison < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }

        static void Main(string[] args)
        {
            Product[] productList = new Product[]
            {
                new Product { ProductId = 1, ProductName = "Camera", Category = "Electronics" },
                new Product { ProductId = 2, ProductName = "Laptop", Category = "Electronics" },
                new Product { ProductId = 3, ProductName = "Shoes", Category = "Fashion" },
                new Product { ProductId = 4, ProductName = "Watch", Category = "Accessories" }
            };

            // Linear Search
            Console.WriteLine("Linear Search:");
            var result1 = LinearSearch(productList, "Shoes");
            Console.WriteLine(result1 != null ? "Found: " + result1.ProductName : "Not Found");

            // Binary Search (requires sorted array)
            Array.Sort(productList, (x, y) => x.ProductName.CompareTo(y.ProductName));
            Console.WriteLine("\nBinary Search:");
            var result2 = BinarySearch(productList, "Laptop");
            Console.WriteLine(result2 != null ? "Found: " + result2.ProductName : "Not Found");
        }
    }
}

