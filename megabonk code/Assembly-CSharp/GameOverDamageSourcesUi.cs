using System;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using UnityEngine;

public class GameOverDamageSourcesUi : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<DamageSource, float> _003C_003E9__2_0;

		internal float _003CStart_003Eb__2_0(DamageSource ds)
		{
			return 0f;
		}
	}

	public GameObject damageSourcePrefab;

	public Transform damageSourceParent;

	private void Start()
	{
	}
}
