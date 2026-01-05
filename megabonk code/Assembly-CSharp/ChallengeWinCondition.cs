using UnityEngine;
using UnityEngine.Localization;

public abstract class ChallengeWinCondition : ScriptableObject
{
	public LocalizedString localizedString;

	private bool _003Ccompleted_003Ek__BackingField;

	public bool completed
	{
		get
		{
			return _003Ccompleted_003Ek__BackingField;
		}
		private set
		{
			_003Ccompleted_003Ek__BackingField = value;
		}
	}

	public abstract void Init(ChallengeData challengeData);

	public abstract void Cleanup();

	public void ChallengeCompleted()
	{
	}

	public string GetDescription()
	{
		return null;
	}
}
