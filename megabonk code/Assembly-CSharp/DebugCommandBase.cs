using System;

public class DebugCommandBase
{
	private string _003CcommandId_003Ek__BackingField;

	private string _003CcommandDescription_003Ek__BackingField;

	private string _003CcommandFormat_003Ek__BackingField;

	public Type commandType;

	public string commandId
	{
		get
		{
			return _003CcommandId_003Ek__BackingField;
		}
		private set
		{
			_003CcommandId_003Ek__BackingField = value;
		}
	}

	public string commandDescription
	{
		get
		{
			return _003CcommandDescription_003Ek__BackingField;
		}
		private set
		{
			_003CcommandDescription_003Ek__BackingField = value;
		}
	}

	public string commandFormat
	{
		get
		{
			return _003CcommandFormat_003Ek__BackingField;
		}
		private set
		{
			_003CcommandFormat_003Ek__BackingField = value;
		}
	}

	public DebugCommandBase(string id, string description, string format, Type commandType)
	{
	}
}
