using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    internal class Product
    {
        // Constructor
        
        //public Product(int catId, string name, double price  )
        public Product(string category, string name, double price  )
        {
            Cat = category;
            // CatId = caId; 
            Name = name;
            Price = price;
            
        }

        //properties
        public string Cat { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        
        
        //methods 
    }



}
