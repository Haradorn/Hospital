using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class SortViewModel
    {
        public SortState PatientSort { get; private set; } 
        public SortState DoctorSort { get; private set; }    
        public SortState StartSort { get; private set; }   
        public SortState Current { get; private set; }     // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            PatientSort = sortOrder == SortState.PatientAsc ? SortState.PatientDesc : SortState.PatientAsc;
            DoctorSort = sortOrder == SortState.DoctorAsc ? SortState.DoctorDesc : SortState.DoctorAsc;
            StartSort = sortOrder == SortState.StartAsc ? SortState.StartDesc : SortState.StartAsc;
            Current = sortOrder;
        }
    }
}
