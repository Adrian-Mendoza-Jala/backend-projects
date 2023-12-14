class Program_Queues
{
    static void Main()
    {
        OrderProcessingSystem orderSystem = new OrderProcessingSystem();
        orderSystem.PlaceOrder("Double Cheese Burger x2");
        orderSystem.PlaceOrder("Hotdog x3");
        orderSystem.PlaceOrder("Pizza King Size x1");
        orderSystem.ProcessOrders();
    }
}
