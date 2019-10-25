//using System.Data.Entity;
using System;
using System.IO.Ports;
using System.Threading;

namespace TestSerial_ConsoleApp
{
    class Program
    {
        static SerialPort _serialPort;
        static bool _notCollected = true;
        static void Main(string[] args)
        {

            //// Get a list of serial port names.===========        
            //string[] ports = SerialPort.GetPortNames();
            //Console.WriteLine("The following serial ports were found:");
            //foreach (string portname in ports) { Console.WriteLine(portname); }
            //Console.ReadLine();
            ////=================================   

            //Console.Write("Port no: ");
            //string port = Console.ReadLine();
            //Console.Write("baudrate: ");
            //string baudrate = Console.ReadLine();

            // Create a new SerialPort on port COM7      
            _serialPort = new SerialPort("/dev/ttyUSB0", 9600);

            // Set the read/write timeouts           
            _serialPort.ReadTimeout = 2000;
            _serialPort.Open();
            while (true)
            {
                Read();
                Thread.Sleep(2000);
            }
            //_serialPort.Close();


        }

        static void Read()
        {
            string data;
            DateTime dt = DateTime.Now;
            int m = dt.Minute;
            int s = dt.Second;

            data = _serialPort.ReadLine();
            Console.Write(data);
            Console.WriteLine("  Min: "+m+" Sec: "+s);

            if (m != 5 && m != 15 && m != 25 && m != 35 && m != 45 && m != 55)
            {
                _notCollected = true;
            }
            else 
            {
                if (_notCollected)//if data not collected yet
                {
                    using (var context = new WeatherRecordDBContext())
                    {
                        string[] words = data.Split(" ");
                        var wr = new WeatherRecord()
                        {
                            DateCollection = DateTime.Now,
                            TempOutside = double.Parse(words[0]),
                            HumOutside = double.Parse(words[1]),
                            TempIndoor = double.Parse(words[2]),
                            HumIndoor = double.Parse(words[3])

                        };
                        context.WeatherRecords.Add(wr);
                        context.SaveChanges();
                        _notCollected = false;
                        Console.WriteLine("Saved into DB !");
                    }
                }
            }






        }
    }
}





