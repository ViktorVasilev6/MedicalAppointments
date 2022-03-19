using MedicalAppointments.Business;
using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointments.Presentation
{
    // Конзолно управление за пациентите
    class PatientsDisplay
    {
        private PatientsManager manager = new PatientsManager();
        private const int backOperationCode = 6;

        public PatientsDisplay()
        {
            Console.WriteLine();
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 168));
            Console.WriteLine(new string(' ', 84) + "PATIENTS MENU" + new string(' ', 84));
            Console.WriteLine(new string('-', 168));
            Console.WriteLine("1. List all Patients");
            Console.WriteLine("2. Add a new Patient");
            Console.WriteLine("3. Update an existing Patient");
            Console.WriteLine("4. Fetch a Patient by ID");
            Console.WriteLine("5. Delete a Patient by ID");
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
                // Избор на операция, според въведеното от потребителя
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
            Console.WriteLine(new string(' ', 84) + "PATIENTS" + new string(' ', 84));
            Console.WriteLine(new string('-', 168));
            var patients = manager.GetAll();
            foreach (var a in patients)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        private void Add()
        {
            try
            {
                Patients patient = new Patients();
                Console.Write("Enter Patient first name: ");
                patient.FirstName = Console.ReadLine();
                Console.Write("Enter patient last name: ");
                patient.LastName = Console.ReadLine();
                Console.Write("Enter Patient birthdate (dd/MM/yyyy): ");
                string[] date = Console.ReadLine().Split("/");
                patient.Birthdate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                Console.Write("Enter Blood Group ID: ");
                patient.BloodGroupId = int.Parse(Console.ReadLine());
                Console.Write("Enter Patient Diagnose: ");
                patient.Diagnose = Console.ReadLine();
                manager.Add(patient);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Patient successfully added!\n");
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
                Console.Write("Enter ID of Patient: ");
                Patients patient = manager.Get(int.Parse(Console.ReadLine()));
                Console.Write("Enter Patient first name: ");
                patient.FirstName = Console.ReadLine();
                Console.Write("Enter patient last name: ");
                patient.LastName = Console.ReadLine();
                Console.Write("Enter Patient birthdate (dd/MM/yyyy): ");
                string[] date = Console.ReadLine().Split("/");
                patient.Birthdate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                Console.Write("Enter Blood Group ID: ");
                patient.BloodGroupId = int.Parse(Console.ReadLine());
                Console.Write("Enter Patient Diagnose: ");
                patient.Diagnose = Console.ReadLine();
                manager.Update(patient);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Patient successfully updated!\n");
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
                Console.Write("Enter ID of Patient: ");
                Patients patient = manager.Get(int.Parse(Console.ReadLine()));
                Console.WriteLine(patient);
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
                Console.Write("Enter ID of Patient: ");
                manager.Delete(int.Parse(Console.ReadLine()));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Patient successfully deleted!\n");
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
