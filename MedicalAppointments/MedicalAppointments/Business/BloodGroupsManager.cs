using System;
using System.Collections.Generic;
using System.Text;
using MedicalAppointments.Data;
using MedicalAppointments.Data.Models;

namespace MedicalAppointments.Business
{
    // Бизнес логика, свързана с кръвните групи
    class BloodGroupsManager
    {
        private BloodGroupsData manager = new BloodGroupsData();

        public List<BloodGroups> GetAll()
        {
            return manager.GetAll();
        }
        public BloodGroups Get(int id)
        {
            return manager.Get(id);
        }
    }
}
