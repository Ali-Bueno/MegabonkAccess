using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableCoffin : BaseInteractable
{
	public const int numCoffins = 4;

	public GameObject rayFx;

	public Animator coffinAnimator;

	public LocalizedString interactString;

	public Transform bossSpawnPos;

	public GameObject zone;

	public GameObject minimapIcon;

	public GameObject keyPickup;

	public AudioSource ambience;

	private static int currentGhostIndex;

	private HashSet<Enemy> minibossEnemies;

	private static bool hasActiveFight;

	private bool interacted;

	public AudioSource audio;

	public ParticleSystem[] stormParticles;

	public MeshRenderer fogOfWarRenderer;

	public GameObject zoneCollider;

	public GameObject zoneRenderer;

	private Material fogOfWarMaterial;

	private float fogIntensityDefault;

	private float fogIntensityNew;

	private Color fogColorDefault;

	private Color fogColorNew;

	private float audioVolume;

	private float fadeOverTime;

	private float fadeZoneTime;

	private float fadeTime;

	private bool isActive;

	private bool startedAnimating;

	private void Awake()
	{
	}

	private new void Start()
	{
	}

	private new void OnDestroy()
	{
	}

	public override bool Interact()
	{
		return false;
	}

	private void OnEnemyDied(Enemy enemy)
	{
	}

	private void OnKeyPickedUp()
	{
	}

	private void OnZoneCharged()
	{
	}

	private void OnInteracted(BaseInteractable interactable, bool succeess)
	{
	}

	public override string GetInteractString()
	{
		return null;
	}

	public override bool CanInteract()
	{
		return false;
	}

	public EnemyData GetEnemyData()
	{
		return null;
	}

	public void FadeIn()
	{
	}

	public void FadeOut()
	{
	}

	private void Update()
	{
	}
}
