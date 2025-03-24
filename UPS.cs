namespace Lab1;

public class UPS
{
	// Максимальний час роботи UPS (годин)
	public double MaxOperationTime { get; } = 0.5;
	// Поточний залишок часу роботи
	public double RemainingOperationTime { get; private set; }

	public UPS()
	{
		RemainingOperationTime = MaxOperationTime;
	}

	// Симуляція споживання заряду UPS (годин)
	public void Consume(double hours)
	{
		RemainingOperationTime -= hours;
		if (RemainingOperationTime < 0)
			RemainingOperationTime = 0;
	}

	// Повне відновлення заряду UPS
	public void Recharge()
	{
		RemainingOperationTime = MaxOperationTime;
	}
}
