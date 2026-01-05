using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;
using UnityEngine.UI;

public class StealWeaponWui : MonoBehaviour
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

	private float moveTime;

	public void Set(UnlockableBase unlockable, Transform target, Vector3 targetOffset, float hoverTime, float moveTime, float scale, bool useScaleDown = false)
	{
	}

	private void Update()
	{
	}
}
