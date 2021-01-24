using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Controllers
{
    public class HomeController : Controller
    {
        HospitalContext db;
        public HomeController(HospitalContext context)
        {
            this.db = context;
            if (db.Patients.Count() == 0)
            {
                Patient patient1 = new Patient { Name = "Иванов И.И.", Home = "Ул. Урицкого, д. 14, кв. 124", DayOfBirth = "12.03.1976" };
                Patient patient2 = new Patient { Name = "Петров П.П.", Home = "Ул. Матросова, д. 2", DayOfBirth = "22.12.1991" };
                Patient patient3 = new Patient { Name = "Сидоров С.С.", Home = "Ул. Володарского, д. 124, кв. 4", DayOfBirth = "14.10.1986" };
                Patient patient4 = new Patient { Name = "Касьянова А.Е.", Home = "Ул. Гагарина, д. 16", DayOfBirth = "01.12.1969" };
                Patient patient5 = new Patient { Name = "Гречкин Р.Н.", Home = "Ул. Высоцкого, д. 23, кв. 1", DayOfBirth = "11.05.1958" };
                Patient patient6 = new Patient { Name = "Ляшенко К.В.", Home = "Ул. Горького, д. 12", DayOfBirth = "15.03.1982" };

                Deseases desease1 = new Deseases { Name = "Грипп" };
                Deseases desease2 = new Deseases { Name = "Глазная болезнь" };
                Deseases desease3 = new Deseases { Name = "Ушная болезнь" };
                Deseases desease4 = new Deseases { Name = "Венерическая болезнь" };

                Doctor doctor1 = new Doctor { Name = "Городецкий Е.А.", Specialization = "Терапевт" };
                Doctor doctor2 = new Doctor { Name = "Омельченко Г.К.", Specialization = "Отоларинголог" };
                Doctor doctor3 = new Doctor { Name = "Красавина У.В.", Specialization = "Венеролог" };
                Doctor doctor4 = new Doctor { Name = "Турецкий А.В.", Specialization = "Офтальмолог" };

                Admission admission1 = new Admission { Deseases = desease1, Doctor = doctor1, Patient = patient1, Start = "01.02.2020", IsDischarged = "Выписан" };
                Admission admission2 = new Admission { Deseases = desease1, Doctor = doctor1, Patient = patient4, Start = "05.02.2020", IsDischarged = "На лечении" };
                Admission admission3 = new Admission { Deseases = desease2, Doctor = doctor4, Patient = patient3, Start = "10.03.2020", IsDischarged = "Выписан" };
                Admission admission4 = new Admission { Deseases = desease3, Doctor = doctor2, Patient = patient1, Start = "15.03.2020", IsDischarged = "На лечении" };
                Admission admission5 = new Admission { Deseases = desease4, Doctor = doctor3, Patient = patient6, Start = "23.03.2020", IsDischarged = "На лечении" };
                Admission admission6 = new Admission { Deseases = desease2, Doctor = doctor4, Patient = patient5, Start = "03.04.2020", IsDischarged = "Выписан" };
                Admission admission7 = new Admission { Deseases = desease4, Doctor = doctor3, Patient = patient2, Start = "09.04.2020", IsDischarged = "Выписан" };
                Admission admission8 = new Admission { Deseases = desease3, Doctor = doctor2, Patient = patient2, Start = "11.04.2020", IsDischarged = "На лечении" };
                Admission admission9 = new Admission { Deseases = desease4, Doctor = doctor3, Patient = patient6, Start = "15.05.2020", IsDischarged = "На лечении" };
                Admission admission10 = new Admission { Deseases = desease3, Doctor = doctor2, Patient = patient3, Start = "04.06.2020", IsDischarged = "Выписан" };

                db.Patients.AddRange(patient1, patient2, patient3, patient4, patient5, patient6);
                db.Deseases.AddRange(desease1, desease2, desease3, desease4);
                db.Doctors.AddRange(doctor1, doctor2, doctor3, doctor4);
                db.Admissions.AddRange(admission1, admission2, admission3, admission4, admission5, admission6, admission7, admission8, admission9, admission10);
                db.SaveChanges();
            }
        }
        public async Task<IActionResult> Index(int? doctor, string name, int page = 1,
            SortState sortOrder = SortState.DoctorAsc)
        {
            int pageSize = 3;
            IQueryable<Admission> admissions = db.Admissions.Include(x => x.Doctor);
            if (doctor != null && doctor != 0)
            {
                admissions = admissions.Where(p => p.DoctorId == doctor);
            }
            switch (sortOrder)
            {
                case SortState.DoctorDesc:
                    admissions = admissions.OrderByDescending(s => s.Doctor);
                    break;
                case SortState.PatientAsc:
                    admissions = admissions.OrderBy(s => s.Patient);
                    break;
                case SortState.PatientDesc:
                    admissions = admissions.OrderByDescending(s => s.Patient);
                    break;
                case SortState.StartAsc:
                    admissions = admissions.OrderBy(s => s.Start);
                    break;
                case SortState.StartDesc:
                    admissions = admissions.OrderByDescending(s => s.Start);
                    break;
                default:
                    admissions = admissions.OrderBy(s => s.Doctor);
                    break;
            }

            var count = await admissions.CountAsync();
            var items = await admissions.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Admissions.ToList(), doctor, name),
                Admissions = items
            };
            return View(viewModel);
        }
    }
}
