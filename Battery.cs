namespace Lab2;

public class Battery
{
	private int CapacityInmAh { get; set; }
	public int RemainingCapacityInmAh { get; private set; }

	public Battery(int capacityInmAh)
	{
		CapacityInmAh = capacityInmAh;
		RemainingCapacityInmAh = capacityInmAh;
	}

	// Розрахунок доступного часу роботи з урахуванням залишкової місткості
	public double GetOperationTime(bool intensive)
	{
		return CapacityInmAh switch
		{
			>= 2000 and <= 3000 => intensive
				? 16 * RemainingCapacityInmAh / (double)CapacityInmAh
				: 48 * RemainingCapacityInmAh / (double)CapacityInmAh,
			>= 5000 and <= 7000 => intensive
				? 4 * RemainingCapacityInmAh / (double)CapacityInmAh
				: 12 * RemainingCapacityInmAh / (double)CapacityInmAh,
			_ => 0
		};
	}

	public int GetBatteryCapacity()
	{
		return CapacityInmAh;
	}

	public void SetCapacity(int capacityInmAh)
	{
		CapacityInmAh = capacityInmAh;
	}

	// Метод для симуляції розряду батареї за певний період роботи (в годинах)
	public void Consume(double hours, bool intensive)
	{
		var consumptionRate = CapacityInmAh switch
		{
			>= 2000 and <= 3000 => intensive ? (double)CapacityInmAh / 16 : (double)CapacityInmAh / 48,
			>= 5000 and <= 7000 => intensive ? (double)CapacityInmAh / 4 : (double)CapacityInmAh / 12,
			_ => 0
		};

		var consumed = (int)(consumptionRate * hours);
		RemainingCapacityInmAh -= consumed;
		if (RemainingCapacityInmAh < 0)
			RemainingCapacityInmAh = 0;
	}
}
