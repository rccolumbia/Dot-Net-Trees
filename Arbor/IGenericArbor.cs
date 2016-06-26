using System;
using System.Collections.Generic;

namespace Arbor
{
	public interface IGenericArbor<T> : IArbor<T>, IParentedArbor<T>
	{
		/// <summary>
		/// Populate the specified items into the tree. If items are in order, the result will be a binary search tree.
		/// </summary>
		/// <param name="items">The items to insert</param>
		void Populate(IEnumerable<T> items);

		/// <summary>
		/// Gets a collection of references to the children of this node.
		/// </summary>
		/// <value>a collection of references to the children of this node</value>
		IEnumerable<GenericArbor<T>> ChildNodes { get; set; }

		/// <summary>
		/// Gets an enumerated collection of all the descendants in the tree.
		/// </summary>
		/// <returns>an enumerated collection of all the descendants in the tree.</returns>
		IEnumerable<IGenericArbor<T>> GetDescendants();

		/// <summary>
		/// Gets an enumerated collection of all the nodes in a tree using a Breadth First Search (BFS).
		/// </summary>
		/// <returns>an enumerated collection of all the nodes in a tree using a Breadth First Search (BFS)</returns>
		IEnumerable<IGenericArbor<T>> GetChildrenAsBFS();

		/// <summary>
		/// Gets an enumerated collection of all the nodes in a tree using a Depth First Search (DFS).
		/// </summary>
		/// <returns>an enumerated collection of all the nodes in a tree using a Breadth First Search (BFS)</returns>
		IEnumerable<IGenericArbor<T>> GetChildrenAsDFS();

		/// <summary>
		/// Gets an enumerated collection of all the items in a tree using a Breadth First Search (BFS).
		/// </summary>
		/// <returns>an enumerated collection of all the items in a tree using a Breadth First Search (BFS)</returns>
		IEnumerable<T> GetItemsAsBFS();

		/// <summary>
		/// Gets an enumerated collection of all the items in a tree using a Depth First Search (DFS).
		/// </summary>
		/// <returns>an enumerated collection of all the items in a tree using a Depth First Search (DFS)</returns>
		IEnumerable<T> GetItemsAsDFS();
	}
}

