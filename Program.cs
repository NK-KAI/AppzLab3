using System;
using System.Text;

// Console.OutputEncoding = Encoding.UTF8;

namespace Lab1
{
    // Точка входу – демонстрація роботи пристроїв
    public class Program
    {
        public static void Main()
        {
            var deviceMode = "0";
            var electricityMode = "0";
            var batteryMode = "0";
            var upsMode = "1";
            var softMode = "0";
            var networkMode = "0";
            var audioMode = "0";
            var run = true;
            
            PowerSource powerSource = new PowerSource(false, new Battery(0));
            Device device = new Computer("0", powerSource);

            while (!new[] { "1", "2", "3" }.Contains(deviceMode))
            {
                Console.WriteLine("Create device to operate:");
                Console.WriteLine("1. Computer");
                Console.WriteLine("2. Laptop");
                Console.WriteLine("3. Phone");

                deviceMode = Console.ReadLine()!.Trim();
            }

            while (!new[] {"1", "2"}.Contains(electricityMode))
            {
                Console.WriteLine("Is it connected to electricity:");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                
                electricityMode = Console.ReadLine();
            }


            {
                while (!new[] { "1", "2" }.Contains(upsMode))
                {
                    Console.WriteLine("Is it connected to uninterruptible power supply:");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");
                    upsMode = Console.ReadLine();
                }
            }
            

            while (!new[] { "1", "2" }.Contains(batteryMode))
            {
                Console.WriteLine("Choose installed into device power source:");
                Console.WriteLine("1. Accumulator 2000-3000mAh");
                Console.WriteLine("2. Accumulator 5000-7000mAh");

                batteryMode = Console.ReadLine()!;
            }

            if (batteryMode == "1")
            {
                powerSource = new PowerSource(
                    electricityMode == "1", 
                    new Battery(2500),
                    upsMode == "1" ? null : new UPS());
            }
            else
            {
                powerSource = new PowerSource(
                    electricityMode == "1", 
                    new Battery(6000),
                    upsMode == "1" ? null : new UPS());
            }
            
            while (!new[] { "1", "2" }.Contains(softMode))
            {
                Console.WriteLine("Does it have a software installed:");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");

                softMode = Console.ReadLine()!;
            }
            
            while (!new[] { "1", "2" }.Contains(networkMode))
            {
                Console.WriteLine("Is it connected to network:");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");

                networkMode = Console.ReadLine()!;
            }
            
            while (!new[] { "1", "2" }.Contains(audioMode))
            {
                Console.WriteLine("Does it have a audio devices connected:");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");

                audioMode = Console.ReadLine()!;
            }

            switch (deviceMode)
            {
                case "1":
                    device = new Computer(name: "Personal Computer", powerSource)
                    {
                        HasSoftware = softMode == "1",
                        HasNetwork = networkMode == "1",
                        HasAudioDevice = audioMode == "1"
                    };
                    break;
                case "2":
                    device = new Laptop(name: "Laptop", powerSource)
                    {
                        HasSoftware = softMode == "1",
                        HasNetwork = networkMode == "1",
                        HasAudioDevice = audioMode == "1"
                    };
                    break;
                case "3":
                    device = new Smartphone(name: "Laptop", powerSource)
                    {
                        HasSoftware = softMode == "1",
                        HasNetwork = networkMode == "1",
                        HasAudioDevice = audioMode == "1"
                    };
                    break;
            }
            
            
            // device.Play();
            // device.Communicate();
            // device.ListenToMusic();
            // device.WatchVideo();
            while (run)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Work");
                Console.WriteLine("2. Play");
                Console.WriteLine("3. Communicate");
                Console.WriteLine("4. Listen to music");
                Console.WriteLine("5. Watch video");
                Console.WriteLine("6. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        device.Work();
                        break;
                    case "2":
                        device.Play();
                        break;
                    case "3":
                        device.Communicate();
                        break;
                    case "4":
                        device.ListenToMusic();
                        break;
                    case "5":
                        device.WatchVideo();
                        break;
                    case "6":
                        run = false;
                        break;
                }
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
