using UnityEngine.EventSystems;

namespace Rewired.Integration.UnityUI;

public class RewiredEventSystem : EventSystem
{
	private bool _alwaysUpdate;

	public bool alwaysUpdate
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	protected override void Update()
	{
	}
}
