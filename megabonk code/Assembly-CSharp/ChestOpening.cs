using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpening : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<ItemData, int> _003C_003E9__33_0;

		internal int _003COpenChest_003Eb__33_0(ItemData x)
		{
			return 0;
		}
	}

	private sealed class _003CAnimateEffects_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChestOpening _003C_003E4__this;

		public ItemData itemData;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CAnimateEffects_003Ed__54(int _003C_003E1__state)
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

	private sealed class _003CAnimateOpening_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChestOpening _003C_003E4__this;

		public ItemData itemData;

		private float _003Ctimer_003E5__2;

		private float _003CwaitTime_003E5__3;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CAnimateOpening_003Ed__48(int _003C_003E1__state)
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

	public SkinnedMeshRenderer chestRenderer;

	public Animator chestAnimator;

	public AudioSource sfxOpen;

	public AudioSource sfxBuildup;

	public AudioSource sfxBuildupIntro;

	private bool spinning;

	private bool opened;

	public AudioClip buildupCommon;

	public AudioClip buildupRare;

	public AudioClip buildupEpic;

	public AudioClip buildupLegendary;

	public AudioClip skipCommon;

	public AudioClip skipRare;

	public AudioClip skipEpic;

	public AudioClip skipLegendary;

	public GameObject backgroundParticles;

	public ParticleSystem itemShine;

	public ParticleSystem backgroundGlow;

	public ParticleSystem[] psChestEmission;

	public GameObject particlesCoinsParent;

	public Mesh meshNormal;

	public Mesh meshFree;

	public Mesh meshEvil;

	public Material matNormal;

	public Material matFree;

	public Material matEvil;

	public Material matFreeCrypt;

	public Material matGhost;

	public Camera cam;

	public static Action<ItemData> A_ChestFinished;

	private ItemData itemData;

	private List<ItemData> rollingItems;

	public RawImage itemIcon;

	private int index;

	private const float updateRate = 0.06f;

	private float nextIconUpdate;

	private Vector3 desiredPosition;

	public GameObject fxCommon;

	public GameObject fxRare;

	public GameObject fxEpic;

	public GameObject fxLegendary;

	public GameObject fxCorrupted;

	public GameObject fxFinal;

	public Texture[] testSpinTextures;

	private bool canSkip;

	private bool skipped;

	private float desiredFov;

	private float defaultFov;

	private float timeBetweenTiers;

	public void SetChest(EChest chestType)
	{
	}

	private void SetRender(EChest chest)
	{
	}

	public void OpenChest(ItemData itemData)
	{
	}

	private void Update()
	{
	}

	private IEnumerator AnimateOpening(ItemData itemData)
	{
		return null;
	}

	private IEnumerator AnimateEffects(ItemData itemData)
	{
		return null;
	}
}
