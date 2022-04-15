using System;
using System.Collections.Generic;
using System.Linq;
using Web_app_customer.Data;
using Web_app_customer.Models;

namespace Web_app_customer.Utils
{
    public class HotellService
    {
        private readonly Oblig4Context _context;

        public HotellService(Oblig4Context context)
        {
            this._context = context;
        }


        public List<Room> searchRoom(DateTime from, DateTime to, int selectedBeds, int quality)
        {
            List<Room> potentialRooms = _context.rooms.Where(r => r.NumOfBeds == selectedBeds && r.Size == quality).ToList();

            List<Reservation> reservations = _context.reservations.ToList();

            List<Room> availableRoom = getRooms(from, to, potentialRooms);//potentialRooms.Where(r => r.Reservations.Any(y => !IsBewteenTwoDates(from, y.DateStart, y.DateEnd) && !IsBewteenTwoDates(to, y.DateStart, y.DateEnd))).ToList();

            return availableRoom;
        }


        public List<Room> getRooms(DateTime from, DateTime to,List<Room> availableRooms)
        {
            
            List<Room> choosenRooms = new List<Room>();
            foreach(Room r in availableRooms)
            {
                bool isAvailable = true;
                foreach (Reservation res in r.Reservations)
                {
                    if (IsBetweenTwoDates(from, res.DateStart, res.DateEnd) || IsBetweenTwoDates(to, res.DateStart, res.DateEnd))
                    {
                        isAvailable = false;
                        break;
      
                    }
                }
                if(isAvailable)
                {
                    choosenRooms.Add(r);
                }
              
            }
            return choosenRooms;

        }

        public bool IsBetweenTwoDates(DateTime dt, DateTime start, DateTime end)
        {
           
            return dt >= start && dt <= end;
        }

        public void makeReservation(DateTime from, DateTime to, int roomId, string username)
        {
            Reservation reservation = new Reservation(from, to, roomId, username);
            if (!_context.users.Where(u => u.Username == username).ToList().Any())
            {

                User user = new User();
                user.Username = username;
                user.Reservations.Add(reservation);
                _context.users.Add(user);
            }
            else
            {

                User user = _context.users.Where(u => u.Username == username).ToList().First();
                user.Reservations.Add(reservation);
            }

            _context.reservations.Add(reservation);
            _context.SaveChanges();
        }

        public IEnumerable<Reservation> getReservations(string username)
        {

            IEnumerable<Reservation> reservations = _context.reservations.Where(r => r.UserUsername == username).ToList();

            return reservations;
        }
        public void checkOut(Reservation r)
        {
            r.CheckedOut = true;
            _context.Update<Reservation>(r);
            _context.SaveChanges();
        }
        public void checkIn(Reservation r)
        {
            r.CheckedIn = true;
            _context.Update<Reservation>(r);
            _context.SaveChanges();
        }

    }


}
