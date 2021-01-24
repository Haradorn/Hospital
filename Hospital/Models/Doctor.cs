using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public List<Admission> Admissions { get; set; }
        public Doctor()
        {
            Admissions = new List<Admission>();
        }
    }
}
