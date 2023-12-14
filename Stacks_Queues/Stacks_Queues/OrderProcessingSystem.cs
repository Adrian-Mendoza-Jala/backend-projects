class OrderProcessingSystem
{

    private readonly Queue<string> orderQueue;
    public OrderProcessingSystem()
    {
        orderQueue = new Queue<string>();
    }

    public void PlaceOrder(string order)
    {
        orderQueue.Enqueue(order);
        Console.WriteLine($"Order placed: {order}");
    }

    public void ProcessOrders()
    {
        while (orderQueue.Count > 0)
        {
            string currentOrder = orderQueue.Dequeue();
            Console.WriteLine($"Processing Order: {currentOrder}");
        }
        if (orderQueue.Count == 0)
        {
            Console.WriteLine("All orders processed.");
        }
    }
}