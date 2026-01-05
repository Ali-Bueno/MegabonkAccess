using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat;
using UnityEngine;

namespace Assets.Scripts.Actors;

public class DamageContainer
{
	public const string unknownDamageSource = "Unkown";

	public Vector3 direction;

	public float damage;

	public bool crit;

	public float knockback;

	public Enemy enemy;

	public EDamageEffect damageEffect;

	public EElement element;

	public float procCoefficient;

	public string damageSource;

	public int damageBlockedByArmor;

	public DcFlags flags;

	public DamageContainer(float procCoefficient, string damageSource)
	{
	}

	public void Reuse(float procCoefficient, string damageSource)
	{
	}

	public void Copy(DamageContainer dcOther)
	{
	}

	public Color GetColor()
	{
		return default(Color);
	}
}
