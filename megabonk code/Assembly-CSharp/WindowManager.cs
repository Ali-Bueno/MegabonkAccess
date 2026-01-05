using System;
using System.Collections.Generic;

public static class WindowManager
{
	public static List<Window> openWindows;

	public static Window activeWindow;

	public static Action<Window> A_WindowOpened;

	public static void Update()
	{
	}

	public static void CloseAll()
	{
	}

	public static void WindowOpened(Window newWindow)
	{
	}

	public static void WindowClosed(Window closedWindow)
	{
	}

	public static void RefreshCursor()
	{
	}

	public static bool HasOpenWindow()
	{
		return false;
	}

	public static void OnGUI()
	{
	}
}
