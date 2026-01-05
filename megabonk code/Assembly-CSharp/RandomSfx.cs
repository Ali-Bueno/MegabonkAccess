using UnityEngine;

public class RandomSfx : MonoBehaviour
{
	public AudioClip[] sounds;

	public float maxPitch;

	public float minPitch;

	public float randomVolume;

	public AudioSource s;

	public bool playOnAwake;

	private float defaultVolume;

	private void Awake()
	{
	}

	private void Init()
	{
	}

	public void Play(float delay = 0f, float volumeMultiplier = 1f)
	{
	}

	public void Stop()
	{
	}

	private void OnValidate()
	{
	}
}
