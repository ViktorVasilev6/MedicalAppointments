using MedicalAppointments.Business;
using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointments.Presentation
{
    class MedicalCenterTypesDisplay
    {
        private MedicalCenterTypesManager manager = new MedicalCenterTypesManager();
        private const int backOperationCode = 3;

        public MedicalCenterTypesDisplay()
        {
            Console.WriteLine();
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 168));
            Console.WriteLine(new string(' ', 84) + "MEDICAL CENTER TYPES MENU" + new string(' ', 84));
            Console.WriteLine(new string('-', 168));
            Console.WriteLine("1. List all Medical center types");
            Console.WriteLine("2. Fetch a Medical center type by ID");
            Console.WriteLine("3. Back");
            Console.Write("Choose (1-3): ");
        }
        private void Input()
        {
            int op = -1;
            do
            {
                ShowMenu();
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine();
                        ListAll();
                        break;
                    case 2:
                        Console.WriteLine();
                        Fetch();
                        break;
                }
            } while (op != backOperationCode);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 45));
            Console.WriteLine(new string(' ', 16) + "MEDICAL CENTER TYPES" + new string(' ', 16));
            Console.WriteLine(new string('-', 45));
            var medicalCenterTypes = manager.GetAll();
            foreach (var a in medicalCenterTypes)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }
        private void Fetch()
        {
            Console.Write("Enter ID of Medical center type: ");
            MedicalCenterTypes medicalCenterType = manager.Get(int.Parse(Console.ReadLine()));
            Console.WriteLine(medicalCenterType);
        }
    }
}
