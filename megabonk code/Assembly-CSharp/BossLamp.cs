using System;
using UnityEngine;
using UnityEngine.UI;

public class BossLamp : MonoBehaviour
{
	private float chargeTime;

	private float chargeProgress;

	public Renderer zoneRenderer;

	public Renderer lampRenderer;

	private MaterialPropertyBlock zonePropertyBlock;

	public Color zoneColor;

	private Color startColor;

	public Material lampPostMaterial;

	public Material lampPostMaterialOff;

	private float zoneRadius;

	private static int numPlayers;

	private bool hasPlayer;

	public GameObject minimapIcon;

	public GameObject altarIcon;

	public Image circleProgress;

	public CanvasGroup circleParent;

	public AudioSource audioStart;

	public AudioSource audioLoop;

	public AudioSource audioComplete;

	public AudioSource audioAbort;

	public GameObject light;

	public GameObject lampExplosionPrefab;

	public EffectPlayer finishedFx;

	public EffectPlayer randomGoOutEffect;

	private bool charging;

	private float pitchStart;

	private float pitchEnd;

	private bool isTurnedOn;

	public static Action A_Activate;

	public static Action A_Deactivate;

	private bool wasLoopAudioPlayingWhenPaused;

	private int randomDeactivateTimeMin;

	private int randomDeactivateTimeMax;

	private float timeToDeactivate;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public bool HasPlayer()
	{
		return false;
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

	public void Deactivate()
	{
	}

	private void OnTriggerEnter()
	{
	}

	private void FixedUpdate()
	{
	}

	private void CheckRandomDeactivate()
	{
	}

	private void ExtendRandomDeactivateTime()
	{
	}

	private void OnTriggerExit()
	{
	}
}
