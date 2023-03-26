41 lines (35 sloc)  1.21 KB

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        using (StreamReader reader = new StreamReader("C:/Users/Admin/Documents/products.txt"))
        {
            List<Product> products = new List<Product>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(',');
                Product product = new Product();
                product.Name = parts[0];
                product.Category = parts[1];
                product.Price = double.Parse(parts[2]);
                products.Add(product);
            }

            List<Product> filteredProducts = products.OrderByDescending(products => products.Category).ToList();

            foreach (var group in filteredProducts)
            {
                Console.WriteLine("Категорія: {0} , Назва: {1} , Ціна: {2} грн", group.Category,group.Name,group.Price);
            }
        }
    }

