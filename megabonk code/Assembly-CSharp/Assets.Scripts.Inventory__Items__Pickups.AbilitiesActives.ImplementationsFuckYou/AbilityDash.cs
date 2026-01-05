using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesActives.ImplementationsFuckYou;

public class AbilityDash : ActiveAbility
{
	private float dashDuration;

	private float dashOverAtTime;

	private bool isDashing;

	private Vector3 dashDir;

	private Vector3 preDashVel;

	private float dashSpeed;

	private float dashSpeedToUse;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public override void UseImplementation()
	{
	}

	private void DashFinished()
	{
	}

	public override void Tick()
	{
	}

	public override float GetCooldown()
	{
		return 0f;
	}
}
