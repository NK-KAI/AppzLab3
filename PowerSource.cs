namespace Lab2;

public class PowerSource
{
	public bool ElectricityAvailable { get; set; }
	public Battery? Battery { get; }
	public Ups? Ups { get; }

	public PowerSource(bool electricityAvailable, int batteryCapacity = 0, bool isUps = false)
	{
		ElectricityAvailable = electricityAvailable;
		Battery = new Battery(batteryCapacity);
		Ups = isUps ? new Ups() : null;
	}
	
	public bool HasSufficientPower(bool intensive)
	{
		if (ElectricityAvailable)
			return true;

		var availableTime = GetAvailableOperationTime(intensive);
		return availableTime > 0;
	}
	
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
