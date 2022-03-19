using MedicalAppointments.Business;
using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointments.Presentation
{
    // Конзолно управление на записаните часове
    class AppointmentsDisplay
    {
        private AppointmentsManager manager = new AppointmentsManager();
        private const int backOperationCode = 6;

        public AppointmentsDisplay()
        {
            Console.WriteLine();
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 168));
            Console.WriteLine(new string(' ', 84) + "APPOINTMENTS MENU" + new string(' ', 84));
            Console.WriteLine(new string('-', 168));
            Console.WriteLine("1. List all Appointments");
            Console.WriteLine("2. Add a new Appointment");
            Console.WriteLine("3. Update an existing Appointment");
            Console.WriteLine("4. Fetch an Appointment by ID");
            Console.WriteLine("5. Delete an Appointment by ID");
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
            Console.WriteLine(new string(' ', 84) + "APPOINTMENTS" + new string(' ', 84));
            Console.WriteLine(new string('-', 168));
            var appointments = manager.GetAll();
            foreach(var a in appointments)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }
        private void Add() 
        {
            try
            { 
                Appointments appointment = new Appointments();
                Console.Write("Enter Patient ID: ");
                appointment.PatientId = int.Parse(Console.ReadLine());
                Console.Write("Enter Doctor ID: ");
                appointment.DoctorId = int.Parse(Console.ReadLine());
                Console.Write("Enter Date and time (dd/MM/yyyy hh:mm): ");
                string[] s = Console.ReadLine().Split(" ");
                string[] date = s[0].Split("/");
                string[] time = s[1].Split(":");
                appointment.TimeAndDate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]),
                                                       int.Parse(time[0]), int.Parse(time[1]), 0);
                manager.Add(appointment);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Appointment successfully added!\n");
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
        {   try
            {
                Console.Write("Enter ID of Appointment: ");
                Appointments appointment = manager.Get(int.Parse(Console.ReadLine()));
                Console.Write("Enter Patient ID: ");
                appointment.PatientId = int.Parse(Console.ReadLine());
                Console.Write("Enter Doctor ID: ");
                appointment.DoctorId = int.Parse(Console.ReadLine());
                Console.Write("Enter Date and time (dd/MM/yyyy hh:mm): ");
                string[] s = Console.ReadLine().Split(" ");
                string[] date = s[0].Split("/");
                string[] time = s[1].Split(":");
                appointment.TimeAndDate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]),
                                                       int.Parse(time[0]), int.Parse(time[1]), 0);
                manager.Update(appointment);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Appointment successfully updated!\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            } catch(Exception e)
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
                Console.Write("Enter ID of Appointment: ");
                Appointments appointment = manager.Get(int.Parse(Console.ReadLine()));
                Console.WriteLine(appointment);
            } catch(Exception e)
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
                Console.Write("Enter ID of Appointment: ");
                manager.Delete(int.Parse(Console.ReadLine()));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Appointment successfully deleted!\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }
        }
    }
}
