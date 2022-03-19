using MedicalAppointments.Data.Models;
using MedicalAppointments.Presentation;
using System;
using System.Linq;

namespace MedicalAppointments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("  __  __          _ _           _                              _       _                        _       ");
            Console.WriteLine(" |  \\/  |        | (_)         | |     /\\                     (_)     | |                      | |      ");
            Console.WriteLine(" | \\  / | ___  __| |_  ___ __ _| |    /  \\   _ __  _ __   ___  _ _ __ | |_ _ __ ___   ___ _ __ | |_ ___ ");
            Console.WriteLine(" | |\\/| |/ _ \\/ _` | |/ __/ _` | |   / /\\ \\ | '_ \\| '_ \\ / _ \\| | '_ \\| __| '_ ` _ \\ / _ \\ '_ \\| __/ __| ");
            Console.WriteLine(" | |  | |  __/ (_| | | (_| (_| | |  / ____ \\| |_) | |_) | (_) | | | | | |_| | | | | |  __/ | | | |_\\__ \\");
            Console.WriteLine(" |_|  |_|\\___|\\__,_|_|\\___\\__,_|_| /_/    \\_\\ .__/| .__/ \\___/|_|_| |_|\\__|_| |_| |_|\\___|_| |_|\\__|___/");
            Console.WriteLine("                                            | |   | |                                                   ");
            Console.WriteLine("                                            |_|   |_|                                                   ");
            Console.ForegroundColor = ConsoleColor.Gray;
            new Display();
            Environment.Exit(0);
        }
    }
}
