using MedicalAppointments.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalAppointments.Data
{
    class PatientsData
    {
        public List<Patients> GetAll()
        {
            using (var ctx = new DoctorDBContext())
            {
                return ctx.Patients.Include(p => p.BloodGroup).ToList();
            }
        }
        public Patients Get(int id)
        {
            using (var ctx = new DoctorDBContext())
            {
                return ctx.Patients.Include(p => p.BloodGroup).Where(p => p.Id == id).First();
            }
        }
        public void Add(Patients patient)
        {
            using (var ctx = new DoctorDBContext())
            {
                ctx.Patients.Add(patient);
                ctx.SaveChanges();
            }
        }
        public void Update(Patients patient)
        {
            using (var ctx = new DoctorDBContext())
            {
                ctx.Entry(patient).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var ctx = new DoctorDBContext())
            {
                var patient = ctx.Patients.Where(p => p.Id == id).First();
                var apps = ctx.Appointments.Where(a => a.Patient.Id == id);
                ctx.Patients.Remove(patient);
                ctx.Appointments.RemoveRange(apps);
                ctx.SaveChanges();
            }
        }
    }
}
