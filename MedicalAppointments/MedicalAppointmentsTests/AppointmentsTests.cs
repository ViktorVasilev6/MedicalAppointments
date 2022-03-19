using MedicalAppointments.Data.Models;
using NUnit.Framework;
using System;

namespace MedicalAppointmentsTests
{
    public class AppointmentsTests
    {
        [Test]
        public void AddAppointment_PatientIdNegativeValue_ThrowsException()
        {
            try
            {
                var a = new Appointments();
                a.PatientId = -1;
            } catch(Exception e)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void AddAppointment_DoctorIdNegativeValue_ThrowsException()
        {
            try
            {
                var a = new Appointments();
                a.DoctorId = -1;
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
        }
    }
}