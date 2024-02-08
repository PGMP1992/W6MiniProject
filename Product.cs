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
        public Product(int catId, string name, double price  )
        {
            CatId = catId;
            Name = name;
            Price = price;
            
        }

        //properties
        public int CatId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        
        
        //methods 
    }



}
