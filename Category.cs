using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    internal class Category
    {
        //constructor
        public Category() { }
        
        public Category (int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Properties 
        public int Id { get; set; }
        public string Name { get; set; }
        
        //Methods
        
    }





}

