using Assets.Scripts.UI.Animation;
using UnityEngine;
using UnityEngine.UI;

public class UiAnimation : MonoBehaviour
{
	public MaskableGraphic element;

	private MaskableGraphic[] subElements;

	private bool checkedChildren;

	private float scaleTarget;

	private float scaleTimer;

	private float scaleTimespan;

	private float fromScale;

	private EEasing scaleEasing;

	private void Awake()
	{
	}

	private void CheckSubElements()
	{
	}

	public void CrossFadeAndScaleIn(float time, EEasing easing = EEasing.Linear)
	{
	}

	public void ScaleIn(float time, EEasing easing = EEasing.Linear)
	{
	}

	public void CrossFade(float alpha, float time)
	{
	}

	public void Scale(float scale, float time, EEasing easing = EEasing.Linear)
	{
	}

	private void Update()
	{
	}

	private float GetEaseValue(float value, EEasing easing)
	{
		return 0f;
	}
}
