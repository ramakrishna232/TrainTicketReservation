using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainTicketReservation.Models
{
    public class RouteDetails
    {
        public place Source { get; set; }
        public place Destination { get; set; }

    }
    public enum place
    {
        Chennai,
        Nellore,
        Gudur,
        Hyderbad,
        Banglore,
        Delhi,
        Bhuvneshwar
    }
}