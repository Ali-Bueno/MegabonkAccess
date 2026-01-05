using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeWorldUi : MonoBehaviour
{
	public MaskableGraphic damageText;

	public MaskableGraphic otherText;

	private Vector3 randomDir;

	public CanvasGroup cGroup;

	private Vector3 defaultScale;

	private float fadeTime;

	public float startFadeoutTime;

	private bool started;

	private IEnumerator shakeRoutine;

	private float moveMultiplier;

	private float speed;

	private Vector3 moveDir;

	private float desiredScale;

	private void StartFadeOut()
	{
	}

	public void Start()
	{
	}

	private void Update()
	{
	}

	private void DestroySelf()
	{
	}
}
