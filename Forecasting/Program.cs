using System;

class FinancialForecast
{
    // Recursive method to calculate future value
    public static double CalculateFutureValue(double initialAmount, double growthRate, int years)
    {
        // Base case: 0 years means no growth
        if (years == 0)
            return initialAmount;

        // Recursive case
        return (1 + growthRate) * CalculateFutureValue(initialAmount, growthRate, years - 1);
    }

    // Optimized version with memoization
    public static double CalculateFutureValueMemo(double initialAmount, double growthRate, int years, double[] memo)
    {
        if (years == 0)
            return initialAmount;

        if (memo[years] != 0)
            return memo[years];

        memo[years] = (1 + growthRate) * CalculateFutureValueMemo(initialAmount, growthRate, years - 1, memo);
        return memo[years];
    }

    static void Main()
    {
        Console.WriteLine("--- Financial Forecasting Tool ---");
        Console.Write("Enter initial investment amount: ");
        double initial = double.Parse(Console.ReadLine()!);

        Console.Write("Enter annual growth rate (e.g., 0.05 for 5%): ");
        double rate = double.Parse(Console.ReadLine()!);

        Console.Write("Enter number of years: ");
        int years = int.Parse(Console.ReadLine()!);

        double futureValue = CalculateFutureValue(initial, rate, years);
        Console.WriteLine($"\nFuture Value (Recursive): {futureValue:F2}");

        double[] memo = new double[years + 1];
        double futureValueMemo = CalculateFutureValueMemo(initial, rate, years, memo);
        Console.WriteLine($"Future Value (Memoized): {futureValueMemo:F2}");
    }
}

