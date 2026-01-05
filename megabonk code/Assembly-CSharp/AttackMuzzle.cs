using UnityEngine;

public class AttackMuzzle : MonoBehaviour
{
	public RandomSfx randomSfx;

	public ParticleSystem ps;

	private float cliplength;

	private float volumeMultiplier;

	public float minVolumeMultiplier;

	public float maxInterval;

	public float minAudioCooldown;

	private float lastPlayedTime;

	public void Set(int quantity, float burstInterval)
	{
	}

	public void Play()
	{
	}

	private void OnValidate()
	{
	}
}
