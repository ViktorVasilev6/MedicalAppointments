using MedicalAppointments.Business;
using System;
using System.Collections.Generic;

namespace MedicalAppointments.Data.Models
{
    public partial class MedicalCenters
    {
        private int centerTypeId;
        public MedicalCenters()
        {
            Doctors = new HashSet<Doctors>();
        }

        public int Id { get; set; }
        public string CenterName { get; set; }
        public string CenterAddress { get; set; }
        public string PhoneNumber { get; set; }
        // Валидация за ID на тип медицинско заведение
        public int CenterTypeId
        {
            get => centerTypeId;
            set
            {
                if(value <= 0)
                {
                    throw new Exception("Invalid input!");
                }
                centerTypeId = value;
            }
        }

        public virtual MedicalCenterTypes CenterType { get; set; }
        public virtual ICollection<Doctors> Doctors { get; set; }

        // toString репрезентация на обекта
        public override string ToString()
        {
            return string.Format("{0, -10}{1, -30}{2, -30}{3, -15}{4, -10}",
                                  Id + ".", CenterName, CenterAddress, PhoneNumber, CenterType.CenterType);
        }
    }
}
