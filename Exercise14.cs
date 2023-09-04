class Exercise14{

    DateOnly date1;
    DateOnly date2;

    public Exercise14(){
        date1 = new DateOnly();
        date2 = new DateOnly();
    }
    public void calculateDates(){
        Console.WriteLine("Here will be calculated the range between two dates in years/months/days/");
        date1 = enterDate(1);
        date2 = enterDate(2);
        CalculateRange(date1, date2);
    }

    public DateOnly enterDate(int numDate)
    {
        DateOnly date;
        while (true)
        {
            Console.WriteLine($"Please enter date{numDate} (format: MM/dd/yyyy):");
            string? userInput = Console.ReadLine();
            if (DateOnly.TryParseExact(userInput, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly parsedDate))
            {
                Console.WriteLine($"You entered a valid date: {parsedDate.ToShortDateString()}");
                date = parsedDate;
                break;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please try again.");
            }
        }
        return date;
    }


    public void CalculateRange(DateOnly startDate, DateOnly endDate){
        if (startDate > endDate)
        {
            var temp = startDate;
            startDate = endDate;
            endDate = temp;
        }

        int years = endDate.Year - startDate.Year;
        int months = endDate.Month - startDate.Month;
        int days = endDate.Day - startDate.Day;
        
        if (days < 0)
        {
            months--;
            int previousMonth = (endDate.Month - 1 == 0) ? 12 : endDate.Month - 1;
            int year = (previousMonth == 12) ? endDate.Year - 1 : endDate.Year;
            days += DateTime.DaysInMonth(year, previousMonth);
        }

        if (months < 0)
        {
            years--;
            months += 12;
        }

        Console.WriteLine($"The range between dates is {years} years, {months} months, and {days} days.");
    }


}