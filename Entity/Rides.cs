using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Rides : IEntitiesInterface
    {
        private int id;
        private string name;
        private string category;
        private string status;
        private List<Report> reports;

        public event PropertyChangedEventHandler PropertyChanged;

        public Rides(int id, string name, string category, string status)
        {
            Id = id;
            Name = name;
            Category = category;
            Status = status;
        }

        public Rides(string name, string category, string status)
        {
            Name = name;
            Category = category;
            Status = status;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public List<Report> Reports
        {
            get { return reports; }
            set { reports = value; }
        }
        public int NumberOfShutdown()
        {
            int shutdowns = 0;
            foreach (Report report in Reports)
            {
                shutdowns += report.Status == "nedbrudt" ? 1 : 0;
            }
            return shutdowns;
        }
        public DateTime DaysSinceLastShutdown()
        {
            try
            {
                Report reportHolder = reports.FirstOrDefault();
                foreach (Report report in Reports)
                {
                    reportHolder = report.ReportTime > reportHolder.ReportTime ? report : reportHolder;
                }
                return reportHolder.ReportTime;
            }
            catch (Exception)
            {
                throw new ArgumentNullException("the current ride have no reports");
            }
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
