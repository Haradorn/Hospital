using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Admission> admissions, int? admission, string start)
        {
            admissions.Insert(0, new Admission { Start = "Все", Id = 0 });
            Admissions = new SelectList(admissions, "Id", "Start", admission);
            SelectedAdmission = admission;
            SelectedStart = start;
        }
        public SelectList Admissions { get; private set; } 
        public int? SelectedAdmission { get; private set; }  
        public string SelectedStart { get; private set; }  
    }
}
