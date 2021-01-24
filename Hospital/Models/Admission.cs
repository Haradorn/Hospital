using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Admission
    {
        public int Id { get; set; }
        public string Start { get; set; }
        public string IsDischarged { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DeseaseId { get; set; }
        public Deseases Deseases { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
