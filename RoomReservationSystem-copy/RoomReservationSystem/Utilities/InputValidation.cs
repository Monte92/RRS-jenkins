namespace RoomReservationSystem.Utilities
{
    public class InputValidation
    {
        public static bool CheckInt(string input, int min, int max)
        {
            if(int.TryParse(input, out int value))
            {
                if (value < min || value > max) { return false; }
                return true;
            } else { return false; }
        }
    }
}
