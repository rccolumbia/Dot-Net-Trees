using System;
using System.Collections.Generic;

namespace Arbor
{
	/// <summary>
	/// Defines an Arbor (Tree) that has a directly accessible parent.
	/// </summary>
	public interface IParentedArbor<T> : IArbor<T>
	{
		IParentedArbor<T> Parent { get; set;}

		/// <summary>
		/// Gets all of the node's ancestors
		/// </summary>
		/// <returns>The ancestors of this node</returns>
		IEnumerable<IParentedArbor<T>> GetAncestors();
	}
}

