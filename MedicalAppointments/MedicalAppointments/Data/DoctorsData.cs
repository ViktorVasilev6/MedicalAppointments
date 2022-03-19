using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointments.Data
{
    // Заявки, свързани с лекарския персонал
    class DoctorsData
    {
        public List<Doctors> GetAll()
        {
            using (var ctx = new DoctorDBContext())
            {
                return ctx.Doctors.Include(d => d.Center).ToList();
            }
        }
        public Doctors Get(int id)
        {
            using (var ctx = new DoctorDBContext())
            {
                return ctx.Doctors.Include(d => d.Center).Where(d => d.Id == id).First();
            }
        }
        public void Add(Doctors doctor)
        {
            using (var ctx = new DoctorDBContext())
            {
                ctx.Doctors.Add(doctor);
                ctx.SaveChanges();
            }
        }
        public void Update(Doctors doctor)
        {
            using (var ctx = new DoctorDBContext())
            {
                ctx.Entry(doctor).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var ctx = new DoctorDBContext())
            {
                var doctor = ctx.Doctors.Where(d => d.Id == id).First();
                var apps = ctx.Appointments.Where(a => a.Doctor.Id == id);
                ctx.Doctors.Remove(doctor);
                ctx.Appointments.RemoveRange(apps);
                ctx.SaveChanges();
            }
        }
    }
}
