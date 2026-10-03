using System;
using System.Collections.Generic;
using System.Text;

namespace Src2
{
    internal class Reservation
    {
        public Reservation(int reservationId, DateTime checkInDate, DateTime checkOutDate, Room room)
        {
            if (checkOutDate <= checkInDate)
                throw new Exception("Check-out date must be after check-in date.");
            if (room.IsUnderMaintenance==true)
                throw new Exception("This room is unber naintenance");
            ReservationId = reservationId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Room = room;
            Status = ReservationStatus.Pending;
        }

        public int ReservationId { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
       
        public Room Room { get; } 
        public ReservationStatus Status { get; private set; }
        public void Confirm()
        {
            if (Status != ReservationStatus.Pending)
                throw new Exception("Reservation can only be confirmed when it is pending.");

            Status = ReservationStatus.Confirmed;
        }

        public void CheckIn()
        {
            if (Status != ReservationStatus.Confirmed)
                throw new Exception("Reservation can only be checked in when it is confirmed.");

            Status = ReservationStatus.CheckedIn;
        }

        public void CheckOut()
        {
            if (Status != ReservationStatus.CheckedIn)
                throw new Exception("Reservation can only be checked out when it is checked in.");

            Status = ReservationStatus.CheckedOut;
        }

        public void Cancel()
        {
            if (Status != ReservationStatus.Pending &&
                Status != ReservationStatus.Confirmed)
                throw new Exception("Only pending or confirmed reservations can be cancelled.");

            Status = ReservationStatus.Cancelled;
        }
        public decimal CalculateTotalCost()
        {
            TimeSpan stayDuration = CheckOutDate - CheckInDate;
            int numberOfNights = stayDuration.Days;

            return numberOfNights * Room.NightlyRate;
        }
    }
    internal enum ReservationStatus
    {
        Pending,
        Confirmed,
        CheckedIn,
        CheckedOut,
        Cancelled
    }
}
