using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class MyButton : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	public enum EButtonState
	{
		Active,
		Inactive,
		InactiveWithSelection
	}

	protected bool isHovering;

	public Transform scaleOnHover;

	protected Button button;

	public float hoverScale;

	private EButtonState state;

	public GameObject disabledOverlay;

	public AudioClip customSfx;

	protected float selectedAtTime;

	protected void Awake()
	{
	}

	public void SetFocus(bool focus)
	{
	}

	public void SetInteractable(bool interactable)
	{
	}

	public void SetInteractableButKeepSelectionOn(bool interactable)
	{
	}

	private void RefreshState()
	{
	}

	public void SetDisabledOverlayButKeepInteractable(bool enabled)
	{
	}

	public abstract void StartHover();

	public abstract void StopHover();

	protected abstract void OnClick();

	protected void PlaySfx()
	{
	}

	public void OnSelect(BaseEventData eventData)
	{
	}

	protected void Update()
	{
	}

	public Button GetButton()
	{
		return null;
	}
}
