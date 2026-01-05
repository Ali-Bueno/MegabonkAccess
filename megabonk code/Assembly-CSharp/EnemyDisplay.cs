using Actors.Enemies;
using UnityEngine;

public class EnemyDisplay : MonoBehaviour
{
	public AnimatedMesh animatedMesh;

	public MeshRenderer meshRenderer;

	public Camera camera;

	public LayerMask layerMask;

	private float cameraDistance;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetEnemy(EEnemy eEnemy)
	{
	}

	private void EncapsulateEnemyRenderer()
	{
	}
}
