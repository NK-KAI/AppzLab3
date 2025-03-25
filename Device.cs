namespace Lab2;
 
public abstract class Device
    {
        private string Name { get; }
        private bool HasSoftware { get; set; }
        private bool HasNetwork { get; set; }
        private bool HasAudioDevice { get; set; }
        private PowerSource Power { get; }

        // Конструктор з композицією компонентів
        protected Device(string name, PowerSource power)
        {
            Name = name;
            Power = power;
        }

        public void SetSoftware(bool enabled)
        {
            HasSoftware = enabled;
        }

        public void SetNetwork(bool enabled)
        {
            HasNetwork = enabled;
        }

        public void SetAudioDevice(bool enabled)
        {
            HasAudioDevice = enabled;
        }
        
        private void ExecuteOperation(string operationName, bool requiresSoftware, 
                                      bool requiresNetwork, bool requiresAudio, bool isIntensive)
        {
            Console.WriteLine($" Trying \"{operationName}\":");
            

            if (requiresSoftware && !HasSoftware)
            {
                Console.WriteLine("  Impossible to execute operation: no required software installed.");
                return;
            }
            if (requiresNetwork && !HasNetwork)
            {
                Console.WriteLine("  Impossible to execute operation: no network connection.");
                return;
            }
            if (requiresAudio && !HasAudioDevice)
            {
                Console.WriteLine("  Impossible to execute operation: no audio device.");
                return;
            }
            if (!Power.HasSufficientPower(isIntensive))
            {
                Console.WriteLine("  Impossible to execute operation: insufficient power.");
                return;
            }
            
            
            // Якщо електроенергії немає і використовується батарея – симулюємо розряджання
            if (!Power.ElectricityAvailable)
            {
                if (Power.Battery != null)
                {
                    // Припустимо, що кожна операція триває 1 годину
                    Power.Battery.Consume(1, isIntensive);
                    Console.WriteLine($"  Remaining capacity of battery: {Power.Battery.RemainingCapacityInmAh} mAh");
                }
                else if (Power.Ups != null)
                {
                    // Споживання UPS за 1 годину
                    Power.Ups.Consume(1);
                    Console.WriteLine($"  Remaining operation time for UPS: {Power.Ups.RemainingOperationTime} h");
                }
            }
            Console.WriteLine($"  Operation \"{operationName}\" were executed successfully.");
        }

        // Реалізація операцій, спираючись на спільні передумови
        public void Work() => ExecuteOperation("Work", requiresSoftware: true, requiresNetwork: false, requiresAudio: false, isIntensive: false);
        public void Play() => ExecuteOperation("Game", requiresSoftware: true, requiresNetwork: false, requiresAudio: false, isIntensive: true);
        public void Communicate() => ExecuteOperation("Communication", requiresSoftware: true, requiresNetwork: true, requiresAudio: false, isIntensive: false);
        public void ListenToMusic() => ExecuteOperation("Music listening", requiresSoftware: false, requiresNetwork: false, requiresAudio: true, isIntensive: false);
        public void WatchVideo() => ExecuteOperation("Video watching", requiresSoftware: true, requiresNetwork: false, requiresAudio: false, isIntensive: true);
        public void ConnectCharger() => Power.Battery?.SetCapacity(Power.Battery.GetBatteryCapacity());
}


public class Computer: Device
{
    public Computer(string name, PowerSource power) 
        : base(name, power) { }
}

public class Laptop : Device
{
    public Laptop(string name, PowerSource power)
        : base(name, power) { }
}

public class Smartphone : Device
{
    public Smartphone(string name, PowerSource power)
        : base(name, power) { }
}
