using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;
using UnityEngine.UI;

public class ReturnWeaponWui : MonoBehaviour
{
	public RawImage icon;

	private Transform target;

	private Vector3 targetOffset;

	private float scale;

	private bool useScaleDown;

	private int phase;

	private float timer;

	private float moveUpTimer;

	private float moveUpTime;

	private float floatAbovePlayerHeadTime;

	private float scaleDownTime;

	public void Set(UnlockableBase unlockable)
	{
	}

	private void Update()
	{
	}
}
