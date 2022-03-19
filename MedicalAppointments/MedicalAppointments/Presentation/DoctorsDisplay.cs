using MedicalAppointments.Business;
using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointments.Presentation
{
    class DoctorsDisplay
    {
        private DoctorsManager manager = new DoctorsManager();
        private const int backOperationCode = 6;
        private const string stringNull = null;

        public DoctorsDisplay()
        {
            Console.WriteLine();
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 168));
            Console.WriteLine(new string(' ', 84) + "DOCTORS MENU" + new string(' ', 84));
            Console.WriteLine(new string('-', 168));
            Console.WriteLine("1. List all Doctors");
            Console.WriteLine("2. Add a new Doctor");
            Console.WriteLine("3. Update an existing Doctor");
            Console.WriteLine("4. Fetch a Doctor by ID");
            Console.WriteLine("5. Delete a Doctor by ID");
            Console.WriteLine("6. Back");
            Console.Write("Choose (1-6): ");
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
                        Add();
                        break;
                    case 3:
                        Console.WriteLine();
                        Update();
                        break;
                    case 4:
                        Console.WriteLine();
                        Fetch();
                        break;
                    case 5:
                        Console.WriteLine();
                        Delete();
                        break;
                }
            } while (op != backOperationCode);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 168));
            Console.WriteLine(new string(' ', 84) + "DOCTORS" + new string(' ', 84));
            Console.WriteLine(new string('-', 168));
            var doctors = manager.GetAll();
            foreach (var a in doctors)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        private void Add()
        {
            try
            {
                Doctors doctor = new Doctors();
                Console.Write("Enter Doctor first name: ");
                doctor.FirstName = Console.ReadLine();
                Console.Write("Enter Doctor last name: ");
                doctor.LastName = Console.ReadLine();
                Console.Write("Enter Doctor specialty: ");
                doctor.Specialty = Console.ReadLine();
                Console.Write("Enter Doctor special position (optional): ");
                string s = Console.ReadLine();
                doctor.SpecialPosition = (s == "" ? Convert.ToString(stringNull) : s);
                Console.Write("Enter Doctor academic degree (optional): ");
                s = Console.ReadLine();
                doctor.AcademicDegree = (s == "" ? Convert.ToString(stringNull) : s);
                Console.Write("Enter Doctor Center ID: ");
                doctor.CenterId = int.Parse(Console.ReadLine());
                manager.Add(doctor);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Doctor successfully added!\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            } catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }
        }
        private void Update()
        {
            try
            {
                Console.Write("Enter ID of Doctor: ");
                Doctors doctor = manager.Get(int.Parse(Console.ReadLine()));
                Console.Write("Enter Doctor first name: ");
                doctor.FirstName = Console.ReadLine();
                Console.Write("Enter Doctor last name: ");
                doctor.LastName = Console.ReadLine();
                Console.Write("Enter Doctor specialty: ");
                doctor.Specialty = Console.ReadLine();
                Console.Write("Enter Doctor special position (optional): ");
                string s = Console.ReadLine();
                doctor.SpecialPosition = (s == "" ? Convert.ToString(stringNull) : s);
                Console.Write("Enter Doctor academic degree (optional): ");
                s = Console.ReadLine();
                doctor.AcademicDegree = (s == "" ? Convert.ToString(stringNull) : s);
                Console.Write("Enter Doctor Center ID: ");
                doctor.CenterId = int.Parse(Console.ReadLine());
                manager.Update(doctor);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Doctor successfully updated!\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            } catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }
        }
        private void Fetch()
        {
            try
            {
                Console.Write("Enter ID of Doctor: ");
                Doctors doctor = manager.Get(int.Parse(Console.ReadLine()));
                Console.WriteLine(doctor);
            } catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }
        }
        private void Delete()
        {
            try
            {
                Console.Write("Enter ID of Doctor: ");
                manager.Delete(int.Parse(Console.ReadLine()));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Doctor successfully deleted!\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            } catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }
        }
    }
}
