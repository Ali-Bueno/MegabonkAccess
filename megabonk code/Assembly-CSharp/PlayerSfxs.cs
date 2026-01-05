using UnityEngine;

public class PlayerSfxs : MonoBehaviour
{
	public static PlayerSfxs Instance;

	public RandomSfx sourceEvade;

	public RandomSfx sourceFlex;

	public RandomSfx slideStart;

	public AudioSource slideLoop;

	public AudioClip evade;

	public AudioClip evadePhantom;

	public AudioSource windAudio;

	private float maxVolume;

	private float maxPitch;

	private float minSpeed;

	private float maxSpeed;

	public GameObject grindFx;

	public RandomSfx sourceGrindAction;

	public RandomSfx sourceGrindLoop;

	public AudioClip grindStart;

	public AudioClip grindStop;

	private float avgSpeed;

	private bool wasPlayingGrind;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public void Evade(bool phantom)
	{
	}

	public void Flex()
	{
	}

	public void StartGrind()
	{
	}

	public void StopGrind()
	{
	}

	private void UpdateSliding()
	{
	}

	private void UpdateWind()
	{
	}

	private void OnPause(bool pause)
	{
	}
}
