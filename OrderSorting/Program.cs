using System;

namespace OrderSorting
{
    class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }

        public void Display()
        {
            Console.WriteLine($"Order ID: {OrderId}, Customer: {CustomerName}, Total: {TotalPrice:C}");
        }
    }

    class Program
    {
        static void BubbleSort(Order[] orders)
        {
            int n = orders.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                    {
                        // Swap
                        var temp = orders[j];
                        orders[j] = orders[j + 1];
                        orders[j + 1] = temp;
                    }
                }
            }
        }

        static void QuickSort(Order[] orders, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(orders, low, high);
                QuickSort(orders, low, pivotIndex - 1);
                QuickSort(orders, pivotIndex + 1, high);
            }
        }

        static int Partition(Order[] orders, int low, int high)
        {
            decimal pivot = orders[high].TotalPrice;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (orders[j].TotalPrice < pivot)
                {
                    i++;
                    var temp = orders[i];
                    orders[i] = orders[j];
                    orders[j] = temp;
                }
            }

            var swapTemp = orders[i + 1];
            orders[i + 1] = orders[high];
            orders[high] = swapTemp;

            return i + 1;
        }

        static void PrintOrders(string title, Order[] orders)
        {
            Console.WriteLine($"\n{title}");
            foreach (var order in orders)
            {
                order.Display();
            }
        }

        static void Main(string[] args)
        {
            Order[] orders = new Order[]
            {
                new Order { OrderId = 101, CustomerName = "Alice", TotalPrice = 300.00m },
                new Order { OrderId = 102, CustomerName = "Bob", TotalPrice = 150.50m },
                new Order { OrderId = 103, CustomerName = "Charlie", TotalPrice = 500.75m },
                new Order { OrderId = 104, CustomerName = "Diana", TotalPrice = 250.00m }
            };

            // Bubble Sort Example
            Order[] bubbleSorted = (Order[])orders.Clone();
            BubbleSort(bubbleSorted);
            PrintOrders("Bubble Sorted Orders (Low to High):", bubbleSorted);

            // Quick Sort Example
            Order[] quickSorted = (Order[])orders.Clone();
            QuickSort(quickSorted, 0, quickSorted.Length - 1);
            PrintOrders("Quick Sorted Orders (Low to High):", quickSorted);
        }
    }
}

