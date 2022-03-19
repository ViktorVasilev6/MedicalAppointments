using MedicalAppointments.Data;
using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointments.Business
{
    // Бизнес логика, свързана с лекарския персонал
    class DoctorsManager
    {
        private DoctorsData manager = new DoctorsData();

        public List<Doctors> GetAll()
        {
            return manager.GetAll();
        }
        public Doctors Get(int id)
        {
            return manager.Get(id);
        }
        public void Add(Doctors doctor)
        {
            manager.Add(doctor);
        }
        public void Update(Doctors doctor)
        {
            manager.Update(doctor);
        }
        public void Delete(int id)
        {
            manager.Delete(id);
        }
    }
}
