using System;
using System.Collections.Generic;
using System.Text;

namespace Src2
{
    internal class Room
    {
        
        public int RoomNumber { get; }
        public RoomType RoomType { get; }
        public decimal NightlyRate { get; private set; }
        public bool IsUnderMaintenance { get; private set; }

        public Room(int roomNumber, RoomType roomType, decimal nightlyRate)
        {
            if (nightlyRate <= 0)
                throw new Exception("nightlyRate must be bigger than 0");
            RoomNumber = roomNumber;
            RoomType = roomType;
            NightlyRate = nightlyRate;
            IsUnderMaintenance = false;
        }
        public void ChangenightlyRate(decimal newRate)
        {
            if (newRate <= 0)
                throw new Exception("nightlyRate must be bigger than 0");
            NightlyRate = newRate;
        }
        public void StartMaintan()
        {
            IsUnderMaintenance = true;
        }
        public void EndMaintan()
        {
            IsUnderMaintenance = false;
        }
    }
    internal enum RoomType 
    {
        Single,
        Double,
        Suite
    }
}
