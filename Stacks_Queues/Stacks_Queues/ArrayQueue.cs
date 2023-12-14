public class ArrayQueue<T>
{
    private readonly T[] array;
    private int front;
    private int rear;
    private readonly int capacity;
    public ArrayQueue(int capacity)
    {
        this.capacity = capacity;
        this.array = new T[capacity];
        this.front = this.rear = -1;
    }

    public void Enqueue(T item)
    {
        if ((rear + 1) % capacity == front)
        {
            Console.WriteLine("Queue is full. Cannot enqueue.");
            return;
        }

        if (front == -1)
        {
            front = 0;
        }

        rear = (rear + 1) % capacity;
        array[rear] = item;

        Console.WriteLine($"{item} enqueued to the queue");
    }

    public T Dequeue()
    {
        if (front == -1)
        {
            Console.WriteLine("Queue is empty. Cannot dequeue.");
            return default(T);
        }

        T itemToRemove = array[front];

        if (front == rear)
        {
            front = rear = -1;
        }
        else
        {
            front = (front + 1) % capacity;
        }

        Console.WriteLine($"{itemToRemove} dequeued from the queue");
        return itemToRemove;
    }

    public T Peek()
    {
        if (front == -1)
        {
            Console.WriteLine("Queue is empty. Cannot peek.");
            return default(T);
        }

        return array[front];
    }

    public bool IsEmpty()
    {
        return front == -1;
    }

    public bool IsFull()
    {
        return (rear + 1) % capacity == front;
    }
}
