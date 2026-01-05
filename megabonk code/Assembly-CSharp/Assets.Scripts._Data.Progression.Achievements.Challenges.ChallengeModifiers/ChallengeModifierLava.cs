using UnityEngine;

namespace Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeModifiers;

public class ChallengeModifierLava : ChallengeModifier
{
	private GameObject lavaObject;

	private Vector3 topPosition;

	private Vector3 lowPosition;

	private float riseTime;

	private float stayTop;

	private float lowerTime;

	private float stayBottom;

	private float cycleDuration;

	private float startDelay;

	private float startTime;

	public override void Init(ChallengeData challengeData)
	{
	}

	public override void Cleanup()
	{
	}

	private void OnGenerationComplete()
	{
	}

	public override void Tick()
	{
	}
}
