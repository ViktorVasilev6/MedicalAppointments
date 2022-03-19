using MedicalAppointments.Data;
using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointments.Business
{
    class PatientsManager
    {
        private PatientsData manager = new PatientsData();

        public List<Patients> GetAll()
        {
            return manager.GetAll();
        }
        public Patients Get(int id)
        {
            return manager.Get(id);
        }
        public void Add(Patients patient)
        {
            manager.Add(patient);
        }
        public void Update(Patients patient)
        {
            manager.Update(patient);
        }
        public void Delete(int id)
        {
            manager.Delete(id);
        }
    }
}
