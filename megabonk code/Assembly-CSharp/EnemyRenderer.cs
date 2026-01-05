using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using UnityEngine;

public class EnemyRenderer : MonoBehaviour
{
	public Enemy enemy;

	public Renderer enemyRenderer;

	private MaterialPropertyBlock propertyBlock;

	private Color freezeColorSpecular;

	private Color freezeColorAlbedo;

	private Color stunColorSpecular;

	private Color stunColorAlbedo;

	private Color echoColorSpecular;

	private Color echoColorAlbedo;

	private Color charmColorAlbedo;

	private Color charmColorSpecular;

	private Color lastSetSpecularColor;

	private string specularColorKey;

	private string albedoColorKey;

	private string rimColorKey;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void Reset()
	{
	}

	public void Set(EnemyData enemyData)
	{
	}

	private void OnDebuffAdded(EDebuff debuff)
	{
	}

	private void GetDebuffColor(out Color specular, out Color albedo)
	{
		specular = default(Color);
		albedo = default(Color);
	}

	private void OnDebuffRemoved(EDebuff debuff)
	{
	}

	public void SetInvulnerable(bool invulnerable)
	{
	}

	private void RefreshColor(EDebuff debuff)
	{
	}
}
