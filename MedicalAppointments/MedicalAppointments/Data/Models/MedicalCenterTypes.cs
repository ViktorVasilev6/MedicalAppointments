using System;
using System.Collections.Generic;

namespace MedicalAppointments.Data.Models
{
    public partial class MedicalCenterTypes
    {
        public MedicalCenterTypes()
        {
            MedicalCenters = new HashSet<MedicalCenters>();
        }

        public int Id { get; set; }
        public string CenterType { get; set; }

        public virtual ICollection<MedicalCenters> MedicalCenters { get; set; }
        public override string ToString()
        {
            return Id + ". " + CenterType;
        }
    }
}
