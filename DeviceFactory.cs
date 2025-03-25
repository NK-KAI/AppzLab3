namespace Lab2;

public class DeviceFactory
{
	private bool _hasSoftware;
	private bool _hasNetwork;
	private bool _hasAudio;
	private PowerSource? _powerSource;
	private string _deviceType = "";
	
	public void SetSoftware(bool enable) => _hasSoftware = enable;
	public void SetNetwork(bool enable) => _hasNetwork = enable;
	public void SetAudioDevice(bool enable) => _hasAudio = enable;
	public void SetPowerSource(PowerSource powerSource) => _powerSource = powerSource;
	public void SetDeviceType(string deviceType) => _deviceType = deviceType;

	public Device Build()
	{
		Device device;
		switch (_deviceType)
		{
			case "Computer":
				device = new Computer("", _powerSource ?? new PowerSource(false));
				device.SetAudioDevice(_hasAudio);
				device.SetSoftware(_hasSoftware);
				device.SetNetwork(_hasNetwork);
				return device;
			case "Smartphone":
				device = new Smartphone("", _powerSource ?? new PowerSource(false));
				device.SetAudioDevice(_hasAudio);
				device.SetSoftware(_hasSoftware);
				device.SetNetwork(_hasNetwork);
				return device;
			case "Laptop":
				device = new Laptop("", _powerSource ?? new PowerSource(false));
				device.SetAudioDevice(_hasAudio);
				device.SetSoftware(_hasSoftware);
				device.SetNetwork(_hasNetwork);
				return device;
			default:
				throw new ArgumentOutOfRangeException();
			
			
		}
	}
	
}