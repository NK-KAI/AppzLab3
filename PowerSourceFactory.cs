namespace Lab2;

public class PowerSourceFactory
{
	private bool _electricity;
	private bool _isUps;
	private int _batteryCapacity;
	

	public void setElectricity(bool enabled)
	{
		_electricity = enabled;
	}

	public void setBattery(int capacity)
	{
		_batteryCapacity = capacity;
	}

	public void setUps(bool enabled)
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