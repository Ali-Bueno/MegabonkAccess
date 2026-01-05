using System;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
	protected MyButton savedBtn;

	public MyButton startBtn;

	public bool alwaysUseStartBtn;

	public float openDelay;

	public List<MyButton> allButtons;

	public HashSet<GameObject> allButtonsHashed;

	private bool isFocused;

	public static Action A_WindowOpenedFirstTime;

	private float lastHadButtonTime;

	protected void Awake()
	{
	}

	protected void OnDestroy()
	{
	}

	public void FindAllButtonsInWindow()
	{
	}

	protected void Start()
	{
	}

	protected void OnEnable()
	{
	}

	protected void OnDisable()
	{
	}

	public void Close()
	{
	}

	private void OnButtonHover(MyButton btn)
	{
	}

	public void FocusWindow()
	{
	}

	private void DelayedButtonFocus()
	{
	}

	public void UnfocusWindow()
	{
	}

	private void Update()
	{
	}
}
