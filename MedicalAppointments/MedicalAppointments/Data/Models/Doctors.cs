using System;
using System.Collections.Generic;

namespace MedicalAppointments.Data.Models
{
    public partial class Doctors
    {
        private int centerId;
        public Doctors()
        {
            Appointments = new HashSet<Appointments>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string SpecialPosition
        {
            get; set;
        }
        public string AcademicDegree
        {
            get; set;
        }
        // Валидация за ID на медицинско заведение
        public int CenterId
        {
            get => centerId;
            set
            {
                if(value <= 0)
                {
                    throw new Exception("Invalid input!");
                }
                centerId = value;
            }
        }

        public virtual MedicalCenters Center { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }

        // toString репрезентация на обекта
        public override string ToString()
        {
            return String.Format("{0, -10}{1, -35}{2, -25}{3, -35}{4, -25}{5, -10}", 
                                  Id + ".", "Dr. " + FirstName + " " + LastName,
                                  Specialty, SpecialPosition, AcademicDegree, Center.CenterName);
        }
    }
}
