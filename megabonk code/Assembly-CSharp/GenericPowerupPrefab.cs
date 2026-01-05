using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using UnityEngine;

public class GenericPowerupPrefab : MonoBehaviour
{
	public Pickup pickup;

	public ParticleSystem ps;

	public MeshRenderer minimapRenderer;

	public MeshRenderer iconRenderer;

	public Material hpMaterial;

	public Material nukeMaterial;

	public Material timeFreezeMaterial;

	public Material shieldMaterial;

	public Material rageMaterial;

	public Material hasteMaterial;

	public Material stonksMaterial;

	public Material magnetMaterial;

	private MaterialPropertyBlock propertyBlock;

	private void TryInit()
	{
	}

	public void Set(EPickup ePickup)
	{
	}

	private Material GetMinimapMaterial(EPickup ePickup)
	{
		return null;
	}
}
