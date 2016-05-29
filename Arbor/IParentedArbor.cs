using System;

namespace Arbor
{
	/// <summary>
	/// Defines an Arbor (Tree) that has a directly accessible parent.
	/// </summary>
	public interface IParentedArbor<T> : IArbor<T>
	{
		IParentedArbor<T> Parent { get; set;}
	}
}

