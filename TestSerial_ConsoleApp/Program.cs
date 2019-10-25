using System;
using System.IO.Ports;

namespace TestSerial_ConsoleApp
{
    class Program
    {
      static   SerialPort _serialPort;
        static void Main(string[] args)
        {
            
            // Get a list of serial port names.===========        
            string[] ports = SerialPort.GetPortNames();
            Console.WriteLine("The following serial ports were found:");
            foreach (string portname in ports) { Console.WriteLine(portname); }
            Console.ReadLine();
            //=================================   

            Console.Write("Port no: ");
            string port = Console.ReadLine();
            Console.Write("baudrate: ");
            string baudrate = Console.ReadLine();

            // Create a new SerialPort on port COM7      
            _serialPort = new SerialPort(port, int.Parse(baudrate));

            // Set the read/write timeouts           
            _serialPort.ReadTimeout = 2000;
            _serialPort.Open();
            while (true)
            {
                Read();
            }
            _serialPort.Close();


        }

        static void Read() { 
            try { 
                string message = _serialPort.ReadLine(); 
                Console.WriteLine(message);
            } 
            catch (TimeoutException) 
            {

            } 
        }
    }
}
   
        


            
         