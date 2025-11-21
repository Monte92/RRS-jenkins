using Microsoft.Data.Sqlite;
using RoomReservationSystem.Models;
using System;

namespace RoomReservationSystem.Services
{
    public class ReservationService
    {
        // Get all reservations
        /* How to use - example
           var dbService = new DatabaseService();
           using (var connection = dbService.GetConnection())
           {
             var reservations = ReservationService.GetAllReservations(connection);
             foreach (var reservation in reservations)
             {
                Console.WriteLine(reservation);
             }
           }
        */
        public static List<Reservation> GetAllReservations(SqliteConnection connection)
        {
            List<Reservation> reservations = [];

            using (connection)
            {
                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = "SELECT reservation_id, customer_id, room_id, start_date, end_date FROM reservation;";

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    reservations.Add(new Reservation
                    {
                        ReservationId = reader.GetInt32(0),
                        CustomerId = reader.GetInt32(1),
                        RoomId = reader.GetInt32(2),
                        StartDate = reader.GetDateTime(3),
                        EndDate = reader.GetDateTime(4)
                    });
                }
            }

            return reservations;
        }


        //Get a reservation by ID
        /* How to use - example
            var dbService = new DatabaseService();
            using (var connection = dbService.GetConnection())
            {
                int reservationId = InputReader.ReadInt(1, int.MaxValue, "Enter reservation ID: ");

                var reservation = ReservationService.GetReservationById(connection, reservationId);

                if (reservation != null)
                {
                    Console.WriteLine(reservation);
                }
                else
                {
                    Console.WriteLine("Reservation not found.");
                }
            }

        */
        public static Reservation? GetReservationById(SqliteConnection connection, int reservationId)
        {
            using (connection)
            {
                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = "SELECT reservation_id, customer_id, room_id, start_date, end_date FROM reservation WHERE reservation_id = @id;";
                command.Parameters.AddWithValue("@id", reservationId);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Reservation
                    {
                        ReservationId = reader.GetInt32(0),
                        CustomerId = reader.GetInt32(1),
                        RoomId = reader.GetInt32(2),
                        StartDate = reader.GetDateTime(3),
                        EndDate = reader.GetDateTime(4)
                    };
                }

                return null;
            }
        }
        // Create a reservation
        /* How to use - example
            var dbService = new DatabaseService();
            using (var connection = dbService.GetConnection())
            {
                connection.Open();

                Console.WriteLine("Creating a new reservation...");

                var newReservation = new Reservation
                {
                    CustomerId = 2,
                    RoomId = 3,
                    StartDate = new DateTime(2025, 11, 15),
                    EndDate = new DateTime(2025, 11, 18)
                };

                try
                {
                    int newId = ReservationService.CreateReservation(connection, newReservation);
                    Console.WriteLine($"Reservation created with ID: {newId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating reservation: {ex.Message}");
                }
            }

        */
        public static int CreateReservation(SqliteConnection connection, Reservation reservation)
        {
            using var command = connection.CreateCommand();
            command.CommandText = """
                INSERT INTO reservation (customer_id, room_id, start_date, end_date)
                VALUES ($customer_id, $room_id, $start_date, $end_date);
                SELECT last_insert_rowid();
            """;

            command.Parameters.AddWithValue("$customer_id", reservation.CustomerId);
            command.Parameters.AddWithValue("$room_id", reservation.RoomId);
            command.Parameters.AddWithValue("$start_date", reservation.StartDate);
            command.Parameters.AddWithValue("$end_date", reservation.EndDate);

            var result = command.ExecuteScalar();
            return Convert.ToInt32(result);
        }


        /*
            var dbService = new DatabaseService();
            using (var connection = dbService.GetConnection())
            {
                connection.Open();

                Console.Write("Enter reservation ID to update: ");
                int id = InputReader.ReadInt(1, int.MaxValue, "Enter reservation ID: ");

                var reservation = ReservationService.GetReservationById(connection, id);
                if (reservation == null)
                {
                    Console.WriteLine("Reservation not found.");
                    return;
                }

                Console.WriteLine("Updating end date (+2 days)...");
                reservation.EndDate = reservation.EndDate.AddDays(2);

                bool success = ReservationService.UpdateReservation(connection, reservation);

                if (success)
                    Console.WriteLine("Reservation updated");
                else
                    Console.WriteLine(" Update failed.");
            }

         */

        public static bool UpdateReservation(SqliteConnection connection, Reservation reservation)
        {
            using var command = connection.CreateCommand();
            command.CommandText = """
                UPDATE reservation
                SET customer_id = $customer_id,
                    room_id = $room_id,
                    start_date = $start_date,
                    end_date = $end_date
                WHERE reservation_id = $reservation_id;
            """;

            command.Parameters.AddWithValue("$customer_id", reservation.CustomerId);
            command.Parameters.AddWithValue("$room_id", reservation.RoomId);
            command.Parameters.AddWithValue("$start_date", reservation.StartDate);
            command.Parameters.AddWithValue("$end_date", reservation.EndDate);
            command.Parameters.AddWithValue("$reservation_id", reservation.ReservationId);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        /*
            var dbService = new DatabaseService();
            using (var connection = dbService.GetConnection())
            {
                connection.Open();

                Console.Write("Enter reservation ID to delete: ");
                int id = InputReader.ReadInt(1, int.MaxValue, "Enter reservation ID: ");

                bool deleted = ReservationService.DeleteReservation(connection, id);

                if (deleted)
                    Console.WriteLine($"Reservation {id} deleted successfully.");
                else
                    Console.WriteLine($"Reservation {id} not found or delete failed.");
            }
 
        */
        public static bool DeleteReservation(SqliteConnection connection, int reservationId)
        {
            using var command = connection.CreateCommand();
            command.CommandText = """
                DELETE FROM reservation
                WHERE reservation_id = $reservation_id;
            """;

            command.Parameters.AddWithValue("$reservation_id", reservationId);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
}