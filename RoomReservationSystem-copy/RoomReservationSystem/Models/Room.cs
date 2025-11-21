namespace RoomReservationSystem.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public bool PetsAllowed { get; set; }
    }
}
