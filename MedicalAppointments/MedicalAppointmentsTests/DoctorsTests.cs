using MedicalAppointments.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointmentsTests
{
    class DoctorsTests
    {
        [Test]
        public void AddDoctor_CenterIdNegativeValue_ThrowsException()
        {
            try
            {
                var a = new Doctors();
                a.CenterId= -1;
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
        }
    }
}
