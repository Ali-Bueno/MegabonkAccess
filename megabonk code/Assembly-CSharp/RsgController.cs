using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.AI.Navigation;
using UnityEngine;

public class RsgController : MonoBehaviour
{
	public enum EDungeonType
	{
		Normal,
		BossDungeon
	}

	private sealed class _003CGenerateMap_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RsgController _003C_003E4__this;

		private Stopwatch _003Ctimer_003E5__2;

		private float _003ClowestCordsHeight_003E5__3;

		private int _003CmaxPieces_003E5__4;

		private int _003CnumPieces_003E5__5;

		private int _003Ccollisions_003E5__6;

		private int _003CmaxCollisions_003E5__7;

		private int _003ClookAhead_003E5__8;

		private RsgPiece _003Cprevious_003E5__9;

		private RsgPiece _003CpieceBeforeLookahead_003E5__10;

		private List<RsgPiece> _003ClookaheadPieces_003E5__11;

		private int _003Cj_003E5__12;

		private int _003Ck_003E5__13;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CGenerateMap_003Ed__41(int _003C_003E1__state)
		{
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
		}
	}

	public bool combineColliderMesh;

	public NavMeshSurface navmeshSurface;

	public GameObject[] prefabs;

	public GameObject roomStart;

	public GameObject roomEnd;

	public GraveyardBossRoom roomBoss;

	private float generationDelay;

	private static ConsistentRandom random;

	public static int seed;

	public static Action<float> A_GenerationFinished;

	private static int customSeed;

	private float extraTime;

	private float extraTimeBoss;

	public static RsgController Instance;

	public int testSeed;

	private EDungeonType dungeonType;

	public static bool isCurrentMapRandomSeed;

	private float totalTraversalTime;

	private RsgPiece previousPiece;

	private List<RsgPiece> allPieces;

	private RsgStart _003CrsgStart_003Ek__BackingField;

	private InteractableCryptLeave _003CrsgEnd_003Ek__BackingField;

	private List<Bounds> bounds;

	private int mapLength;

	public int minPieces;

	public int maxPieces;

	private Vector3 startPosition;

	public GameObject combinedColliderMesh;

	private bool HasCustomSeed => false;

	public RsgStart rsgStart
	{
		get
		{
			return _003CrsgStart_003Ek__BackingField;
		}
		private set
		{
			_003CrsgStart_003Ek__BackingField = value;
		}
	}

	public InteractableCryptLeave rsgEnd
	{
		get
		{
			return _003CrsgEnd_003Ek__BackingField;
		}
		private set
		{
			_003CrsgEnd_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	public static void SetCustomSeed(int seed)
	{
	}

	private bool CanUseCustomSeed()
	{
		return false;
	}

	public void Generate(int newSeed, EDungeonType dungeonType, out float traversalTime)
	{
		traversalTime = default(float);
	}

	private int FindMapLength()
	{
		return 0;
	}

	public void ClearMap()
	{
	}

	private IEnumerator GenerateMap()
	{
		return null;
	}

	private void MirrorPiece(RsgPiece piece)
	{
	}

	private void ReversePiece(RsgPiece piece)
	{
	}

	private bool BoundsOverlap(RsgPiece piece)
	{
		return false;
	}

	private void BoundsAdd(RsgPiece piece)
	{
	}

	private void GetNextTransform(RsgPiece piece, out Vector3 pos, out Quaternion rotation)
	{
		pos = default(Vector3);
		rotation = default(Quaternion);
	}

	public void CombineMeshes(List<RsgPiece> allPieces)
	{
	}

	public static void AutoWeld(Mesh mesh, float threshold)
	{
	}

	private void OnDrawGizmos()
	{
	}
}
