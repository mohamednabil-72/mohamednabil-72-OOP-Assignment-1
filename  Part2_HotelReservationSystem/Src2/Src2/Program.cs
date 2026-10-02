namespace Src2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Guest guest = new Guest(1, "Mohamed Nabil", "01000000000");

            Room room = new Room(101, RoomType.Single, 500);

            Reservation reservation = new Reservation(
                1,
                new DateTime(2026, 10, 10),
                new DateTime(2026, 10, 13),
                room
            );

            guest.AddReservation(reservation);

            Console.WriteLine($"Reservation Status: {reservation.Status}");
            Console.WriteLine($"Total Cost: {reservation.CalculateTotalCost}");

            reservation.Confirm();
            Console.WriteLine($"Reservation Status: {reservation.Status}");

            reservation.CheckIn();
            Console.WriteLine($"Reservation Status: {reservation.Status}");

            reservation.CheckOut();
            Console.WriteLine($"Reservation Status: {reservation.Status}");

            Console.WriteLine();

            Console.WriteLine("Testing Double Booking...");

            try
            {
                Reservation reservation2 = new Reservation(
                    2,
                    new DateTime(2026, 10, 11),
                    new DateTime(2026, 10, 14),
                    room
                );

                guest.AddReservation(reservation2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            Console.WriteLine("Testing Maintenance...");

            room.StartMaintan();

            try
            {
                Reservation reservation3 = new Reservation(
                    3,
                    new DateTime(2026, 10, 20),
                    new DateTime(2026, 10, 22),
                    room
                );

                guest.AddReservation(reservation3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            room.EndMaintan();

            Console.WriteLine();

            Console.WriteLine("Testing Nightly Rate Change...");

            room.ChangenightlyRate(600);

            Console.WriteLine($"New Nightly Rate: {room.NightlyRate}");

            Console.WriteLine();

            Console.WriteLine("All tests completed.");


        }
    }
}
