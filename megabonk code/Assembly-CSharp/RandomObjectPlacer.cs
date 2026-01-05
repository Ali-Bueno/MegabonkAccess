using Assets.Scripts.Game.MapGeneration;
using UnityEngine;

public class RandomObjectPlacer : MonoBehaviour
{
	public Vector3 center;

	public Vector3 size;

	private int numChargeShrines;

	public RandomMapObject[] randomObjects;

	public RandomMapObject chargeShrineSpawns;

	public RandomMapObject greedShrineSpawns;

	private int index;

	public void GenerateInteractables(MapData mapData)
	{
	}

	public void Generate(RandomMapObject[] objects, float amountMultiplier)
	{
	}

	private void RandomObjectSpawner(RandomMapObject randomObject, float amountMultiplier = 1f)
	{
	}

	private void OnDrawGizmosSelected()
	{
	}
}
