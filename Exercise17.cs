using System;
using System.Collections.Generic;

class Exercise17
{
    private Dictionary<string, string> bookings;

    public Exercise17(){
        bookings = new Dictionary<string, string>();
    }

    public void manageBookings(){
        Console.WriteLine("Welcome to the super simple Booking System");
        RunMenu();
    }

    public void ShowMenu(){
        Console.WriteLine("Menu: ");
        Console.WriteLine("1 - Make a Booking");
        Console.WriteLine("2 - View Bookings");
    }

    public void RunMenu()
    {
        while (true)
        {   
            ShowMenu();
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        MakeBooking();
                        break;
                    case 2:
                        ViewBookings();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
            if (!wannaKeepGoing())
            {
                break;
            }
        }
    }

    public DateTime enterDate(string dateName)
    {
        DateTime date;
        while (true)
        {
            Console.WriteLine($"Please enter {dateName} (format: MM/dd/yyyy HH:mm):");
            string? userInput = Console.ReadLine();
            if (DateTime.TryParseExact(userInput, "MM/dd/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
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

    public void MakeBooking(){
        Console.WriteLine("Enter your name:");
        string? name;
        while(true){
            name = Console.ReadLine();
            if(!string.IsNullOrEmpty(name)){
                break;
            }
            else{
                Console.WriteLine("Wrong input, retry");
            }
        }
        DateTime startDate = enterDate("startDate");
        DateTime endDate = enterDate("endDate");
        if (!checkIfDateRangeAvailable(startDate, endDate))
        {
            Console.WriteLine("Sorry, the selected time slot is not available.");
            return;
        }
        else
        {
             bookings.Add(name, startDate.ToString("MM/dd/yyyy HH:mm") + " - " + endDate.ToString("MM/dd/yyyy HH:mm"));
            Console.WriteLine($"Successfully booked the slot from {startDate} to {endDate} for {name}.");
        }
    }

    public bool checkIfDateRangeAvailable(DateTime newStart, DateTime newEnd){
        foreach (var booking in bookings)
        {
            string[] dateRange = booking.Value.Split(" - ");
            DateTime existingStart = DateTime.ParseExact(dateRange[0], "MM/dd/yyyy HH:mm", null);
            DateTime existingEnd = DateTime.ParseExact(dateRange[1], "MM/dd/yyyy HH:mm", null);

            if ((newStart >= existingStart && newStart <= existingEnd) ||
                (newEnd >= existingStart && newEnd <= existingEnd) ||
                (newStart <= existingStart && newEnd >= existingEnd))
            {
                return false;
            }
        }

        return true;
    }

    public void ViewBookings()
    {
        Console.WriteLine("Current Bookings:");
        foreach (var booking in bookings)
        {
            Console.WriteLine($"Time Slot: {booking.Value}, Booked By: {booking.Key}");
        }
    }

    public static bool wannaKeepGoing(){
        Console.WriteLine("Do you want to keep managing your bookings? y or n");
        string? input = Console.ReadLine();
        return input == "y";
    }
}
