using System;
using System.Collections.Generic;

namespace MedicalAppointments.Data.Models
{
    public partial class BloodGroups
    {
        public BloodGroups()
        {
            Patients = new HashSet<Patients>();
        }

        public int Id { get; set; }
        public string BloodType { get; set; }
        public bool RhFactor { get; set; }

        public virtual ICollection<Patients> Patients { get; set; }

        // toString репрезентация на обекта
        public override string ToString()
        {
            return Id + ". " + BloodType + (RhFactor ? "+" : "-");
        }
    }
}
