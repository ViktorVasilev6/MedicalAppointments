using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace MedicalAppointments.Data
{
    class AppointmentsData
    {
        public List<Appointments> GetAll()
        {
            using(var ctx = new DoctorDBContext())
            {
                return ctx.Appointments.Include(a => a.Patient).Include(a => a.Doctor).ToList();
            }
        }
        public Appointments Get(int id)
        {
            using(var ctx = new DoctorDBContext())
            {
                return ctx.Appointments.Include(a => a.Patient).Include(a => a.Doctor)
                          .Where(a => a.Id == id).First();
            }
        }      
        public void Add(Appointments appointment)
        {
            using(var ctx = new DoctorDBContext())
            {
                ctx.Appointments.Add(appointment);
                ctx.SaveChanges();
            }
        }
        public void Update(Appointments appointment)
        {
            using (var ctx = new DoctorDBContext())
            {
                ctx.Entry(appointment).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var ctx = new DoctorDBContext())
            {
                ctx.Appointments.Remove(Get(id));
                ctx.SaveChanges();
            }
        }
    }
}
