/* Mini Project Wee6 
 * Author : Pedro Martinez
 * Date : 09/02/2023
 */

using MiniProject;

bool validPrice = false;
bool exit = false;

string
    sCat = "",
    sProd = "",
    sPrice = "",
    sImput = "";

int p_index = 1;  //Counter for Category Id 

double price = 0.00,
       sum = 00;

Category cat1 = new Category("");
Product prod1 = new Product("", "", 0.00);

List<Product> list_Product = new List<Product>();
List<Category> list_Category = new List<Category>();

while( !exit) // Loop for new entry after list shown
{
    MsgColor("To Enter a new product - Follow the Steps | To quit Enter + Q", "Blue");

    //  Enter Category
    while (!exit)
    {
        Console.Write("Enter a Category : ");
        sCat = Console.ReadLine().Trim().ToUpper();

        if (sCat == "Q")
        {
            exit = true;
            break;
        }
        else if (sCat.Length == 0)
        {
             MsgInvalidEntry();
        }

        else
        {
            // Check if Product exists 
            if ( !list_Category.Any(c => c.Name == sCat))
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
                }
            }

            // Enter Products 
            sProd = " "; //reset string 
            while (true)
            {
                Console.Write("Enter a Product  : ");
                sProd = Console.ReadLine().Trim().ToUpper();
            
                if (sProd.Length == 0 )
                {
                    MsgInvalidEntry();
                }
                else { 
                    break; 
                }
            }

            validPrice = false; // reset validPrice
            while (!validPrice)
            {
                Console.Write("Enter Price      : ");
                sPrice = Console.ReadLine().Trim();

                try
                {
                    price = double.Parse(sPrice);
                    validPrice = true;
                }
                catch (Exception ex)
                {
                    MsgInvalidEntry(); 
                }
                finally // do nothing 
                {
                }

            }  // while ( ! validPrice)

            p_index++;
            list_Product.Add(new Product(sCat, sProd, price));

            MsgColor(" Product succefully Added ! ", "Yellow");
            Console.WriteLine(" -----------------------------------------");
            exit = false;

        } // if else 
        
    } // while ! exit

    // List is not empty show list
    if (list_Category.Count() > 0)
    {
        PrintList(sum, list_Product);
  
        Console.WriteLine(" -----------------------------------------");
        MsgColor(" To Enter a Product enter: P  | To quit Enter Q ", "Green");
        
        sImput = ""; // Reset Imput

        while (sImput != "Q" && sImput != "P")
        {
            sImput = Console.ReadLine().Trim().ToUpper();
            if (sImput == "P") //New Product
            {
                exit = false;
            } 
            else if (sImput == "Q") // Quit 
            {
                exit = true;
            } else
            {
                MsgInvalidEntry();
                exit = false;
            }
        }
           
    }

} 


// ==============================================================================


// Color text in Prompt 
static void MsgColor(string msg, string color)
{
    //Console.WriteLine(fname + " is " + age);
    switch (color)
    {
        case "Yellow":
            Console.ForegroundColor = ConsoleColor.Yellow;
            break;
        case "Red":
            Console.ForegroundColor = ConsoleColor.Red;
            break;
        case "Green":
            Console.ForegroundColor = ConsoleColor.Green;
            break;
        case "Blue":
            Console.ForegroundColor = ConsoleColor.Blue;
            break;
    }
    Console.WriteLine(msg); 
    Console.ResetColor();
}

//  Show error message 
static void MsgInvalidEntry()
{
    MsgColor("Invalid Entry! Please try again: ", "Red");
}
    

// Print sorted List of products by Price
static void PrintList(double sum, List<Product> list_Product)
{
    // Sort List by Price 
    List<Product> sortedByPrice = list_Product.OrderBy(list_Product => list_Product.Price).ToList();

    // Print lists with Sum of Prices
    Console.WriteLine("");
    Console.WriteLine("Sorted by Price");
    Console.WriteLine("===============");
    MsgColor("Category".PadRight(10) + "Product".PadRight(10) + " Price", "Blue");

    foreach (Product i in sortedByPrice)
    {
        Console.WriteLine(i.Cat.PadRight(10) + i.Name.PadRight(10) + " " + i.Price);
    }

    // Calculate Sum of Price by Category
    sum = list_Product.Sum(list_Product => list_Product.Price);  //Sum of Price

    Console.WriteLine("");
    Console.WriteLine("Total Amout :".PadRight(21) + sum);
}
