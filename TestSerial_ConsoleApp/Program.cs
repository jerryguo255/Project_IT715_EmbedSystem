using System;
using System.IO.Ports;

namespace TestSerial_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a list of serial port names.        
            string[] ports = SerialPort.GetPortNames();
            Console.WriteLine("The following serial ports were found:");
            foreach (string port in ports) { Console.WriteLine(port); }
            Console.ReadLine();
        }
    }
}
