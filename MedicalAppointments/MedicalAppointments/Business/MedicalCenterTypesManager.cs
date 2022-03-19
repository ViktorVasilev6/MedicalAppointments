using MedicalAppointments.Data;
using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointments.Business
{
    // Бизнес логика, свързана с видовете медицински заведения
    class MedicalCenterTypesManager
    {
        MedicalCenterTypesData manager = new MedicalCenterTypesData();
        public List<MedicalCenterTypes> GetAll()
        {
            return manager.GetAll();
        }
        public MedicalCenterTypes Get(int id)
        {
            return manager.Get(id);
        }
    }
}
