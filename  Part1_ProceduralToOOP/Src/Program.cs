namespace Src;

public class Program
{
    static void printMenu()
    {
        Console.WriteLine("\n---------- MENU ----------");
        Console.WriteLine("1) Print customers");
        Console.WriteLine("2) Print products");
        Console.WriteLine("3) Print all orders");
        Console.WriteLine("4) Print one order by id");
        Console.WriteLine("5) Create order");
        Console.WriteLine("6) Add line to order");
        Console.WriteLine("7) Mark order paid");
        Console.WriteLine("8) Show paid sales total");
        Console.WriteLine("0) Exit");
        Console.Write("Choice: ");
    }


    static void runInteractiveMenu(OrderSystem system)
    {
        int choice = -1;

        while (choice != 0)
        {
            printMenu();
            choice = int.Parse(Console.ReadLine()!);

            if (choice == 1)
            {
                system.printCustomers();
            }
            else if (choice == 2)
            {
                system.printProducts();
            }
            else if (choice == 3)
            {
                system.printAllOrders();
            }
            else if (choice == 4)
            {
                int orderId;
                Console.Write("Order id: ");
                orderId = int.Parse(Console.ReadLine()!);

                system.printOrder(orderId);
            }
            else if (choice == 5)
            {
                int orderId, customerId;
                string date;

                Console.Write("Order id: ");
                orderId = int.Parse(Console.ReadLine()!);

                Console.Write("Customer id: ");
                customerId = int.Parse(Console.ReadLine()!);

                Console.Write("Date (YYYY-MM-DD): ");
                date = Console.ReadLine()!;

                system.createOrder(orderId, customerId, date);
            }
            else if (choice == 6)
            {
                int orderId, productId, quantity;

                Console.Write("Order id: ");
                orderId = int.Parse(Console.ReadLine()!);

                Console.Write("Product id: ");
                productId = int.Parse(Console.ReadLine()!);

                Console.Write("Quantity: ");
                quantity = int.Parse(Console.ReadLine()!);

                system.addLineToOrder(orderId, productId, quantity);
            }
            else if (choice == 7)
            {
                int orderId;

                Console.Write("Order id: ");
                orderId = int.Parse(Console.ReadLine()!);

                system.markOrderPaid(orderId);
            }
            else if (choice == 8)
            {
                Console.WriteLine(
                    $"Paid sales total: {system.totalSalesPaidOnly():F2}");
            }
            else if (choice == 0)
            {
                Console.WriteLine("Bye.");
            }
            else
            {
                Console.WriteLine("Unknown choice.");
            }
        }
    }


    static void Main()
    {
        Console.WriteLine(
            "Procedural Order System (no classes / no structs)");

        Console.WriteLine(
            "Seed sample data, show a demo, then open the menu.");

        OrderSystem system = new OrderSystem();

        system.seedSampleData();
        system.runDemoScenario();

        system.printCustomers();
        system.printProducts();
        system.printAllOrders();

        Console.WriteLine(
            $"\nPaid sales total after demo: {system.totalSalesPaidOnly():F2}");

        runInteractiveMenu(system);
    }
}