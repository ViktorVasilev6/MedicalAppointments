using MedicalAppointments.Business;
using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointments.Presentation
{
    class BloodGroupsDisplay
    {
        private BloodGroupsManager manager = new BloodGroupsManager();
        private const int backOperationCode = 3;

        public BloodGroupsDisplay()
        {
            Console.WriteLine();
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 168));
            Console.WriteLine(new string(' ', 84) + "BLOOD GROUPS MENU" + new string(' ', 84));
            Console.WriteLine(new string('-', 168));
            Console.WriteLine("1. List all Blood groups");
            Console.WriteLine("2. Fetch a Blood group by ID");
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
            Console.WriteLine(new string('-', 168));
            Console.WriteLine(new string(' ', 84) + "BLOOD GROUPS" + new string(' ', 84));
            Console.WriteLine(new string('-', 168));
            var bloodGroups = manager.GetAll();
            foreach (var a in bloodGroups)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }
        private void Fetch()
        {
            Console.Write("Enter ID of Blood group: ");
            BloodGroups bloodGroup = manager.Get(int.Parse(Console.ReadLine()));
            Console.WriteLine(bloodGroup);
        }
    }
}
