using System;
using System.Collections.Generic;
using Assets.Scripts._Data.Hats;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public ECharacter character;

		internal bool _003CSetHat_003Eb__0(HatOrientation x)
		{
			return false;
		}
	}

	public PlayerMovement playerMovement;

	public Animator animator;

	public Material damageFlash;

	private Material defaultMaterial;

	public SkinnedMeshRenderer renderer;

	private Transform hatTransform;

	private MeshRenderer hatRenderer;

	private MeshFilter hatFilter;

	public Transform hips;

	public Transform torso;

	private Quaternion desiredLookRotation;

	private float rotationSpeed;

	private float stoppedMovingAtTime;

	private float movingToIdleTimeout;

	private bool moving;

	private float resetMaterialTime;

	private GameObject rendererObject;

	public Action<CharacterData> A_CharacterSet;

	private CharacterData characterData;

	private SkinData skinData;

	public List<Renderer> subRenderers;

	protected Material[] activeMaterials;

	private List<Material> allMaterials;

	private Color defaultGoochDarkColor;

	private HatData currentHat;

	private bool isDamageFlash;

	private Material[] beforeDamageFlashMaterials;

	private bool shieldActive;

	private Outline outline;

	public Color shieldColor;

	public Color colorFreeze;

	public Color colorMud;

	public Color poisonColor;

	public Color colorNothing;

	private Vector3 smoothedNormal;

	private Vector3 lastValidMoveDirection;

	private float smoothingMultiplier;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnInventoryInit(PlayerInventory inventory)
	{
	}

	public void SetCharacter(CharacterData characterData, PlayerInventory inventory, Vector3 spawnDir)
	{
	}

	private void CreateMaterials(int amount)
	{
	}

	public void SetSkin(SkinData skinData)
	{
	}

	public void SetHat(HatData hatData)
	{
	}

	private void LateUpdate()
	{
	}

	private bool HasRenderer()
	{
		return false;
	}

	public void ResetMaterial()
	{
	}

	public void ForceMoving(bool b)
	{
	}

	private void Update()
	{
	}

	public void ForceRotation(Vector3 dir)
	{
	}

	private void ForceWalkAnimation()
	{
	}

	private void OnPause(bool paused)
	{
	}

	private void OnDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
	}

	private void OnHeal(PlayerHealth ph, float amount, bool isShield)
	{
	}

	private void ChangeShield(bool on)
	{
	}

	private void RefreshPlayerOutlines()
	{
	}

	public void SetMaterial(Material mat)
	{
	}

	public void SetIdle()
	{
	}

	private void OnDeath()
	{
	}

	private void OnStatusEffectAdded(EStatusEffect effect, bool newEffect)
	{
	}

	private void OnStatusEffectRemoved(EStatusEffect effect)
	{
	}

	private void RefreshStatusEffectColor()
	{
	}

	public void SetOutlineColor(Color color)
	{
	}

	public void SetRim(Color color, float size)
	{
	}

	public void SetRimOff()
	{
	}
}
