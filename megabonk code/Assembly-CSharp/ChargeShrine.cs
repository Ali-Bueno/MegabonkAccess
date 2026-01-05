using System;
using UnityEngine;
using UnityEngine.UI;

public class ChargeShrine : BaseInteractable
{
	private float chargeTime;

	private float currentChargeTime;

	private float chargeProgress;

	public Renderer zoneRenderer;

	public Renderer meshRenderer;

	public Transform runeStone;

	private MaterialPropertyBlock zonePropertyBlock;

	private MaterialPropertyBlock rendererPropertyBlock;

	private Color zoneColor;

	private Color startColor;

	public GameObject minimapIcon;

	public Image circleProgress;

	public CanvasGroup circleParent;

	public AudioSource audioStart;

	public AudioSource audioLoop;

	public AudioSource audioComplete;

	public AudioSource audioAbort;

	public GameObject finishParticles;

	public GameObject altarIcon;

	public GameObject healingZone;

	private bool notInterrupted;

	public static Action A_ChargeShrineSpawned;

	public static Action<bool> A_Charged;

	private float goldChance;

	private bool _003CisGolden_003Ek__BackingField;

	public Material goldMaterial;

	private bool wasLoopAudioPlayingWhenPaused;

	private float pitchStart;

	private float pitchEnd;

	private bool completed;

	private float rewardTime;

	private bool rewardGiven;

	public static ChargeShrine lastRewardShrine;

	private bool charging;

	private float volumeWhenExit;

	public static string debugName;

	public bool isGolden
	{
		get
		{
			return _003CisGolden_003Ek__BackingField;
		}
		private set
		{
			_003CisGolden_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	private new void OnDestroy()
	{
	}

	private new void Start()
	{
	}

	private void FindChargeTime()
	{
	}

	private void Update()
	{
	}

	private void OnPause(bool paused)
	{
	}

	private void Complete()
	{
	}

	private void ScorePopup()
	{
	}

	private void Reward()
	{
	}

	private void OnTriggerEnter()
	{
	}

	private void OnTriggerExit()
	{
	}

	public override bool Interact()
	{
		return false;
	}

	public override string GetInteractString()
	{
		return null;
	}

	public override bool CanInteract()
	{
		return false;
	}

	public override bool ShowInDebug()
	{
		return false;
	}

	public override string GetDebugName()
	{
		return null;
	}
}
