namespace RoomReservationSystem.Utilities
{
    public class InputReader
    {
        public static int ReadInt(int min = int.MinValue, int max = int.MaxValue, string? prompt = null)
        {
            while (true)
            {
                if (!string.IsNullOrEmpty(prompt))
                {
                    Console.Write(prompt);
                }

                var input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && InputValidation.CheckInt(input, min, max))
                {
                    return int.Parse(input);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
