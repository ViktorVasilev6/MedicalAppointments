using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalAppointments.Data
{
    class BloodGroupsData
    {
        public List<BloodGroups> GetAll()
        {
            using (var ctx = new DoctorDBContext())
            {
                return ctx.BloodGroups.ToList();
            }
        }
        public BloodGroups Get(int id)
        {
            using (var ctx = new DoctorDBContext())
            {
                return ctx.BloodGroups.Where(g => g.Id == id).First();
            }
        }
    }
}
