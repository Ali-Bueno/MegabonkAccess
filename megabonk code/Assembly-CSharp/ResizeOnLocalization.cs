using UnityEngine;
using UnityEngine.Localization.Components;

public class ResizeOnLocalization : MonoBehaviour
{
	public Transform rebuildTransform;

	public LocalizeStringEvent localizeStringEvent;

	public TextSizer textSizer;

	public ButtonTextWrapper buttonTextWrapper;

	private bool expectingRebuild;

	private bool expectingRefresh;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnLocalizedStringChanged(string updatedString)
	{
	}

	private void DelayedRefresh()
	{
	}

	private void Rebuild()
	{
	}

	private void OnValidate()
	{
	}
}
