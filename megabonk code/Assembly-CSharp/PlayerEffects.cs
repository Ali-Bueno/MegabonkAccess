using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
	public GameObject mirrorFx;

	public GameObject flexFx;

	public PlayerRenderer playerRenderer;

	public ParticleSystem dashPs;

	public ParticleSystem dashCloudPs;

	private ParticleSystem.EmissionModule dashEmission;

	private float dangerValue;

	private float dangerTarget;

	private float lastHp;

	private float timeLowHp;

	private const float dangerIncreaseSpeed = 4f;

	private const float dangerDecaySpeed = 0.02f;

	private const float sustainedLowThreshold = 15f;

	private const float lerpSpeed = 1.5f;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnCharacterSet(CharacterData characterData)
	{
	}

	private void Update()
	{
	}

	private void DashFx()
	{
	}

	private float RemapHpRatio(float hpRatio, float min, float max)
	{
		return 0f;
	}

	public float GetDangerRatio()
	{
		return 0f;
	}

	public float GetDangerRatioMusic()
	{
		return 0f;
	}

	private void OnMirrorReady(bool isReady)
	{
	}

	private void OnFlexReady(bool isReady)
	{
	}
}
