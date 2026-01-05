namespace Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeModifiers;

public class ChallengeModifierNoDamage : ChallengeModifier
{
	private bool hasBeenCalled;

	private bool hasBeenKilled;

	public override void Init(ChallengeData challengeData)
	{
	}

	public override void Cleanup()
	{
	}

	private void OnDamagePlayer()
	{
	}

	public override void Tick()
	{
	}
}
