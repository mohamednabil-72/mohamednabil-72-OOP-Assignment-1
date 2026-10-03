namespace Src;

public class OrderSystem
{
    const int MAX_CUSTOMERS = 50;
    const int MAX_PRODUCTS = 50;
    const int MAX_ORDERS = 100;
    const int MAX_LINES_PER_ORDER = 20;

    int customerCount = 0;
    Customer[] customers = new Customer[MAX_CUSTOMERS];

    int productCount = 0;
    Product[] products = new Product[MAX_PRODUCTS];

    int orderCount = 0;
    Order[] orders = new Order[MAX_ORDERS];


    int findCustomerIndexById(int id)
    {
        for (int i = 0; i < customerCount; i++)
        {
            if (customers[i].Id == id)
                return i;
        }

        return -1;
    }


    int findProductIndexById(int id)
    {
        for (int i = 0; i < productCount; i++)
        {
            if (products[i].Id == id)
                return i;
        }

        return -1;
    }


    int findOrderIndexById(int id)
    {
        for (int i = 0; i < orderCount; i++)
        {
            if (orders[i].Id == id)
                return i;
        }

        return -1;
    }


    public void addCustomer(int id, string name, string email, string city, bool isVip)
    {
        if (customerCount >= MAX_CUSTOMERS)
        {
            Console.WriteLine("ERROR: customer list is full.");
            return;
        }

        if (findCustomerIndexById(id) != -1)
        {
            Console.WriteLine($"ERROR: customer id {id} already exists.");
            return;
        }

        customers[customerCount] = new Customer(id, name, email, city, isVip);
        customerCount++;
    }


    public void printCustomers()
    {
        Console.WriteLine($"\n=== CUSTOMERS ({customerCount}) ===");

        for (int i = 0; i < customerCount; i++)
        {
            Console.WriteLine($"#{customers[i].Id}  {customers[i].Name}  <{customers[i].Email}>  {customers[i].City}  vip={(customers[i].IsVip ? "yes" : "no")}");
        }
    }


    public void addProduct(int id, string name, double price, int stock)
    {
        if (productCount >= MAX_PRODUCTS)
        {
            Console.WriteLine("ERROR: product list is full.");
            return;
        }

        if (findProductIndexById(id) != -1)
        {
            Console.WriteLine($"ERROR: product id {id} already exists.");
            return;
        }

        products[productCount] = new Product(id, name, price, stock);
        productCount++;
    }


    public void printProducts()
    {
        Console.WriteLine($"\n=== PRODUCTS ({productCount}) ===");

        for (int i = 0; i < productCount; i++)
        {
            Console.WriteLine($"#{products[i].Id}  {products[i].Name}  price={products[i].Price:F2}  stock={products[i].Stock}");
        }
    }


    public int createOrder(int orderId, int customerId, string date)
    {
        if (orderCount >= MAX_ORDERS)
        {
            Console.WriteLine("ERROR: order list is full.");
            return -1;
        }

        if (findOrderIndexById(orderId) != -1)
        {
            Console.WriteLine($"ERROR: order id {orderId} already exists.");
            return -1;
        }

        int customerIndex = findCustomerIndexById(customerId);

        if (customerIndex == -1)
        {
            Console.WriteLine($"ERROR: customer id {customerId} not found.");
            return -1;
        }

        orders[orderCount] = new Order(orderId, customers[customerIndex], date);
        orderCount++;

        return orderCount - 1;
    }


    public void addLineToOrder(int orderId, int productId, int quantity)
    {
        int orderIndex = findOrderIndexById(orderId);

        if (orderIndex == -1)
        {
            Console.WriteLine($"ERROR: order id {orderId} not found.");
            return;
        }

        if (orders[orderIndex].IsPaid)
        {
            Console.WriteLine("ERROR: cannot change a paid order.");
            return;
        }

        if (orders[orderIndex].OrderLines.Count >= MAX_LINES_PER_ORDER)
        {
            Console.WriteLine("ERROR: order has too many lines.");
            return;
        }

        int productIndex = findProductIndexById(productId);

        if (productIndex == -1)
        {
            Console.WriteLine($"ERROR: product id {productId} not found.");
            return;
        }

        if (quantity <= 0)
        {
            Console.WriteLine("ERROR: quantity must be positive.");
            return;
        }

        if (products[productIndex].Stock < quantity)
        {
            Console.WriteLine($"ERROR: not enough stock for product #{productId}.");
            return;
        }

        products[productIndex].Stock -= quantity;

        orders[orderIndex].OrderLines.Add(new OrderLine(products[productIndex], quantity));
    }


