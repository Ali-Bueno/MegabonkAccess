using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetOfInterestPrefab : MonoBehaviour
{
	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_hp;

	public TextMeshProUGUI t_armor;

	public RawImage hpBar;

	public RawImage bloodmark;

	public RawImage poison;

	public CanvasGroup canvasGroup;

	public Color defaultColor;

	public Color invulnerableColor;

	private Enemy enemy;

	private float fadeTimer;

	private float fadeTime;

	private float debuffLerpSpeed;

	private float bloodmarkRatio;

	private float poisonRatio;

	private float poisonTargetRatio;

	private float bloodmarkTargetRatio;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetEnemy(Enemy enemy)
	{
	}

	private void Update()
	{
	}

	private void UpdateHp()
	{
	}

	private void UpdateDebuffs()
	{
	}

	private void OnDamage(Enemy enemy, DamageContainer dc)
	{
	}

	private void OnInvulnerableChanged(Enemy enemy, bool invulnerable)
	{
	}

	private void OnHealthChange(Enemy enemy)
	{
	}

	private void OnArmorChange(Enemy enemy, int current, int max)
	{
	}
}
