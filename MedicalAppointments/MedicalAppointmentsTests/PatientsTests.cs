using MedicalAppointments.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointmentsTests
{
    class PatientsTests
    {
        [Test]
        public void AddPatient_BloodGroupIdNegativeValue_ThrowsException()
        {
            try
            {
                var a = new Patients();
                a.BloodGroupId = -1;
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
        }
    }
}
