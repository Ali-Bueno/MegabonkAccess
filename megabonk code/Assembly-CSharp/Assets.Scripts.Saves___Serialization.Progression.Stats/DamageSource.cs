using UnityEngine;

namespace Assets.Scripts.Saves___Serialization.Progression.Stats;

public class DamageSource
{
	public string damageSource;

	public float addedAtTime;

	public float damage;

	public DamageSource(string damageSource, float addedAtTime)
	{
	}

	public void AddDamage(float d)
	{
	}

	public int GetLevel()
	{
		return 0;
	}

	public Texture GetIcon()
	{
		return null;
	}
}
