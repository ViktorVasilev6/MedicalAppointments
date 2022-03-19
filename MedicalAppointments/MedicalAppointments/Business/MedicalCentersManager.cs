using MedicalAppointments.Data;
using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointments.Business
{
    class MedicalCentersManager
    {
        private MedicalCentersData manager = new MedicalCentersData();

        public List<MedicalCenters> GetAll()
        {
            return manager.GetAll();
        }
        public MedicalCenters Get(int id)
        {
            return manager.Get(id);
        }
        public void Add(MedicalCenters center)
        {
            manager.Add(center);
        }
        public void Update(MedicalCenters center)
        {
            manager.Update(center);
        }
        public void Delete(int id)
        {
            manager.Delete(id);
        }
    }
}
