using MilkShake;
using UnityEngine;

public class DungeonPressurePlate : MonoBehaviour
{
	private bool opened;

	public GameObject blocker;

	public AudioSource sfxPlate;

	public AudioSource sfxBlocker;

	public ShakePreset shakePreset;

	private Vector3 startPos;

	private Vector3 endPos;

	private float progressTimer;

	private float progressDuration;

	private void OnTriggerEnter(Collider other)
	{
	}

	private void Move()
	{
	}

	private void FinishMove()
	{
	}

	private void Update()
	{
	}
}
