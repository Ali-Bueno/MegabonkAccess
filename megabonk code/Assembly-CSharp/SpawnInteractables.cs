using UnityEngine;

public class SpawnInteractables : MonoBehaviour
{
	public GameObject chest;

	public GameObject chestFree;

	private float chestDensity;

	private float shrineDensity;

	private float chanceForFreeChest;

	public const int numChestsPerStage = 46;

	public const int numShrines = 14;

	private int numRails;

	public GameObject[] rails;

	private Vector3 worldArea;

	private Vector3 worldCenter;

	private float areaMagnitude;

	public void SetArea(Vector3 worldArea, Vector3 worldCenter, float mag)
	{
	}

	public void SpawnShit()
	{
	}

	public void SpawnChests()
	{
	}

	public void SpawnShrines()
	{
	}

	private void SpawnOther()
	{
	}

	private void SpawnRails()
	{
	}
}
