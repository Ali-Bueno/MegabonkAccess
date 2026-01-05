using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource xp;

	public AudioSource gold;

	public AudioSource silver;

	public AudioSource dungeonDoorEnter;

	private float xpPitch;

	private float xpPitchDefault;

	private float xpPitchMax;

	private float baseXpVolume;

	private float baseGoldVolume;

	public RandomSfx uiClick;

	public RandomSfx uiSelect;

	public RandomSfx uiInputSet;

	public RandomSfx uiAbort;

	public RandomSfx customSfx;

	public RandomSfx purchaseSfx;

	public RandomSfx bullseye;

	public RandomSfx newMenuButton;

	public static AudioManager Instance;

	private float xpAndGoldVolume;

	private int xpPerInterval;

	private int goldPerInterval;

	private float interval;

	private float nextIntervalCheck;

	private int maxPerInterval;

	private int minPerInterval;

	private float xpVolumeMultiplier;

	private float goldVolumeMultiplier;

	private float nextMenuSelectTime;

	private float nextMenuEnterTime;

	private float minSelectInterval;

	private bool queueSelect;

	private bool queueEnter;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSettingUpdate(string settingName, object oldValue, object newValue)
	{
	}

	private void UpdateVolumes()
	{
	}

	public void PlayXp()
	{
	}

	public void PlayGold()
	{
	}

	public void PlaySilver()
	{
	}

	public void PlayNewMenuButton()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	public void PlayButtonSelect()
	{
	}

	public void PlayButtonEnter()
	{
	}

	public void PlaySfx(AudioClip clip)
	{
	}

	public void Bullseye()
	{
	}

	public void PlayDungeonDoorEnter()
	{
	}
}
