using CarClassLibrary;
using System;

namespace CarShopConsoleApp
{
    class Program
    {
        static Store CarStore = new Store();
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Welcome to the car store. First you must create some cars and put them into the store inventory. Then you may add cars to the cart. Finally you may checkout,which" +
                "will calcuate your total bill");
            int action = chooseAction();
            while(action != 0)
            {
               switch(action)
                {
                    case 1:
                        Console.Out.WriteLine("You Chose to add a new car to the Store");
                        string carMake = "";
                        string carModel = "";
                        decimal carPrice = 0;
                        int carYear = 0;
                        int carMilage = 0;
                        try
                        {
                            Console.Out.Write("What is the car Make?");
                            carMake = Console.ReadLine();
                            Console.Out.Write("What is the car Model?");
                            carModel = Console.ReadLine();
                            Console.Out.Write("What is the car Price? Numbers only please");
                            carPrice = int.Parse(Console.ReadLine());
                            Console.Out.Write("What is the car Milage? Numbers only please");
                            carMilage = int.Parse(Console.ReadLine());
                            Console.Out.Write("What is the car Year? Numbers only please");
                            carYear = int.Parse(Console.ReadLine());
                            Car newCar = new Car();
                            newCar.Make = carMake;
                            newCar.Model = carModel;
                            newCar.Price = carPrice;
                            newCar.Miles = carMilage;
                            newCar.Year = carYear;
                            CarStore.CarList.Add(newCar);
                            printStoreInventory(CarStore);
                        }
                        catch(Exception e)
                        {
                            Console.Out.WriteLine("Invalid input");
                        }
                        break;
                    case 2:
                        printStoreInventory(CarStore);

                        int choice = 0;
                        Console.Out.Write("Which Car would you like to add to the cart? (number)");
                        try
                        {
                            choice = int.Parse(Console.ReadLine());
                        }
                        catch(Exception e)
                        { 
                        }
                        CarStore.ShoppingList.Add(CarStore.CarList[choice]);

                        printShoppingCart(CarStore);


                        break;
                    case 3:
                        printShoppingCart(CarStore);
                        Console.Out.WriteLine("Your total cost is ${0}", CarStore.checkout());


                        break;

                    default:
                        break;
                }
                action = chooseAction();
            }
           
        }
        static public int chooseAction()
        {
            int choice = 0;
            Console.Out.Write("Choose an action (0) quit (1) add a car (2) add item to cart (3) checkout ");
                choice = int.Parse(Console.ReadLine());
 
            return choice;
        }

        static public void printStoreInventory(Store carStore)
        {
            Console.Out.WriteLine("These are the cars in store inventory");
            int i = 0;
            foreach(var c in carStore.CarList)
            {
                Console.WriteLine(string.Format("Car # = {0} {1} ", i, c.Display));
                i++;
            }
        }

        static public void printShoppingCart(Store carStore)
        {
            Console.Out.WriteLine("These are the cars in your shopping cart:");
            int i = 0;

            foreach (var c in carStore.ShoppingList)
            {
                Console.WriteLine(string.Format("Car # = {0} {1} ", i, c.Display));
                i++;
            }

        }
    }
}
