namespace Assets.Scripts.Game.Combat;

public static class CombatScaling
{
	private static float speedMultiplicationPerMinute;

	private static float hpMultiplicationPerMinute;

	private static float damageMultiplicationPerMinute;

	private static float knockbackResistancePerMinute;

	private static float stageSpeedMultiplier;

	private static float stageDamageMultiplier;

	private static float stageKnockbackResMultiplier;

	private static float GetMinutes()
	{
		return 0f;
	}

	public static float GetStageMultiplier()
	{
		return 0f;
	}

	public static float GetStageSpeedMultiplier()
	{
		return 0f;
	}

	public static float GetStageHpMultiplier()
	{
		return 0f;
	}

	public static float GetStageDamageMultiplier()
	{
		return 0f;
	}

	public static float GetSpeedMultiplierAddition(out float baseAddition, out float swarmAddition, out float stageAddition)
	{
		baseAddition = default(float);
		swarmAddition = default(float);
		stageAddition = default(float);
		return 0f;
	}

	public static float GetHpMultiplierAddition(out float baseAddition, out float swarmAddition, out float stageAddition)
	{
		baseAddition = default(float);
		swarmAddition = default(float);
		stageAddition = default(float);
		return 0f;
	}

	public static float GetDamageMultiplierAddition(out float baseAddition, out float swarmAddition, out float stageAddition)
	{
		baseAddition = default(float);
		swarmAddition = default(float);
		stageAddition = default(float);
		return 0f;
	}

	public static float GetKnockbackResistanceMultiplierAddition(out float baseAddition, out float swarmAddition, out float stageAddition)
	{
		baseAddition = default(float);
		swarmAddition = default(float);
		stageAddition = default(float);
		return 0f;
	}

	public static float GetFinalSwarmMultiplier()
	{
		return 0f;
	}

	public static float GetFinalSwarmHpMultiplier()
	{
		return 0f;
	}

	public static float GetFinalSwarmDamageMultiplier()
	{
		return 0f;
	}

	public static float GetSwarmSpeedMultiplier()
	{
		return 0f;
	}
}
