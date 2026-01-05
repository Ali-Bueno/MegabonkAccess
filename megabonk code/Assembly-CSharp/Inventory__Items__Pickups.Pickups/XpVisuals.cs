using UnityEngine;

namespace Inventory__Items__Pickups.Pickups;

public class XpVisuals : MonoBehaviour
{
	private enum XpTier
	{
		Low = 0,
		Medium = 10,
		High = 50
	}

	public ParticleSystem ps;

	private ParticleSystem.MainModule psMain;

	public Pickup pickup;

	public Color c_low;

	public Color c_mid;

	public Color c_high;

	public Color c_echo;

	private XpTier currentXpTier;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public void SetEchoXp()
	{
	}

	private void OnValueUpdated(int newValue)
	{
	}

	private XpTier GetXpTier(int value)
	{
		return default(XpTier);
	}
}
