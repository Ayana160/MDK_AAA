using ClassroomBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomBooking.Services
{
    public class BookingService
    {
        private readonly List<Booking> bookings = new List<Booking>();

        public bool AddBooking(Booking booking)
        {
            bool conflict = bookings.Any(existing =>
            existing.RoomId == booking.RoomId &&
            existing.Date.Date == booking.Date.Date &&
            existing.StartTime < booking.EndTime &&
            booking.StartTime < existing.EndTime);

            if (conflict)
                return false;

            booking.Id = bookings.Count + 1;
            bookings.Add(booking);
            return true;
        }

        public List<Booking> GetBookings()
        {
            return bookings;
        }
    }
}