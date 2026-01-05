using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class DamageNumbers : MonoBehaviour
{
	public TextMeshProUGUI damageText;

	private Vector3 randomDir;

	private Vector3 defaultScale;

	private float fadeTime;

	private float startFadeoutTime;

	private bool started;

	private IEnumerator shakeRoutine;

	private static StringBuilder sb;

	private float moveMultiplier;

	private float speed;

	private Vector3 moveDir;

	private static string[] suffixes;

	private float desiredScale;

	private void StartFadeOut()
	{
	}

	public void SetDamage(float dmg, Color color, Vector3 position, int textSize = 24)
	{
	}

	public void SetDamage(string text, Color color, Vector3 position, int textSize = 24)
	{
	}

	private void Update()
	{
	}

	public static string FormatDamageNumber(float number, string decimalFormat = "0.0")
	{
		return null;
	}

	private void DestroySelf()
	{
	}
}
