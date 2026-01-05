using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class LocalizationPrewarmer : MonoBehaviour
{
	public TMP_FontAsset mainFont;

	public TMP_FontAsset notoDefault;

	public TMP_FontAsset notoJp;

	public TMP_FontAsset notoKo;

	public TMP_FontAsset notoSc;

	public TMP_FontAsset notoTc;

	public TMP_FontAsset notoTh;

	public List<string> tableNamesToPreload;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnLocaleChanged(Locale locale)
	{
	}

	public void PrewarmFontAsset(TMP_FontAsset fontAsset, Locale locale)
	{
	}

	private void SortFallbacks(TMP_FontAsset fontAsset)
	{
	}

	private TMP_FontAsset GetFontAsset(Locale locale)
	{
		return null;
	}
}
