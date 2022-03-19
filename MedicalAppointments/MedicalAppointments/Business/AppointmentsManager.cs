using MedicalAppointments.Data;
using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointments.Business
{
    class AppointmentsManager
    {
        private AppointmentsData manager = new AppointmentsData();

        public List<Appointments> GetAll()
        {
            return manager.GetAll();
        }
        public Appointments Get(int id)
        {
            return manager.Get(id);
        }
        public void Add(Appointments appointment)
        {
            manager.Add(appointment);
        }
        public void Update(Appointments appointment)
        {
            manager.Update(appointment);
        }
        public void Delete(int id)
        {
            manager.Delete(id);
        }
    }
}
