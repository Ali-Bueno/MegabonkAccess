public class ChallengeModifierSpeedrun : ChallengeModifier
{
	public float timeLimitMinutes;

	private bool isFinalBossKilled;

	private float _003CtimeLeftOnStage_003Ek__BackingField;

	public float timeLeftOnStage
	{
		get
		{
			return _003CtimeLeftOnStage_003Ek__BackingField;
		}
		private set
		{
			_003CtimeLeftOnStage_003Ek__BackingField = value;
		}
	}

	public override void Init(ChallengeData challengeData)
	{
	}

	public override void Cleanup()
	{
	}

	private void OnFinalBossDefeated(bool obj)
	{
	}

	private void OnStageBossDied(bool obj)
	{
	}

	private void OnStageStarted()
	{
	}

	public override void Tick()
	{
	}
}
