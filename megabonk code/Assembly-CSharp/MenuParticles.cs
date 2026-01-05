using Coffee.UIExtensions;
using UnityEngine;

public class MenuParticles : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public MenuParticles _003C_003E4__this;

		public ParticleSystem ps;

		internal void _003CCoinEffect_003Eb__0()
		{
		}
	}

	public GameObject coinEffect;

	public GameObject cointEffectParent;

	public UIParticleAttractor coinAttractor;

	public static MenuParticles Instance;

	private void Awake()
	{
	}

	public void CoinEffect(Vector3 position)
	{
	}

	public void OnCoinCollected()
	{
	}
}
