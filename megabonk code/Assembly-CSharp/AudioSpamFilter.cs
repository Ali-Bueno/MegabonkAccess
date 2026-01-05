using System.Collections.Generic;
using UnityEngine;

public class AudioSpamFilter : MonoBehaviour
{
	private class SpamFilterContainer
	{
		public bool isMuted;

		public float unmuteTime;

		public float lastPlayedTime;
	}

	public AudioSource audioSource;

	public RandomSfx randomSfx;

	private static Dictionary<string, SpamFilterContainer> spamFilter;

	public float spamDelay;

	private string id;

	private bool isStringInit;

	public float minVolumeMultiplier;

	public float maxInterval;

	public float overrideMinInterval;

	public void OnEnable()
	{
	}

	public static float FindVolumeMultiplier(float minInterval, float maxInterval, float interval, float minVolumeMultiplierValue, bool log = false)
	{
		return 0f;
	}

	private void OnValidate()
	{
	}
}
