namespace Lab2
{
    public static class Program
    {
        public static void Main()
        {
            var deviceMode = "0";
            var electricityMode = "0";
            var batteryMode = "0";
            var upsMode = "0";
            var softMode = "0";
            var networkMode = "0";
            var audioMode = "0";
            var run = true;
            
            var deviceFactory = new DeviceFactory();
            var powerSourceFactory = new PowerSourceFactory();
            

            while (!new[] { "1", "2", "3" }.Contains(deviceMode))
            {
                Console.WriteLine("Create device to operate:");
                Console.WriteLine("1. Computer");
                Console.WriteLine("2. Laptop");
                Console.WriteLine("3. Phone");

                deviceMode = Console.ReadLine()!.Trim();

                switch (deviceMode)
                {
                    case "1":
                        deviceFactory.SetDeviceType("Computer");
                        break;
                    case "2":
                        deviceFactory.SetDeviceType("Laptop");
                        break;
                    case "3":
                        deviceFactory.SetDeviceType("Phone");
                        break;
                }
            }
            
            while (!new[] {"1", "2"}.Contains(electricityMode))
            {
                Console.WriteLine("Is it connected to electricity:");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                
                electricityMode = Console.ReadLine();
            }
            
            while (!new[] { "1", "2" }.Contains(upsMode))
            {
                Console.WriteLine("Is it connected to uninterruptible power supply:");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                
                upsMode = Console.ReadLine();
            }
            
            if (deviceMode != "1")
            {
                while (int.TryParse(batteryMode, out var n) != true)
                {
                    Console.WriteLine("Enter mAh of installed into device power source:");

                    batteryMode = Console.ReadLine()!.Trim();
                }
            }
            
            powerSourceFactory.SetElectricity(electricityMode == "1");
            powerSourceFactory.SetUps(upsMode == "1");
            powerSourceFactory.SetBattery(int.Parse(batteryMode));
            deviceFactory.SetPowerSource(powerSourceFactory.Build());
            
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
            
            deviceFactory.SetSoftware(softMode == "1");
            deviceFactory.SetNetwork(networkMode == "1");
            deviceFactory.SetAudioDevice(audioMode == "1");

            var device = deviceFactory.Build();
            
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