    public double calculateOrderTotal(int orderIndex)
    {
        double total = 0.0;

        for (int i = 0; i < orders[orderIndex].OrderLines.Count; i++)
        {
            OrderLine line = orders[orderIndex].OrderLines[i];

            total += line.Product.Price * line.Quantity;
        }

        if (orders[orderIndex].Customer.IsVip)
            total = total * 0.90;

        return total;
    }


    public void markOrderPaid(int orderId)
    {
        int orderIndex = findOrderIndexById(orderId);

        if (orderIndex == -1)
        {
            Console.WriteLine($"ERROR: order id {orderId} not found.");
            return;
        }

        if (orders[orderIndex].OrderLines.Count == 0)
        {
            Console.WriteLine("ERROR: cannot pay an empty order.");
            return;
        }

        orders[orderIndex].IsPaid = true;
    }


    public void printOrder(int orderId)
    {
        int orderIndex = findOrderIndexById(orderId);

        if (orderIndex == -1)
        {
            Console.WriteLine($"ERROR: order id {orderId} not found.");
            return;
        }

        Console.WriteLine($"\n=== ORDER #{orders[orderIndex].Id} ===");
        Console.WriteLine($"Date: {orders[orderIndex].Date}");
        Console.WriteLine($"Customer: {orders[orderIndex].Customer.Name} (#{orders[orderIndex].Customer.Id})");
        Console.WriteLine($"Paid: {(orders[orderIndex].IsPaid ? "yes" : "no")}");
        Console.WriteLine("Lines:");

        for (int i = 0; i < orders[orderIndex].OrderLines.Count; i++)
        {
            OrderLine line = orders[orderIndex].OrderLines[i];
            double lineTotal = line.Product.Price * line.Quantity;

            Console.WriteLine($"  - {line.Product.Name}  x{line.Quantity}  @{line.Product.Price:F2}  = {lineTotal:F2}");
        }

        Console.WriteLine($"TOTAL: {calculateOrderTotal(orderIndex):F2}");
    }


    public void printAllOrders()
    {
        Console.WriteLine($"\n=== ALL ORDERS ({orderCount}) ===");

        for (int i = 0; i < orderCount; i++)
            printOrder(orders[i].Id);
    }


    public double totalSalesPaidOnly()
    {
        double sum = 0.0;

        for (int i = 0; i < orderCount; i++)
        {
            if (orders[i].IsPaid)
                sum += calculateOrderTotal(i);
        }

        return sum;
    }


    public void seedSampleData()
    {
        addCustomer(1, "Mona Ali", "mona@example.com", "Cairo", true);
        addCustomer(2, "Omar Hassan", "omar@example.com", "Alexandria", false);
        addCustomer(3, "Sara Nabil", "sara@example.com", "Giza", false);

        addProduct(101, "USB Cable", 50.0, 100);
        addProduct(102, "Wireless Mouse", 250.0, 40);
        addProduct(103, "Mechanical Keyboard", 1200.0, 15);
        addProduct(104, "Laptop Stand", 400.0, 25);
    }


    public void runDemoScenario()
    {
        createOrder(1001, 1, "2026-09-15");
        addLineToOrder(1001, 101, 2);
        addLineToOrder(1001, 102, 1);
        markOrderPaid(1001);

        createOrder(1002, 2, "2026-09-15");
        addLineToOrder(1002, 103, 1);
        addLineToOrder(1002, 104, 1);

        createOrder(1003, 3, "2026-09-16");
        addLineToOrder(1003, 101, 5);
        markOrderPaid(1003);
    }
}