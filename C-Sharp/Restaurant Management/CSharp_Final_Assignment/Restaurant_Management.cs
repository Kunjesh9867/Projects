namespace CSharp_Final_Assignment;

public class RestaurantManagement

{

    public static void Intro()
    {
        Console.WriteLine("--------------|");
        Console.WriteLine("1-->CUSTOMER  |");
        Console.WriteLine("2-->ADMIN     |");
        Console.WriteLine("3-->Exit      |");
        Console.WriteLine("--------------|");
        
    }

    public static void AdminMainMenu()
    {
        Console.WriteLine();
        Console.WriteLine("\t\t\t\tMAIN MENU");
        Console.WriteLine("\t\t\t\t1.  Adding Employee Records");
        Console.WriteLine("\t\t\t\t2.  For Displaying Records of All the Employees");
        Console.WriteLine("\t\t\t\t3.  For Displaying Records of a Particular Employees");
        Console.WriteLine("\t\t\t\t4.  For Deleting Records Of All the Employee");
        Console.WriteLine("\t\t\t\t5.  For Deleting a Records of a Particular Employee");
        Console.WriteLine("\t\t\t\t0.  For Exit");
    }

    public static void RestaurantIntro()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.Write("-");

        }

        Console.WriteLine();
        Console.WriteLine("\t\t\tWELCOME to PHOENIX Restaurant");
        Console.WriteLine("\t\t\tGood Food and Good Vibes");
        Console.WriteLine("\t\t\tSatisfy your Snack Attack");
        Console.WriteLine("\t\t\tNOTE--->>Please  Order Everything, So not to Squander your Time");
        Console.WriteLine("\t\t\tWE HAVE VARIETIES AS FOLLOWS");
        for (int i = 0; i < 100; i++)
        {
            Console.Write("-");

        }
    }


    public static void Main(string[] args)
    {
        string[] EmployeeId = new string[1000];
        string[] EmployeeName = new string[1000];
        string[] EmployeePost = new string[1000];
        string[] EmployeeSalary = new string[1000];

        string[] CustomerItemsName = new string[1000];
        string[] CustomerItemsPrice = new string[1000];
        int CustomerItemsIndex = 0;
        int index = 0;
        int AdminRequest = 55;
        
        while (true)
        {
            Intro();
            Console.Write("Enter your value here: ");
            String inputValue = Console.ReadLine();
            int input = Int32.Parse(inputValue);
            string password = "Kunjesh";


            if (input.Equals(2))
            {
                Console.Write("Enter the Password: ");
                string pass = Console.ReadLine();
                if (pass.Equals(password))
                {
                    
                    while (AdminRequest != 0)
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            Console.Write("-");

                        }

                        AdminMainMenu();
                        Console.Write("Enter your input here: ");
                        AdminRequest = Int32.Parse(Console.ReadLine());
                        if (AdminRequest == 1)
                        {

                            Console.Write("Enter the ID: ");
                            string id = Console.ReadLine();
                            // Console.WriteLine();
                            Console.Write("Enter the Name: ");
                            string name = Console.ReadLine();
                            // Console.WriteLine();
                            Console.Write("Enter the Post: ");
                            string post = Console.ReadLine();
                            // Console.WriteLine();
                            Console.Write("Enter the Salary: ");
                            string salary = Console.ReadLine();
                            // Console.WriteLine();
                            EmployeeId[index] = id;
                            EmployeeName[index] = name;
                            EmployeePost[index] = post;
                            EmployeeSalary[index] = salary;
                            index++;
                        }
                        else if (AdminRequest == 2)
                        {

                            for (int i = 0; i < index; i++)
                            {
                                Console.Write(EmployeeId[i] + " " + EmployeeName[i] + " " + EmployeePost[i] + " " +
                                              EmployeeSalary[i]);
                                Console.WriteLine();

                            }
                        }
                        else if (AdminRequest == 3)
                        {
                            Console.WriteLine("Enter the ID of the Employee here: ");
                            int id = Int32.Parse(Console.ReadLine());
                            int i;
                           if(Array.Exists( EmployeeId, element => element == id.ToString() )){
                               i = id - 1;
                               Console.WriteLine("ID => "+EmployeeId[i]);
                               Console.WriteLine("Name => " + EmployeeName[i]);
                               Console.WriteLine("Post => "+EmployeePost[i]);
                               Console.WriteLine("Salary => "+EmployeeSalary[i]);
                           }
                        } 

                        else if (AdminRequest == 4)
                        {
                            for (int i = 0; i < EmployeeId.Length; i++)
                            {

                                EmployeeId[i] = " ";
                                EmployeeName[i] = " ";
                                EmployeePost[i] = " ";
                                EmployeeSalary[i] = " ";


                            }
                            
                            
                        }
                        
                        else if (AdminRequest == 5)
                        {
                            Console.WriteLine("Enter the ID of the Employee here: ");
                            int id = Int32.Parse(Console.ReadLine());
                            int i;
                            if(Array.Exists( EmployeeId, element => element == id.ToString() ))
                            {
                                EmployeeId[id - 1] = " ";
                                EmployeeName[id - 1] = " ";
                                EmployeePost[id - 1] = " ";
                                EmployeeSalary[id - 1] = " ";
                            }
                            
                            
                        }
                        
                        
                        
                    }




                }
                else
                {
                    Console.WriteLine("Incorrect Password!!!");
                    continue;
                }

            }

            else if (input == 1)
            {
                string[] items = new string[1000];
                RestaurantIntro();

                Console.WriteLine();
                Console.WriteLine("MENU");
                // int Runner = 100;
                int LoopRunner = 100;
                // while (true)
                // {
                while (LoopRunner != 0)
                {
                    for (int i = 0; i < 40; i++)
                    {
                        Console.Write("-");

                    }
                    Console.WriteLine();
                    Console.WriteLine("1==> SOUPS");
                    Console.WriteLine("2==> INDIAN FOOD:");
                    Console.WriteLine("3==> CONTINENTAL FOOD:");
                    Console.WriteLine("4==> DESSERTS:");
                    Console.WriteLine("0==> Exit:");
                    for (int i = 0; i < 40; i++)
                    {
                        Console.Write("-");

                    }
                    Console.WriteLine();
                    Console.Write("Enter your Choice: ");
                    LoopRunner = Int32.Parse(Console.ReadLine());
                    if (LoopRunner == 1)
                    {
                        for (int i = 0; i < 40; i++)
                        {
                            Console.Write("-");

                        }
                        Console.WriteLine();
                        Console.WriteLine("1 = Minestrone Soup($20)");
                        Console.WriteLine("2 = Hot & Sour Soup($30)");
                        Console.WriteLine("3 = Tomato Soup($25)");
                        Console.WriteLine("4 = Chicken Noodle Soup($35)");
                        Console.WriteLine("5 = Chilli ($30)");
                        for (int i = 0; i < 40; i++)
                        {
                            Console.Write("-");

                        }
                        Console.WriteLine();
                        Console.Write("Enter your Choice: ");
                        int soup = Int32.Parse(Console.ReadLine());
                        if (soup == 1)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Minestrone Soup";
                            CustomerItemsPrice[CustomerItemsIndex] = "20";
                        }
                        else if (soup == 2)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Hot & Sour Soup";
                            CustomerItemsPrice[CustomerItemsIndex] = "30";
                        }
                        else if (soup == 3)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Tomato Soup";
                            CustomerItemsPrice[CustomerItemsIndex] = "25";
                        }
                        else if (soup == 4)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Chicken Noodle Soup";
                            CustomerItemsPrice[CustomerItemsIndex] = "35";
                        }
                        else if (soup == 5)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Chilli Soup";
                            CustomerItemsPrice[CustomerItemsIndex] = "30";
                        }

                        CustomerItemsIndex++;
                    }

                    else if (LoopRunner == 2)
                    {
                        for (int i = 0; i < 40; i++)
                        {
                            Console.Write("-");

                        }
                        Console.WriteLine();
                        Console.WriteLine("1 = Masala Dosa($50)");
                        Console.WriteLine("2 = Dal makhani($100)");
                        Console.WriteLine("3 = Dhokla($25)");
                        Console.WriteLine("4 = Pani puri($15)");
                        Console.WriteLine("5 = Patra ($40)");
                        for (int i = 0; i < 40; i++)
                        {
                            Console.Write("-");

                        }
                        Console.WriteLine();
                        Console.Write("Enter your Choice: ");
                        int indianFood = Int32.Parse(Console.ReadLine());
                        if (indianFood == 1)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Masala Dosa";
                            CustomerItemsPrice[CustomerItemsIndex] = "50";
                        }
                        else if (indianFood == 2)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Dal makhani";
                            CustomerItemsPrice[CustomerItemsIndex] = "100";
                        }
                        else if (indianFood == 3)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Dhokla";
                            CustomerItemsPrice[CustomerItemsIndex] = "25";
                        }
                        else if (indianFood == 4)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Pani puri";
                            CustomerItemsPrice[CustomerItemsIndex] = "15";
                        }
                        else if (indianFood == 5)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Patra";
                            CustomerItemsPrice[CustomerItemsIndex] = "40";
                        }

                        CustomerItemsIndex++;
                    }


                    else if (LoopRunner == 3)
                    {
                        for (int i = 0; i < 40; i++)
                        {
                            Console.Write("-");

                        }
                        Console.WriteLine();
                        Console.WriteLine("1 = French Toast($10)");
                        Console.WriteLine("2 = Chicken Sandwich($50)");
                        Console.WriteLine("3 = Pancakes($25)");
                        Console.WriteLine("4 = Caesar Salad($40)");
                        Console.WriteLine("5 = French Fries ($20)");
                        for (int i = 0; i < 40; i++)
                        {
                            Console.Write("-");

                        }
                        Console.WriteLine();
                        Console.Write("Enter your Choice: ");
                        int continentalFood = Int32.Parse(Console.ReadLine());
                        if (continentalFood == 1)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "French Toast";
                            CustomerItemsPrice[CustomerItemsIndex] = "10";
                        }
                        else if (continentalFood == 2)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Chicken Sandwich";
                            CustomerItemsPrice[CustomerItemsIndex] = "50";
                        }
                        else if (continentalFood == 3)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Pancakes";
                            CustomerItemsPrice[CustomerItemsIndex] = "25";
                        }
                        else if (continentalFood == 4)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Caesar Salad";
                            CustomerItemsPrice[CustomerItemsIndex] = "40";
                        }
                        else if (continentalFood == 5)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "French Fries";
                            CustomerItemsPrice[CustomerItemsIndex] = "20";
                        }

                        CustomerItemsIndex++;
                    }

                    else if (LoopRunner == 4)
                    {
                        for (int i = 0; i < 40; i++)
                        {
                            Console.Write("-");

                        }
                        Console.WriteLine();
                        Console.WriteLine("1 = Black Forest Cake($30)");
                        Console.WriteLine("2 = Chocolate Chunk Cookie($5)");
                        Console.WriteLine("3 = Mango MilkShake($15)");
                        Console.WriteLine("4 = Strawberry Candies($10)");
                        Console.WriteLine("5 = Pineapple Cheesecake($20)");
                        for (int i = 0; i < 40; i++)
                        {
                            Console.Write("-");

                        }
                        Console.WriteLine();
                        Console.Write("Enter your Choice: ");
                        int dessert = Int32.Parse(Console.ReadLine());
                        if (dessert == 1)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Black Forest Cake";
                            CustomerItemsPrice[CustomerItemsIndex] = "30";
                        }
                        else if (dessert == 2)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Chocolate Chunk Cookie";
                            CustomerItemsPrice[CustomerItemsIndex] = "5";
                        }
                        else if (dessert == 3)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Mango MilkShake";
                            CustomerItemsPrice[CustomerItemsIndex] = "15";
                        }
                        else if (dessert == 4)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Strawberry Candies";
                            CustomerItemsPrice[CustomerItemsIndex] = "10";
                        }
                        else if (dessert == 5)
                        {
                            CustomerItemsName[CustomerItemsIndex] = "Pineapple Cheesecake";
                            CustomerItemsPrice[CustomerItemsIndex] = "20";
                        }

                        CustomerItemsIndex++;
                    }
                    // else if (LoopRunner == 0)
                    // {
                    //     Runner = 55;
                    // }
                }
                for (int i = 0; i < 40; i++)
                {
                    Console.Write("-");

                }
                Console.WriteLine();
                Console.WriteLine("Your Items Contains:");
                int total = 0;
                for (int i = 0; i < CustomerItemsIndex; i++)
                {
                    Console.WriteLine(CustomerItemsName[i] + " => $"+CustomerItemsPrice[i]);
                    total += Int32.Parse(CustomerItemsPrice[i]);
                }
                for (int i = 0; i < 40; i++)
                {
                    Console.Write("-");

                }
                Console.WriteLine();

                Console.WriteLine("Your Total is: $" + total);

            }
            else
            {
                break;
            }

        }


    }
}





















