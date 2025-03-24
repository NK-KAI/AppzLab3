namespace Lab1;

public class Battery
{
	public int CapacityInmAh { get; }
	public int RemainingCapacityInmAh { get; private set; }

	public Battery(int capacityInmAh)
	{
		CapacityInmAh = capacityInmAh;
		RemainingCapacityInmAh = capacityInmAh;
	}

	// Розрахунок доступного часу роботи з урахуванням залишкової місткості
	public double GetOperationTime(bool intensive)
	{
		if (CapacityInmAh is >= 2000 and <= 3000)
			return intensive
				? 16 * RemainingCapacityInmAh / (double)CapacityInmAh
				: 48 * RemainingCapacityInmAh / (double)CapacityInmAh;
		if (CapacityInmAh is >= 5000 and <= 7000)
			return intensive
				? 4 * RemainingCapacityInmAh / (double)CapacityInmAh
				: 12 * RemainingCapacityInmAh / (double)CapacityInmAh;
		return 0;
	}

	// Метод для симуляції розряду батареї за певний період роботи (в годинах)
	public void Consume(double hours, bool intensive)
	{
		double consumptionRate = 0;
		if (CapacityInmAh is >= 2000 and <= 3000)
			consumptionRate = intensive ? (double)CapacityInmAh / 16 : (double)CapacityInmAh / 48;
		else if (CapacityInmAh is >= 5000 and <= 7000)
			consumptionRate = intensive ? (double)CapacityInmAh / 4 : (double)CapacityInmAh / 12;
            
		int consumed = (int)(consumptionRate * hours);
		RemainingCapacityInmAh -= consumed;
		if (RemainingCapacityInmAh < 0)
			RemainingCapacityInmAh = 0;
	}
}
