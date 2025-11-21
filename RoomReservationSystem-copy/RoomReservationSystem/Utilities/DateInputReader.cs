using System.Globalization;

namespace RoomReservationSystem.Utilities
{
    public static class DateInputReader
    {
        public static DateTime ReadDate(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                var input = Console.ReadLine();


                //Allows only specific format for date yyyy-mm-dd
                if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }

                Console.WriteLine("Invalid date format. Use format YYYY-MM-DD.");
            }
        }

        public static (DateTime start, DateTime end) ReadDateRange()
        {
            while (true)
            {
                var start = ReadDate("Type start date YYYY-MM-DD");
                var end = ReadDate("Type end date YYYY-MM-DD");

                if (end <= start)
                {
                    Console.WriteLine("End date cannot be before start date, enter valid dates.");
                    continue;
                }

                return (start, end);

            }
        }

        public static bool TryValidateDateRange(DateTime start, DateTime end)
        {
            return end > start;
        }
    }
}
