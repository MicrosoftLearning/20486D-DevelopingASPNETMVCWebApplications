using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class EmployeeRequirements
    {
        public int Id { get; set; }

        public double MinimumAge { get; set; }

        public string JobTitle { get; set; }

        public double PricePerHour { get; set; }

        public string JobDescription { get; set; }

        public virtual ICollection<JobApplication> JobApplications { get; set; }
    }
}
