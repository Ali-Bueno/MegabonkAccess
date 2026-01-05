using Assets.Scripts.Game.Spawning;
using TMPro;
using UnityEngine;

public class AlertUi : MonoBehaviour
{
	public TextMeshProUGUI t_alert;

	public AudioSource audio;

	public AudioClip c_swarm;

	public AudioClip c_finalSwarm;

	public AudioClip c_boss;

	public Color swarmColor;

	public Color swarmFinalColor;

	public Color bossColor;

	private float timer;

	private bool startedFade;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSwarmStarted()
	{
	}

	private void OnFinalSwarmStarted()
	{
	}

	private void OnNewWave(EWaveType waveType)
	{
	}

	public void SetAlertBoss()
	{
	}

	public void SetAlertTimesUp()
	{
	}

	public void SetAlert(EWaveType waveType)
	{
	}

	private void AnimateAlert()
	{
	}

	private void Update()
	{
	}

	private void StartFade()
	{
	}

	private void Disable()
	{
	}
}
