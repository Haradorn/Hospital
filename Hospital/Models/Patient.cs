using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DayOfBirth { get; set; }
        public string Home { get; set; }
        public List<Admission> Admissions { get; set; }
        public Patient()
        {
            Admissions = new List<Admission>();
        }
    }
}
