using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
	public TextMeshProUGUI t_timerRun;

	public TextMeshProUGUI t_timerStage;

	public TextMeshProUGUI t_timerSpeedrun;

	private float fontSizeDefault;

	private bool isRed;

	private ChallengeModifierSpeedrun speedrunModifier;

	private int lastRunMinutes;

	private int lastRunSeconds;

	private int lastStageMinutes;

	private int lastStageSeconds;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void UpdateTimers()
	{
	}

	private float GetForcedTime()
	{
		return 0f;
	}

	private void UpdateTimer(float time, TextMeshProUGUI textMesh, bool useClock, ref int lastMinutes, ref int lastSeconds, bool useSpeedrunModifier)
	{
	}
}
