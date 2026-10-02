using System;
using System.Collections.Generic;
using System.Text;

namespace Src2
{
    internal class Guest
    {
        public Guest(int guestID, string fullName, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new Exception("Guest full name cannot be empty.");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new Exception("Guest phone number cannot be empty.");
            GuestID = guestID;
            FullName = fullName;
            PhoneNumber = phoneNumber;

        }

        public int GuestID { get; }
        public string FullName { get; }
        public string PhoneNumber { get; }
        private readonly List<Reservation> resrvations = new List<Reservation>();
        public IReadOnlyList<Reservation> Reservations => resrvations;
        public void AddReservation(Reservation reservation)
        {
            foreach (Reservation existingReservation in resrvations)
            {
                if (existingReservation.Room == reservation.Room &&
                    existingReservation.CheckInDate < reservation.CheckOutDate &&
                    reservation.CheckInDate < existingReservation.CheckOutDate)
                {
                    throw new Exception("This room is already reserved for these dates.");
                }

            }
        }
    }
}
