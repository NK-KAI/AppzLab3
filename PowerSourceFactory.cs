namespace Lab2;

public class PowerSourceFactory
{
	private bool _electricity;
	private bool _isUps;
	private int _batteryCapacity;
	

	public void SetElectricity(bool enabled)
	{
		_electricity = enabled;
	}

	public void SetBattery(int capacity)
	{
		_batteryCapacity = capacity;
	}

	public void SetUps(bool enabled)
	{
		_isUps = enabled;
	}

	public PowerSource Build()
	{
		return new PowerSource(
			_electricity, 
			_batteryCapacity, 
			_isUps);
	}
}
