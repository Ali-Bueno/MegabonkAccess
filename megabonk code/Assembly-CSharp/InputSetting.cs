public class InputSetting : BetterSetting
{
	public KeyDisplay[] keyDisplays;

	private int listenSlot;

	private new void Awake()
	{
	}

	private new void OnDestroy()
	{
	}

	private void OnControllerChange(EControllerType controllerType)
	{
	}

	public override void ControllerInputDir(int dir, float multiplier)
	{
	}

	protected override void ShowValue()
	{
	}

	public void StartListening(int slot)
	{
	}

	public void SetKey(int keyCode)
	{
	}
}
