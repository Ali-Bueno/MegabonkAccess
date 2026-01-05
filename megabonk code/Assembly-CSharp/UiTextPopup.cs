using TMPro;
using UnityEngine;

public class UiTextPopup : MonoBehaviour
{
	public TextMeshProUGUI t_text;

	public GameObject parent;

	public CanvasGroup canvasGroup;

	private float startFadeTime;

	private float fadeTime;

	private float upSpeed;

	private float scaleSpeed;

	private Vector3 desiredScale;

	public RandomSfx sfx;

	public RectTransform overlayCanvas;

	private bool fading;

	private float fadeTimer;

	public Vector2 TransformCameraToOverlaySpace(Vector3 position)
	{
		return default(Vector2);
	}

	public void SetTextCameraSpace(string text, Vector3 position, Color color, float desiredScale = 1f)
	{
	}

	public void SetText(string text, Vector3 position, Color color, float desiredScale = 1f)
	{
	}

	private void StartFade()
	{
	}

	private void Update()
	{
	}

	private void HideObject()
	{
	}
}
