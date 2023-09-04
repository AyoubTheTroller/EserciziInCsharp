class Exercise8{

    public void convertCurrency(){
        Console.WriteLine("Welcome to the Currency Converter!");

        Console.WriteLine("Enter the amount you'd like to convert:");
        string? amountStr = Console.ReadLine();
        decimal amount;
        if (!decimal.TryParse(amountStr, out amount))
        {
            Console.WriteLine("Invalid amount entered.");
            return;
        }

        START1:
        Console.WriteLine("Enter the source currency (USD, EUR, GBP):");
        string? sourceCurrency = Console.ReadLine()?.ToUpper();

        Console.WriteLine("Enter the target currency (USD, EUR, GBP):");
        string? targetCurrency = Console.ReadLine()?.ToUpper();

        if (string.IsNullOrEmpty(sourceCurrency) || string.IsNullOrEmpty(targetCurrency))
        {
            Console.WriteLine("Invalid input for source or target currency. \nEnter again currencies:");
            goto START1;
        }

        // Conversion rates using dictionaries to make it more efficent and less verbose
        Dictionary<string, decimal> conversionRates = new Dictionary<string, decimal>
        {
            {"USDtoEUR", 0.92M},
            {"USDtoGBP", 0.75M},
            {"EURtoUSD", 1.09M},
            {"EURtoGBP", 0.86M},
            {"GBPtoUSD", 1.27M},
            {"GBPtoEUR", 1.17M},
        };

        decimal convertedAmount = 0;

        string conversionKey = sourceCurrency + "to" + targetCurrency;

        if (conversionRates.ContainsKey(conversionKey))
        {
            convertedAmount = amount * conversionRates[conversionKey];
            Console.WriteLine($"Converted amount: {convertedAmount} {targetCurrency}");
        }
        else
        {
            Console.WriteLine("Invalid currency conversion selected.");
            goto START1;
        }
    }
}