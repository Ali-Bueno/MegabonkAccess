using System.Collections.Generic;
using UnityEngine;

namespace Utility;

public class RaycastUtility
{
	public struct ConeSphere
	{
		public Vector3 pos;

		public float radius;

		public ConeSphere(Vector3 position, float radius)
		{
			pos = default(Vector3);
			this.radius = 0f;
		}
	}

	private static Collider[] coneCastBuffer;

	public static Vector3 RayToGround(Vector3 pos, float maxDistance = 9999f)
	{
		return default(Vector3);
	}

	public static Vector3 RayToGround(Vector3 pos, LayerMask layerMask, float maxDistance = 9999f)
	{
		return default(Vector3);
	}

	public static List<Collider> ConeCastAll(Vector3 origin, Vector3 direction, float maxDistance, float coneAngle)
	{
		return null;
	}

	public static HashSet<Collider> ConeCastNew(Vector3 origin, Vector3 direction, float distance, float coneAngle)
	{
		return null;
	}

	public static List<ConeSphere> GetConecastPositions(Vector3 pos, Vector3 dir, float dist, float coneAngle)
	{
		return null;
	}
}