// public static void AdminFunction()
    // {
    //     // string[][][][] Employee;
    //     for (int i = 0; i < 100; i++)
    //     {
    //         Console.Write("-");
    //         
    //     }
    //     Console.WriteLine();
    //     Console.WriteLine("\t\t\t\tMAIN MENU");
    //     Console.WriteLine("\t\t\t\t1.  Adding Employee Records");
    //     Console.WriteLine("\t\t\t\t2.  Adding Items in Main Menu");
    //     Console.WriteLine("\t\t\t\t3.  For Displaying Records of All the Employees");
    //     Console.WriteLine("\t\t\t\t4.  For Displaying Records of a Particular Employees");
    //     Console.WriteLine("\t\t\t\t5.  For Displaying All Records of MAIN MENU");
    //     Console.WriteLine("\t\t\t\t6.  For Deleting Records Of All the Employee");
    //     Console.WriteLine("\t\t\t\t7.  For Deleting a Records of a Particular Employee");
    //     Console.WriteLine("\t\t\t\t8.  For Modifying Employee Record");
    //     Console.WriteLine("\t\t\t\t0.  For Exit");
    //     Console.Write("Enter your input here: ");
    //     int AdminRequest = Int32.Parse(Console.ReadLine());
    //     if (AdminRequest == 1)
    //     {
    //         AddingEmployee();
    //     }
    //     else if (AdminRequest == 3)
    //     {
    //         DisplayEmployee();
    //     }
    //
    // }
    //
    // public static void DisplayEmployee()
    // {
    //     Console.Write("ID\t Name\t Post\t Salary");
    //     Console.WriteLine();
    //     for (int i = 0; i < index; i++)
    //     {
    //         Console.Write(EmployeeId[i]+"\t "+EmployeeName[i]+"\t "+EmployeePost[i]+"\t "+EmployeeSalary[i]);
    //         Console.WriteLine();
    //         
    //     }
    //     
    // }
    //
    // public static void AddingEmployee()
    // {
    //     
    //     
    //     
    //     int index = 0;
    //     Console.Write("Enter the ID: ");
    //     string id = Console.ReadLine();
    //     // Console.WriteLine();
    //     Console.Write("Enter the Name: ");
    //     string name = Console.ReadLine();
    //     // Console.WriteLine();
    //     Console.Write("Enter the Post: ");
    //     string post = Console.ReadLine();
    //     // Console.WriteLine();
    //     Console.Write("Enter the Salary: ");
    //     string salary = Console.ReadLine();
    //     // Console.WriteLine();
    //     EmployeeId[index] = id;
    //     EmployeeName[index] = name;
    //     EmployeePost[index] = post;
    //     EmployeeSalary[index] = salary;
    //     index++;
    //     
    //
    // }