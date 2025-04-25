using System;

// Main program class that serves as the entry point
class Program
{
    // Constants for validation
    private const double MaxWeight = 50;
    private const double MaxDimensions = 50;

    static void Main(string[] args)
    {
        // Display welcome message
        ShowWelcomeMessage();

        // Get and validate package weight
        double weight = GetPackageWeight();
        if (!ValidateWeight(weight))
            return;

        // Get and validate package dimensions
        var (width, height, length) = GetPackageDimensions();
        if (!ValidateDimensions(width, height, length))
            return;

        // Calculate and display shipping quote
        CalculateAndDisplayQuote(weight, width, height, length);
    }

    // Display welcome message
    static void ShowWelcomeMessage()
    {
        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");
    }

    // Get package weight from user
    static double GetPackageWeight()
    {
        while (true)
        {
            Console.WriteLine("Please enter the package weight:");
            if (double.TryParse(Console.ReadLine(), out double weight))
            {
                return weight;
            }
            Console.WriteLine("Invalid input. Please enter a numeric value.");
        }
    }

    // Validate package weight
    static bool ValidateWeight(double weight)
    {
        if (weight > MaxWeight)
        {
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return false;
        }
        return true;
    }

    // Get package dimensions from user
    static (double width, double height, double length) GetPackageDimensions()
    {
        double width = GetDimensionInput("width");
        double height = GetDimensionInput("height");
        double length = GetDimensionInput("length");
        return (width, height, length);
    }

    // Get single dimension input
    static double GetDimensionInput(string dimensionName)
    {
        while (true)
        {
            Console.WriteLine($"Please enter the package {dimensionName}:");
            if (double.TryParse(Console.ReadLine(), out double dimension))
            {
                return dimension;
            }
            Console.WriteLine("Invalid input. Please enter a numeric value.");
        }
    }

    // Validate package dimensions
    static bool ValidateDimensions(double width, double height, double length)
    {
        double totalDimensions = width + height + length;
        if (totalDimensions > MaxDimensions)
        {
            Console.WriteLine("Package too big to be shipped via Package Express.");
            return false;
        }
        return true;
    }

    // Calculate and display shipping quote
    static void CalculateAndDisplayQuote(double weight, double width, double height, double length)
    {
        double quote = (width * height * length * weight) / 100;
        Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");
        Console.WriteLine("Thank you!");
    }
}