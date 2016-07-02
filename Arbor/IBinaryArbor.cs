using System;
using System.Collections.Generic;

namespace Arbor
{
	/// <summary>
	/// IBinaryArbor<T> is an interface for a generic binary tree of type T.
	/// </summary>
	public interface IBinaryArbor<T> : IArbor<T>, IParentedArbor<T>
	{
		/// <summary>
		/// Gets or sets the left child of this node.
		/// </summary>
		/// <value>The left child of this node (nullable)</value>
		IBinaryArbor<T> Left {get;set;}

		/// <summary>
		/// Gets or sets the right child of this node.
		/// </summary>
		/// <value>The right child of this node (nullable)</value>
		IBinaryArbor<T> Right {get;set;}

		/// <summary>
		/// Populate the specified items into the tree. If items are in order, the result will be a binary search tree.
		/// </summary>
		/// <param name="items">The items to insert</param>
		void Populate(IEnumerable<T> items);

		/// <summary>
		/// Gets an enumerated collection of the object, its ancestors, and its descendants.
		/// </summary>
		/// <returns>an enumerated collection of the object, its ancestors, and its descendants.</returns>
		IEnumerable<IBinaryArbor<T>> GetEntireFamily();

		/// <summary>
		/// Gets an enumerated collection of all the descendants in the tree.
		/// </summary>
		/// <returns>an enumerated collection of all the descendants in the tree.</returns>
		IEnumerable<IBinaryArbor<T>> GetDescendants();

		/// <summary>
		/// Gets an enumerated collection of all the nodes in a tree using a Breadth First Search (BFS).
		/// </summary>
		/// <returns>an enumerated collection of all the nodes in a tree using a Breadth First Search (BFS)</returns>
		IEnumerable<IBinaryArbor<T>> GetChildrenAsBFS();

		/// <summary>
		/// Gets an enumerated collection of all the nodes in a tree using a Depth First Search (DFS).
		/// </summary>
		/// <returns>an enumerated collection of all the nodes in a tree using a Breadth First Search (BFS)</returns>
		IEnumerable<IBinaryArbor<T>> GetChildrenAsDFS();

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

