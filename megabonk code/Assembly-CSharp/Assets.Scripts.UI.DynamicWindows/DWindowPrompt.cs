using System;
using TMPro;

namespace Assets.Scripts.UI.DynamicWindows;

public class DWindowPrompt : DWindowBase
{
	public TextMeshProUGUI t_header;

	public TextMeshProUGUI t_content;

	private Action A_Accept;

	public void Set(string header, string content, Action A_Accept)
	{
	}

	public void Accept()
	{
	}

	public void Close()
	{
	}
}
