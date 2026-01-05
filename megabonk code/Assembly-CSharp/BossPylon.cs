using System;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;
using UnityEngine.UI;

public class BossPylon : MonoBehaviour
{
	private Vector3 startPosition;

	private float chargeTime;

	private float chargeProgress;

	private MaterialPropertyBlock zonePropertyBlock;

	public Renderer zoneRenderer;

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

	public static Action<BossPylon> A_Charged;

	private Enemy boss;

	public LineRenderer laser;

	private int arcPointCount;

	private float arcHeight;

	private float moveTime;

	private Vector3 fromPos;

	private Vector3 toPos;

	public ParticleSystem moveFx;

	private float height;

	private float moveOverSeconds;

	private bool burying;

	private float currentChargeTime;

	private bool wasLoopAudioPlayingWhenPaused;

	private float pitchStart;

	private float pitchEnd;

	private bool completed;

	private bool charging;

	private float volumeWhenExit;

	public void Set(Enemy enemy)
	{
	}

	private void Update()
	{
	}

	private void DrawLaser()
	{
	}

	private void Surface()
	{
	}

	private void Bury()
	{
	}

	private void MoveUpdate()
	{
	}

	public void Despawn()
	{
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void Reset()
	{
	}

	private void FindChargeTime()
	{
	}

	private void ChargeUpdate()
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

	private void OnTriggerEnter()
	{
	}

	private void OnTriggerExit()
	{
	}
}
