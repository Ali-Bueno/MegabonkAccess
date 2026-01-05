using System;
using MilkShake;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public enum ECameraState
	{
		Portal,
		Player3rd,
		Player1st,
		Death
	}

	public Vector3 offset3rdPerson;

	private float currentBob;

	private float desiredBob;

	public Shaker shaker;

	private ECameraState cameraState;

	public CameraOutlines cameraOutlines;

	public Camera camera;

	private bool inited;

	public static PlayerCamera Instance;

	private float defaultZ;

	private Transform portal;

	public bool isPortalCameraFocusingPlayer;

	private float currentZ;

	private float maxExtraZoomoutDistance;

	public bool useCenter;

	public Transform testingTarget;

	public Camera deathCamera;

	public RenderTexture deathRenderTexture;

	private float deathOffset;

	public static Action<GameObject> A_CameraFadeObjectEnter;

	private float cameraRadius;

	public float testDist;

	private void Awake()
	{
	}

	public void TryInit()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void AdjustCameraFar()
	{
	}

	public ECameraState GetCameraState()
	{
		return default(ECameraState);
	}

	private void Update()
	{
	}

	private void UpdateBob()
	{
	}

	public void SetCameraState(ECameraState state)
	{
	}

	public void CameraInput(Vector3 playerRotation)
	{
	}

	public void StartPortalCamera(Transform portal)
	{
	}

	public void StopPortalCamera()
	{
	}

	private void PortalCamera()
	{
	}

	public Vector3 GetPortalOffsetPosition(Vector3 portalForward)
	{
		return default(Vector3);
	}

	private void PlayerCam(Vector3 playerRotation)
	{
	}

	public void MovePositionOnly()
	{
	}

	private void DeathCam()
	{
	}

	private Vector3 GetPlayerHeadPosition()
	{
		return default(Vector3);
	}

	private Vector3 GetCameraPosition()
	{
		return default(Vector3);
	}

	private void CheckFadeObjects(Ray ray, float distance, float radius)
	{
	}

	public void DeathCamera()
	{
	}

	public void HideDeathCamera()
	{
	}

	private void OnPlayerLanded(float fallSpeed)
	{
	}

	private void BobOnce(float strength = 0.5f)
	{
	}

	private Vector3 GetBobOffset()
	{
		return default(Vector3);
	}

	private float Get3rdPersonOffset()
	{
		return 0f;
	}

	private Vector3 Get3rdPersonOffset(float zValue)
	{
		return default(Vector3);
	}

	private void OnSettingUpdated(string name, object oldValue, object newValue)
	{
	}

	public void SetFov(int fov)
	{
	}

	public void SetZoom(float ratio)
	{
	}

	private void UpdateZoom()
	{
	}
}
