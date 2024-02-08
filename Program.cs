/* Mini Project Wee6 
 * Author : Pedro Martinez
 * Date : 06/02/2023
 */

using MiniProject;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

bool isMatch = false;
bool validPrice = false;

string category = "", 
       product = "",
       sImput = "";

int index  = 0;
double price = 0.00,
       sum = 00;


List<Product>  list_Product  = new List <Product> ();
List<Category> list_Category = new List<Category>();

//
while (true)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("To Enter a new product - | To quit type exit");
    Console.ResetColor();

    Console.Write("Enter a Category : ");
    sImput = Console.ReadLine().Trim().ToUpper();

    if (sImput == "Q")
    {
        break;
    }
    else
    {
        //  Enter Category
        
        category = sImput;
        
        // To Fix Here 
        if (index > 0)
        {
            // Maybe do a joint search here for Id ???????
            isMatch = list_Category.Where( list_Category.Contains(index)).Any();
                        
        }
        
        if (!isMatch)
        {
            {
                index++;
                list_Category.Add(new Category(index, category));
            }
        }
        
        // Products 

        Console.Write("Enter a Product : ");
        product = Console.ReadLine().Trim();

        while (validPrice == false)
        {
            Console.Write("Enter Price : ");
            sImput = Console.ReadLine().Trim();

            try
            {
                price = Double.Parse(sImput);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Invalid Entry");
                Console.ResetColor();
                validPrice = false;
            }
            finally
            {

            }
        } //while validPrice 

        validPrice = true;
        
        list_Product.Add(new Product(index, product, price));

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Product succefully Added ! ");
        Console.ResetColor();

        Console.WriteLine(" -----------------------------------------" + index);
        } // ifElse 

    } // While Loop 

  

    //Sort List to new List 
    List<Product> sortedByPrice = list_Product.OrderBy(list_Product => list_Product.Price).ToList();

    // Print lists with Sum of Prices
    
    Console.WriteLine("Category".PadRight(10) + "Product".PadRight(10) + " Price");

    foreach (Product i in sortedByPrice)
    {
        Console.WriteLine(i.CatId.ToString().PadRight(10) + i.Name.PadRight(10) + " " + i.Price);
    }

    sum = list_Product.Sum(list_Product => list_Product.Price);  //Sum of Price
    Console.WriteLine("");
    Console.WriteLine("Total Amout :".PadRight(21) + sum);
