namespace RoomReservationSystem.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return $"Reservation {ReservationId}: Customer {CustomerId}, Room {RoomId}, {StartDate:yyyy-MM-dd} - {EndDate:yyyy-MM-dd}";
        }
    }
}
