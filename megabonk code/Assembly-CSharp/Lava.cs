using System;
using UnityEngine;

public class Lava : MonoBehaviour
{
	private bool isCameraUnder;

	private bool isPlayerUnder;

	private bool isDamageZone;

	private MapData mapData;

	private StageData stageData;

	private Color _003Ccolor_003Ek__BackingField;

	public static Action A_CameraEnterWater;

	public static Action A_CameraExitWater;

	public static Action A_PlayerEnterWater;

	public static Action A_PlayerExitWater;

	public GameObject splashFx;

	private float nextDamageTime;

	private float damageInterval;

	private float damage;

	private string damageSource;

	private Collider collider;

	private Bounds bounds;

	private Vector3 lastPos;

	private float threshold;

	private float nextSplashTime;

	private float splashInterval;

	public Color color
	{
		get
		{
			return _003Ccolor_003Ek__BackingField;
		}
		private set
		{
			_003Ccolor_003Ek__BackingField = value;
		}
	}

	private void Start()
	{
	}

	private void UpdateBounds()
	{
	}

	private void CheckBounds()
	{
	}

	private void FixedUpdate()
	{
	}

	private void Update()
	{
	}
}
