using MedicalAppointments.Business;
using System;
using System.Collections.Generic;

namespace MedicalAppointments.Data.Models
{
    public partial class Patients
    {
        private int bloodGroupId;
        public Patients()
        {
            Appointments = new HashSet<Appointments>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public int BloodGroupId
        {
            get => bloodGroupId;
            set
            {
                if(value <= 0)
                {
                    throw new Exception("Invalid input!");
                }
                bloodGroupId = value;
            }
        }
        public string Diagnose { get; set; }

        public virtual BloodGroups BloodGroup { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }

        public override string ToString()
        {
            return string.Format("{0, -10}{1, -15}{2, -15}{3, -15}{4, -5}{5, -10}",
                                  Id + ".", FirstName, LastName,
                                  Birthdate.ToString("dd/MM/yyyy"), 
                                  BloodGroup.BloodType + (BloodGroup.RhFactor?"+":"-"), Diagnose);
        }
    }
}
