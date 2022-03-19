using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace MedicalAppointments.Data
{
    // Заявки, свързани с медицинските заведения
    class MedicalCentersData
    {
        public List<MedicalCenters> GetAll()
        {
            using(var ctx = new DoctorDBContext())
            {
                return ctx.MedicalCenters.Include(c => c.CenterType).ToList();
            }
        }
        public MedicalCenters Get(int id)
        {
            using (var ctx = new DoctorDBContext())
            {
                return ctx.MedicalCenters.Include(c => c.CenterType).Where(c => c.Id == id).First();
            }
        }
        public void Add(MedicalCenters center)
        {
            using (var ctx = new DoctorDBContext())
            {
                ctx.MedicalCenters.Add(center);
                ctx.SaveChanges();
            }
        }
        public void Update(MedicalCenters center)
        {
            using (var ctx = new DoctorDBContext())
            {
                ctx.Entry(center).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var ctx = new DoctorDBContext())
            {
                var center = ctx.MedicalCenters.Where(c => c.Id == id).First();
                var doctors = ctx.Doctors.Where(d => d.Center.Id == id);
                ctx.MedicalCenters.Remove(center);
                ctx.Doctors.RemoveRange(doctors);
                ctx.SaveChanges();
            }
        }
    }
}
