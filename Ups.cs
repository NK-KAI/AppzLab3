namespace Lab2;

public class Ups
{
	public Ups()
	{
		RemainingOperationTime = MaxOperationTime;
	}

	// Максимальний час роботи UPS (годин)
	private double MaxOperationTime { get; } = 0.5;

	// Поточний залишок часу роботи
	public double RemainingOperationTime { get; private set; }

	// Симуляція споживання заряду UPS (годин)
	public void Consume(double hours)
	{
		RemainingOperationTime -= hours;
		if (RemainingOperationTime < 0)
			RemainingOperationTime = 0;
	}
}
