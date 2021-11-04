using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\new\\new.json";
            Product[] products = new Product[5];
            for (int i = 0; i < 5; i++)
            {
                Product product = new Product();
                Console.WriteLine("Введите код продукта: ");
                product.code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите наименование продукта: ");
                product.name = Console.ReadLine();
                Console.WriteLine("Введите стоимость продукта: ");
                product.price = Convert.ToDouble(Console.ReadLine());
                products[i] = product;
            }

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                string jsonString = JsonSerializer.Serialize(products);
                sw.WriteLine(jsonString);
            }

            using (StreamReader sr = new StreamReader(path))
            {
                string readSpt = sr.ReadLine();
                List<Product> a = JsonSerializer.Deserialize<List<Product>>(readSpt);

                string name = "";
                double price = 0;
                for (int i = 0; i < 5; i++)
                {
                    if(a[i].price > price)
                    {
                        name = a[i].name;
                        price = a[i].price;
                    }
                }
                Console.WriteLine("{0} {1}", name, price);
            }

            Console.ReadKey();
        }

        class Product
        {
            [JsonPropertyName("code")]
            public int code { get; set; }

            [JsonPropertyName("name")]
            public string name { get; set; }

            [JsonPropertyName("price")]
            public double price { get; set; }
        }
    }
}
