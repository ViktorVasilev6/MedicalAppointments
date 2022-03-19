using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalAppointments.Data
{
    class MedicalCenterTypesData
    {
        public List<MedicalCenterTypes> GetAll()
        {
            using (var ctx = new DoctorDBContext())
            {
                return ctx.MedicalCenterTypes.ToList();
            }
        }
        public MedicalCenterTypes Get(int id)
        {
            using (var ctx = new DoctorDBContext())
            {
                return ctx.MedicalCenterTypes.Where(type => type.Id == id).First();
            }
        }
    }
}
