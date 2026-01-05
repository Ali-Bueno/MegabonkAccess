using UnityEngine;

public class ObjectiveArrow : MonoBehaviour
{
	private Vector3 offset;

	public Transform tutorialArrow;

	public RectTransform canvasRect;

	private Transform _003Ctarget_003Ek__BackingField;

	private float hideAtDistance;

	private float timeout;

	private float targetAtTime;

	private float minTime;

	private float scaleMultiplier;

	private Vector3 targetSize;

	private Vector3 fromScale;

	private float timer;

	private float scaleTime;

	public Transform target
	{
		get
		{
			return _003Ctarget_003Ek__BackingField;
		}
		set
		{
			_003Ctarget_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	public void SetTarget(Transform t, Vector3 offset, float hideAtDistance, float timeout, float scaleMultiplier = 1f)
	{
	}

	public void ClearTarget()
	{
	}

	private void Show()
	{
	}

	private void Hide()
	{
	}

	private bool IsHidden()
	{
		return false;
	}

	private void UpdateSize()
	{
	}

	private void Update()
	{
	}

	private void TargetFollowItem()
	{
	}

	private Vector3 calculateWorldPosition(Vector3 position, Camera camera)
	{
		return default(Vector3);
	}
}
