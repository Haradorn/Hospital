using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Deseases
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Admission> Admissions { get; set; }
        public Deseases()
        {
            Admissions = new List<Admission>();
        }
    }
}
