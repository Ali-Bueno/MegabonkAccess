using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Interactables;

public class DetectInteractables : MonoBehaviour
{
	private float interactableRange;

	public LayerMask whatIsInteractable;

	private BaseInteractable currentInteractable;

	public TextMeshProUGUI t_interact;

	public Transform uiParent;

	public MyGlyphDisplay glyphContainer;

	private string tagInteractable;

	public static Action<BaseInteractable, bool> A_Interacted;

	private float animationTime;

	private float animateOverTime;

	private Vector3 fromScale;

	private Vector3 toScale;

	private void Awake()
	{
	}

	private void FixedUpdate()
	{
	}

	public void TryInteract()
	{
	}

	private bool CanInteract()
	{
		return false;
	}

	private void Update()
	{
	}

	private void StartHovering(GameObject newObject)
	{
	}

	public void RefreshCurrentInteractable()
	{
	}

	private void StopHovering()
	{
	}

	public void InteractableDestroyed()
	{
	}

	private void RefreshGlyphContainer()
	{
	}
}
