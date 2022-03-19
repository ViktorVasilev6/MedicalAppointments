using System;
using System.Collections.Generic;

namespace MedicalAppointments.Data.Models
{
    public partial class Appointments
    {
        private int patientId, doctorId;
        public int Id { get; set; }
        // Валидация за ID на пациент
        public int PatientId
        {
            get => patientId;
            set
            {
                if(value <= 0)
                {
                    throw new Exception("Invalid input!");
                }
                patientId = value;
            }
        }
        // Валидация за ID на лекар
        public int DoctorId
        {
            get => doctorId;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Invalid input!");
                }
                doctorId = value;
            }
        }
        public DateTime TimeAndDate { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Patients Patient { get; set; }

        // toString репрезентация на обекта
        public override string ToString()
        {
            return string.Format("{0, -10}{1, -25}{2, -25}{3, -10}", 
                                Id + ".", Patient.FirstName + " " + Patient.LastName, 
                                "Dr. " + Doctor.FirstName + " " + Doctor.LastName, TimeAndDate.ToString("dd/MM/yyyy HH:mm"));
        }
    }
}
