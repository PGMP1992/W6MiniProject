/* Mini Project Wee6 
 * Author : Pedro Martinez
 * Date : 06/02/2023
 */

using MiniProject;
using System.ComponentModel.Design;

bool validPrice = false;

string
    sCat = "",
    sProd = "",
    sPrice = "";

int c_index = 1;  //Counter for Category Id 
int p_index = 1;  //Counter for Category Id 

double price = 0.00,
       sum = 00;

//Category cat1 = new Category(0, "");
//Product prod1 = new Product(0, "", 0.00);    

Category cat1 = new Category("");
Product prod1 = new Product("", "", 0.00);

List<Product> list_Product = new List<Product>();
List<Category> list_Category = new List<Category>();

//
while (true)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("To Enter a new product - Follow the Steps | To quit Enter + Q");
    Console.ResetColor();

    //  Enter Category
    
    Console.Write("Enter a Category : ");
    sCat = Console.ReadLine().Trim().ToUpper();

    if (sCat == "Q")
    {
        break;
    }
    else
    {
        // Check if doesnt exists 
        if ( ! list_Category.Any(c => c.Name == sCat))
        {
            // Add New Category
            list_Category.Add(new Category(sCat));
        }

        else
        {
            // Find Category 
            if (list_Category.Where(p => p.Name.Contains(sCat)).Count() > 0)
            {
                cat1.Name = list_Category.Where(p => p.Name.Contains(sCat)).ToString();
                //list_Category.Add(new Category(sCat));
            }
        }         
        
        // Products 

        Console.Write("Enter a Product : ");
        sProd = Console.ReadLine().Trim();
        validPrice = true;

            Console.Write("Enter Price : ");
            sPrice = Console.ReadLine().Trim();

            try
            {
                price = Double.Parse(sPrice);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Invalid Entry");
                Console.ResetColor();
                validPrice = false;
            }
            finally
            { }

            p_index++;
            list_Product.Add(new Product(sCat, sProd, price));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Product succefully Added ! ");
            Console.ResetColor();

            Console.WriteLine(" -----------------------------------------" + c_index);
        } // ifelse 

    } // While Loop not Q 

    // Sort List to new List 
    List<Product> sortedByPrice = list_Product.OrderBy(list_Product => list_Product.Price).ToList();

// Print lists with Sum of Prices
Console.WriteLine("Sorted by Price");
Console.WriteLine("===============");
Console.WriteLine("Category".PadRight(10) + "Product".PadRight(10) + " Price");

    foreach (Product i in sortedByPrice)
    {
        Console.WriteLine(i.Cat.PadRight(10) + i.Name.PadRight(10) + " " + i.Price);
    }

    // Calculate Sum of Price by Category
    sum = list_Product.Sum(list_Product => list_Product.Price);  //Sum of Price

    Console.WriteLine("");
    Console.WriteLine("Total Amout :".PadRight(21) + sum);
    Console.ReadLine();

