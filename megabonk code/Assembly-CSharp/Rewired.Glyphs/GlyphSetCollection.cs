using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Glyphs;

[Serializable]
public class GlyphSetCollection : ScriptableObject
{
	private sealed class _003CIterateSetsRecursively_003Ed__9 : IEnumerable<GlyphSet>, IEnumerable, IEnumerator<GlyphSet>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private GlyphSet _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private List<GlyphSetCollection> processedCollections;

		public List<GlyphSetCollection> _003C_003E3__processedCollections;

		public GlyphSetCollection _003C_003E4__this;

		private int _003CsetCount_003E5__2;

		private int _003CcollectionCount_003E5__3;

		private int _003Ci_003E5__4;

		private IEnumerator<GlyphSet> _003C_003E7__wrap4;

		GlyphSet IEnumerator<GlyphSet>.Current => null;

		object IEnumerator.Current => null;

		public _003CIterateSetsRecursively_003Ed__9(int _003C_003E1__state)
		{
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
		}

		void IEnumerator.Reset()
		{
		}

		IEnumerator<GlyphSet> IEnumerable<GlyphSet>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	private List<GlyphSet> _sets;

	private List<GlyphSetCollection> _collections;

	public List<GlyphSet> sets
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<GlyphSetCollection> collections
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual IEnumerable<GlyphSet> IterateSetsRecursively()
	{
		return null;
	}

	protected virtual IEnumerable<GlyphSet> IterateSetsRecursively(List<GlyphSetCollection> processedCollections)
	{
		return null;
	}

	private static void LogCircularDependency()
	{
	}
}
