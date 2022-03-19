using System;

namespace MedicalAppointments.Presentation
{
    class Display
    {
        private const int closeOperationID = 7;
        public Display()
        {
            Input();
        }
        
        private void ShowMenu()
        {
            Console.WriteLine("1. Appointments");
            Console.WriteLine("2. Doctors");
            Console.WriteLine("3. Patients");
            Console.WriteLine("4. Medical centers");
            Console.WriteLine("5. Medical center types (Read-only)");
            Console.WriteLine("6. Blood groups (Read-only)");
            Console.WriteLine("7. Exit");
            Console.Write("Choose (1-7): ");
        }
        private void Input()
        {
            int op = -1;
            do
            {
                Console.WriteLine();
                ShowMenu();
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        new AppointmentsDisplay();
                        break;
                    case 2:
                        new DoctorsDisplay();
                        break;
                    case 3:
                        new PatientsDisplay();
                        break;
                    case 4:
                        new MedicalCentersDisplay();
                        break;
                    case 5:
                        new MedicalCenterTypesDisplay();
                        break;
                    case 6:
                        new BloodGroupsDisplay();
                        break;
                }
            } while (op != closeOperationID);
        }
    }
}
