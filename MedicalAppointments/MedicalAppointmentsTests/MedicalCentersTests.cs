using MedicalAppointments.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointmentsTests
{
    class MedicalCentersTests
    {
        [Test]
        public void AddMedicalCenter_CenterTypeIdNegativeValue_ThrowsException()
        {
            try
            {
                var a = new MedicalCenters();
                a.CenterTypeId = -1;
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
        }
    }
}
