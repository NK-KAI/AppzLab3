namespace Lab2;

// Клас для системи живлення
public class PowerSource
{
	// Якщо електроенергія є – немає обмежень
	public bool ElectricityAvailable { get; set; }
	public Battery? Battery { get; }
	public Ups? Ups { get; }

	public PowerSource(bool electricityAvailable, int batteryCapacity = 0, bool isUps = false)
	{
		ElectricityAvailable = electricityAvailable;
		Battery = new Battery(batteryCapacity);
		Ups = isUps ? new Ups() : null;
	}

	// Метод перевіряє, чи є достатньо живлення для операції (інтенсивність впливає на час роботи)
	public bool HasSufficientPower(bool intensive)
	{
		if (ElectricityAvailable)
			return true;

		var availableTime = GetAvailableOperationTime(intensive);
		Console.WriteLine(availableTime);
		return availableTime > 0;
	}

	// Повертає час роботи (в годинах) залежно від доступного джерела живлення
	private double GetAvailableOperationTime(bool intensive)
	{
		if (ElectricityAvailable)
			return double.PositiveInfinity;
		if (Battery != null)
		{
			var time = Battery.GetOperationTime(intensive);
			Console.WriteLine(time);
			if (time > 0)
				return time;
		}
		if (Ups != null)
			return Ups.RemainingOperationTime;
		return 0;
	}
}
