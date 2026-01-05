using UnityEngine;

public class Shield : MonoBehaviour
{
	private Vector3 defaultScale;

	private float destroyTimer;

	private Renderer renderer;

	private Material shieldMaterial;

	public AudioSource sfx;

	private float defaultVolume;

	private float scaleTime;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnPickup(Pickup pickup)
	{
	}

	private void Update()
	{
	}

	private void UpdateAlpha(float alpha)
	{
	}
}
