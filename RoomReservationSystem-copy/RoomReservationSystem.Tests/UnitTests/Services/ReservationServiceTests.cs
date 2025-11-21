using Xunit;
using RoomReservationSystem.Models;
using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Collections.Generic;
using RoomReservationSystem.Services;

namespace RoomReservationSystem.Tests.UnitTests.Services
{
    public class ReservationServiceTests
    {
        private readonly string _dbPath = Path.Combine("Data", "room_reservation_system.db");

        private SqliteConnection GetConnection()
        {
            return new SqliteConnection($"Data Source={_dbPath}");
        }

        [Fact]
        public void GetAllReservations_ShouldReturnAtLeastOneReservation()
        {
            using var connection = GetConnection();
            var reservations = ReservationService.GetAllReservations(connection);

            Assert.NotNull(reservations);
            Assert.NotEmpty(reservations);
        }

        [Fact]
        public void GetReservationById_ShouldReturnCorrectReservation()
        {
            using var connection = GetConnection();
            var reservation = ReservationService.GetReservationById(connection, 1);

            Assert.NotNull(reservation);
            Assert.Equal(1, reservation!.ReservationId);
        }

        [Fact]
        public void GetReservationById_ShouldReturnNull_WhenNotFound()
        {
            using var connection = GetConnection();
            var reservation = ReservationService.GetReservationById(connection, 9999);

            Assert.Null(reservation);
        }

        [Fact]
        public void CreateReservation_ShouldInsertNewReservation()
        {
            using var connection = GetConnection();
            connection.Open();

            var newReservation = new Reservation
            {
                CustomerId = 2,
                RoomId = 1,
                StartDate = new DateTime(2025, 11, 10),
                EndDate = new DateTime(2025, 11, 12)
            };

            var createdId = ReservationService.CreateReservation(connection, newReservation);
            var createdReservation = ReservationService.GetReservationById(connection, createdId);

            Assert.NotNull(createdReservation);
            Assert.Equal(newReservation.CustomerId, createdReservation!.CustomerId);
            Assert.Equal(newReservation.RoomId, createdReservation.RoomId);
            Assert.Equal(newReservation.StartDate, createdReservation.StartDate);
            Assert.Equal(newReservation.EndDate, createdReservation.EndDate);
        }

        [Fact]
        public void UpdateReservation_ShouldModifyExistingReservation()
        {
            using var connection = GetConnection();
            connection.Open();

            var reservation = new Reservation
            {
                CustomerId = 3,
                RoomId = 2,
                StartDate = new DateTime(2025, 12, 1),
                EndDate = new DateTime(2025, 12, 5)
            };
            var id = ReservationService.CreateReservation(connection, reservation);

            reservation.ReservationId = id;
            reservation.EndDate = reservation.EndDate.AddDays(1); // extend by one day
            ReservationService.UpdateReservation(connection, reservation);

            var updated = ReservationService.GetReservationById(connection, id);

            Assert.NotNull(updated);
            Assert.Equal(reservation.EndDate, updated!.EndDate);
        }

        [Fact]
        public void DeleteReservation_ShouldRemoveReservation()
        {
            using var connection = GetConnection();
            connection.Open();

            var reservation = new Reservation
            {
                CustomerId = 2,
                RoomId = 3,
                StartDate = new DateTime(2025, 12, 10),
                EndDate = new DateTime(2025, 12, 12)
            };
            var id = ReservationService.CreateReservation(connection, reservation);

            ReservationService.DeleteReservation(connection, id);
            var deleted = ReservationService.GetReservationById(connection, id);

            Assert.Null(deleted);
        }
    }
}