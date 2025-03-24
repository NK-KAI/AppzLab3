namespace Lab1;

// Клас для системи живлення
public class PowerSource
{
	// Якщо електроенергія є – немає обмежень
	public bool ElectricityAvailable { get; set; }
	public Battery? Battery { get; }
	public UPS? Ups { get; }

	public PowerSource(bool electricityAvailable, Battery? battery = null, UPS? ups = null)
	{
		ElectricityAvailable = electricityAvailable;
		Battery = battery;
		Ups = ups;
	}

	// Метод перевіряє, чи є достатньо живлення для операції (інтенсивність впливає на час роботи)
	public bool HasSufficientPower(bool intensive)
	{
		if (ElectricityAvailable)
			return true;

		double availableTime = GetAvailableOperationTime(intensive);
		Console.WriteLine(availableTime);
		return availableTime > 0;
	}

	// Повертає час роботи (в годинах) залежно від доступного джерела живлення
	public double GetAvailableOperationTime(bool intensive)
	{
		if (ElectricityAvailable)
			return double.PositiveInfinity;
		if (Battery != null)
		{
			double time = Battery.GetOperationTime(intensive);
			if (time > 0)
				return time;
		}
		if (Ups != null)
			return Ups.RemainingOperationTime;
		return 0;
	}
}
