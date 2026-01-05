using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RetroArsenal;

public class RetroFireProjectile : MonoBehaviour
{
	private sealed class _003CShoot_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RetroFireProjectile _003C_003E4__this;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CShoot_003Ed__17(int _003C_003E1__state)
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

	public GameObject[] projectiles;

	public Text missileNameText;

	public Toggle fullAutoButton;

	public Slider speedSlider;

	public bool cleanUpMissileName;

	public Transform spawnPosition;

	public int currentProjectile;

	public float speed;

	public float spawnOffset;

	public float fireRate;

	public bool isFullAuto;

	public GameObject gunPrefab;

	public float gunOffset;

	private bool canShoot;

	private GameObject instantiatedGun;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private IEnumerator Shoot()
	{
		return null;
	}

	private void ShootProjectile()
	{
	}

	private void UpdateGunPositionAndRotation()
	{
	}

	public void nextEffect()
	{
	}

	public void previousEffect()
	{
	}

	private void UpdateDisplayName()
	{
	}

	private string CleanUpMissileName(string name)
	{
		return null;
	}

	private void OnSpeedSliderChanged(float value)
	{
	}
}
