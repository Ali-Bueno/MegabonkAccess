using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInformationUi : MonoBehaviour
{
	public GameObject parent;

	public TextMeshProUGUI t_enemies;

	public RawImage i_enemies;

	public ScalingEntry scalingEntryHp;

	public ScalingEntry scalingEntryDmg;

	public ScalingEntry scalingEntrySpeed;

	private float updateInterval;

	private float nextUpdateTime;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void OnSettingUpdate(string name, object oldVal, object newVal)
	{
	}

	private void Refresh()
	{
	}

	private void FixedUpdate()
	{
	}
}
