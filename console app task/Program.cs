using System;

class Program
{
    static void Main(string[] args)
    { 
        DateTime orderDateTime;

        Console.WriteLine("Welcome!");
        Console.WriteLine("Please enter order date and time (format: dd.MM.yyyy HH:mm):");

        string input = Console.ReadLine();

        if (DateTime.TryParseExact(input, "dd.MM.yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out orderDateTime))
        {
            DateTime deliveryDateTime = GetDeliveryDateTime(orderDateTime);
            Console.WriteLine("Estimated delivery date and time: {0:dd.MM.yyyy HH:mm}", deliveryDateTime);
        }
        else
        {
            Console.WriteLine("Invalid input format.");
        }

        Console.ReadKey();

    }

    static DateTime GetDeliveryDateTime(DateTime orderDateTime)
    {
        if (orderDateTime.DayOfWeek != DayOfWeek.Saturday &&
            orderDateTime.DayOfWeek != DayOfWeek.Sunday &&
            orderDateTime.Hour >= 8 && orderDateTime.Hour < 17)
        {
            return orderDateTime.AddHours(48);
        }
        else
        {
            DateTime nextWorkingDay = orderDateTime.AddDays(1);
            while (nextWorkingDay.DayOfWeek == DayOfWeek.Saturday || nextWorkingDay.DayOfWeek == DayOfWeek.Sunday)
            {
                nextWorkingDay = nextWorkingDay.AddDays(1);
            }
            return nextWorkingDay.AddHours(8 - nextWorkingDay.Hour).AddHours(48);
        }
    }
}