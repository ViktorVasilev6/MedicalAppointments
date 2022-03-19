using MedicalAppointments.Business;
using MedicalAppointments.Data;
using MedicalAppointments.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointments.Presentation
{
    // Конзолно управление за медицинските заведения
    class MedicalCentersDisplay
    {
        private MedicalCentersManager manager = new MedicalCentersManager();
        private const int backOperationCode = 6;
        private const string stringNull = null;

        public MedicalCentersDisplay()
        {
            Console.WriteLine();
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 168));
            Console.WriteLine(new string(' ', 84) + "MEDICAL CENTERS MENU" + new string(' ', 84));
            Console.WriteLine(new string('-', 168));
            Console.WriteLine("1. List all Medical centers");
            Console.WriteLine("2. Add a new Medical center");
            Console.WriteLine("3. Update an existing Medical center");
            Console.WriteLine("4. Fetch a Medical center by ID");
            Console.WriteLine("5. Delete a Medical center by ID");
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
            Console.WriteLine(new string(' ', 84) + "MEDICAL CENTERS" + new string(' ', 84));
            Console.WriteLine(new string('-', 168));
            var medicalCenters = manager.GetAll();
            foreach (var mc in medicalCenters)
            {
                Console.WriteLine(mc);
            }
        }
        private void Add() 
        {
            try
            {
                MedicalCenters center = new MedicalCenters();
                Console.Write("Enter Medical center name: ");
                center.CenterName = Console.ReadLine();
                Console.Write("Enter Medical center address: ");
                center.CenterAddress = Console.ReadLine();
                Console.Write("Enter Medical center phone number (optional): ");
                string s = Console.ReadLine();
                center.PhoneNumber = (s == "" ? Convert.ToString(stringNull) : s);
                Console.Write("Enter Medical center type ID: ");
                center.CenterTypeId = int.Parse(Console.ReadLine());
                manager.Add(center);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Medical center successfully added!\n");
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
                Console.Write("Enter ID of Medical center: ");
                MedicalCenters center = manager.Get(int.Parse(Console.ReadLine()));
                Console.Write("Enter Medical center name: ");
                center.CenterName = Console.ReadLine();
                Console.Write("Enter Medical center address: ");
                center.CenterAddress = Console.ReadLine();
                Console.Write("Enter Medical center phone number (optional): ");
                string s = Console.ReadLine();
                center.PhoneNumber = (s == "" ? Convert.ToString(stringNull) : s);
                Console.Write("Enter Medical center type ID: ");
                center.CenterTypeId = int.Parse(Console.ReadLine());
                manager.Update(center);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Medical center successfully updated!\n");
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
                Console.Write("Enter ID of Medical center: ");
                MedicalCenters center = manager.Get(int.Parse(Console.ReadLine()));
                Console.WriteLine(center);
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
                Console.Write("Enter ID of Medical center: ");
                manager.Delete(int.Parse(Console.ReadLine()));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Medical center successfully deleted!\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }  catch (FormatException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }
        }
    }
}

