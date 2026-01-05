using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalSwarmSilverUi : MonoBehaviour
{
	public Transform coin;

	public TextMeshProUGUI t_silverMultiplier;

	public TextMeshProUGUI t_difficulty;

	public RawImage progressBar;

	public Image outlineGlow;

	private Material outlineGlowMat;

	private string modifierName;

	public GameObject contentParent;

	private float maxTime;

	private float maxMultiplier;

	private float lastMultiplier;

	private float nextCheckTime;

	private float checkInterval;

	public Gradient colorGradient;

	public float testTime;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void RemoveSilverMultiplier()
	{
	}

	private void OnFinalSwarmStarted()
	{
	}

	private void OnFinalSwarmStopped()
	{
	}

	private void Update()
	{
	}

	private void UpdateMultiplier()
	{
	}

	private Color GetColor(float lerpValue)
	{
		return default(Color);
	}

	private float GetSwarmTime()
	{
		return 0f;
	}

	private float GetTimerLerp()
	{
		return 0f;
	}

	private string GetDifficultyText(float lerpValue)
	{
		return null;
	}

	private void OnPlayerInventoryInitialized(PlayerInventory pInv)
	{
	}
}
