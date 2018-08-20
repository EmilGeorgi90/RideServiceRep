using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Report : ObservableCollection<Report>, IEntitiesInterface
    {
        private string notes;
        private DateTime reportTime;
        private string status;
        private Rides rides;
        private int id;

        public Report(Rides ride, string status, DateTime reportTime, string notes)
        {
            Ride = ride;
            Status = status;
            ReportTime = reportTime;
            Notes = notes;
        }

        public Report(int id, Rides ride, string status, DateTime reportTime, string notes)
        {
            Id = id;
            Ride = ride;
            Status = status;
            ReportTime = reportTime;
            Notes = notes;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Rides Ride
        {
            get { return rides; }
            set { rides = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime ReportTime
        {
            get { return reportTime; }
            set { reportTime = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public int CompareTo(IEntitiesInterface other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IEntitiesInterface other)
        {
            return base.Equals(other);
        }
    }
}
