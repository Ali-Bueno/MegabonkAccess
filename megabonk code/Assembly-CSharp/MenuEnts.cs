using System.Collections.Generic;
using UnityEngine;

public class MenuEnts : MonoBehaviour
{
	private class EntData
	{
		public GameObject obj;

		public int dir;

		public float speed;
	}

	public GameObject entPrefab;

	public Transform leftPos;

	public Transform rightPos;

	private float baseSpeed;

	private List<EntData> ents;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void FaceDirection(Transform tr, int dir)
	{
	}
}
