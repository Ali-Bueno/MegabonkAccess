using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Objects.Particles___Effects.ParticleOpacity;

public class ParticleOpacity : MonoBehaviour
{
	public enum EOpacityCurve
	{
		Linear,
		OutCirc,
		Custom
	}

	public ParticleSystem[] particleSystems;

	public float[] defaultOpacitiesParticles;

	public TrailRenderer[] trails;

	public float[] defaultOpacitiesTrailsStart;

	public float[] defaultOpacitiesTrailsEnd;

	public LineRenderer[] lines;

	public float[] defaultOpacitiesLinesStart;

	public float[] defaultOpacitiesLinesEnd;

	public MeshRenderer[] meshRenderer;

	public EffectPlayer effectPlayer;

	public bool subscribeToOpacityChange;

	private bool queueRefreshForce;

	private bool queueRefresh;

	private float readyAtTime;

	private float cooldown;

	private float lastSetOpacity;

	private bool isHidden;

	public EOpacityCurve opacityCurve;

	public AnimationCurve customCurve;

	public bool useProjectileAutoOpacity;

	public ProjectileBase projectileBase;

	public ConstantAttack constantAttack;

	public float autoMinSize;

	public float autoMaxSize;

	public float minOpacity;

	public bool useScaleWithoutProjectileData;

	private string particleOpacitySettingName;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void Refresh()
	{
	}

	private void Refresh(bool force = false)
	{
	}

	private float GetAutoOpacity()
	{
		return 0f;
	}

	private void OnValidate()
	{
	}

	private void OnSettingUpdated(string name, object oldValue, object newValue)
	{
	}

	private void Update()
	{
	}
}
