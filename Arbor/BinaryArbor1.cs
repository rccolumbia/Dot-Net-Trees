using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Arbor
{
	/// <summary>
	/// BinaryArbor1 is a preliminary Binary Tree class with minimal functionality. It is intended later to transition from BinaryArbor1 to a binary tree class that inherits from a generic tree class.
	/// </summary>
	public class BinaryArbor1<T>:IBinaryArbor<T>
	{
		private IBinaryArbor<T> left;
		private IBinaryArbor<T> right;
		private IParentedArbor<T> parent;

		public BinaryArbor1()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Arbor.BinaryArbor1`1"/> class.
		/// </summary>
		/// <param name="value">The value for this node</param>
		/// <param name="left">The left child of this node (nullable)</param>
		/// <param name="right">The right child of this node (nullable)</param>
		public BinaryArbor1(T value, IBinaryArbor<T> left, IBinaryArbor<T> right)
		{
			Value = value;
			Left = left;
			Right = right;
		}

		/// <summary>
		/// Gets or sets the value for this node.
		/// </summary>
		/// <value>The value.</value>
		public T Value {get; set;}

		/// <summary>
		/// Gets or sets the left child of this node.
		/// </summary>
		/// <value>The left child of this node (nullable)</value>
		public IBinaryArbor<T> Left
		{
			get
			{
				return left;
			}
			set
			{
				//Todo: See if a former child needs to be notified.
				left = value;
				RegisterParentage(left);
			}
		}

		/// <summary>
		/// Gets or sets the right child of this node.
		/// </summary>
		/// <value>The right child of this node (nullable)</value>
		public IBinaryArbor<T> Right
		{
			get
			{
				return right;
			}
			set
			{
				//Todo: See if a former child needs to be notified.
				right = value;
				RegisterParentage(right);
			}
		}

		public IParentedArbor<T> Parent
		{
			get
			{
				return parent;
			}
			set
			{
				//Todo: See if a previous parent needs to be notified.
				parent = value;
			}
		}

		/// <summary>
		/// Gets a collection of references to the children of this node.
		/// </summary>
		/// <value>a collection of references to the children of this node</value>
		public IEnumerable<IArbor<T>> Children
		{
			get
			{
				List<IArbor<T>> elements = new List<IArbor<T>> ();
				elements.Add((IArbor<T>)Left);
				elements.Add((IArbor<T>)Right);
				ReadOnlyCollection<IArbor<T>> returnCollection = new ReadOnlyCollection<IArbor<T>>(elements);
				return returnCollection;
			}
		}

		/// <summary>
		/// Gets the number of direct children of this node.
		/// </summary>
		/// <value>The child count.</value>
		public virtual int ChildCount
		{
			get
			{
				int childCount = 0;
				if (null != Left)
				{
					childCount++;
				}
				if (null != Right)
				{
					childCount++;
				}
				return childCount;
			}
		}

		/// <summary>
		/// Nulls the children of this node.
		/// </summary>
		public void ClearChildren()
		{
			Left = null;
			Right = null;
		}

		/// <summary>
		/// Populate the specified items into the tree. If items are in order, the result will be a binary search tree.
		/// </summary>
		/// <param name="items">The items to insert</param>
		public void Populate(IEnumerable<T> items)
		{
			List<T> itemsAsList = new List<T> (items);
			Populate (itemsAsList);
		}

		/// <summary>
		/// Populate the specified items into the tree. If items are in order, the result will be a binary search tree.
		/// </summary>
		/// <param name="items">The items to insert</param>
		public void Populate(List<T> items)
		{
			//List<T> itemsAsList = new List<T> (items);
			int size = items.Count;
			//Special cases for collections of size 0, 1, and 2:
			if (0 == size)
			{
				//There are no items to populate.
				Value = default(T);
				ClearChildren();
				return;
			}
			if (1 == size)
			{
				Value = items [0];
				ClearChildren();
				return;
			}
			if (2 == size)
			{
				Value = items [0];
				Left = null;
				Right = new BinaryArbor1<T> (items[1], null, null);
				return;
			}
			//Recursive cases:

			//Get the root to use using integer division.
			int newRootKey = (size-1)/2;
			//Insert the root item.
			Value = items[newRootKey];
			//Create nodes to be our children.
			BinaryArbor1<T> left = new BinaryArbor1<T>();
			BinaryArbor1<T> right = new BinaryArbor1<T>();
			//Set our children to point to these new nodes.
			Left = left;
			Right = right;
			//Split the list into two sub-lists.
			List<T> leftChildren = items.GetRange(0,newRootKey);
			List<T> RightChildren = items.GetRange (newRootKey + 1, size - (newRootKey + 1));
			//Populate the new nodes.
			Left.Populate(leftChildren);
			Right.Populate(RightChildren);
		}

		/// <summary>
		/// Extracts the underlying values from a set of nodes
		/// </summary>
		/// <returns>The nodes</returns>
		/// <param name="nodes">A collection of the values (.Value) of each node</param>
		public static IEnumerable<T> ExtractValues(IEnumerable<IBinaryArbor<T>> nodes)
		{
			foreach (IBinaryArbor<T> descendantNode in nodes)
			{
				yield return descendantNode.Value;
			}
		}

		/// <summary>
		/// Gets an enumerated collection of all the items in a tree using a Breadth First Search (BFS).
		/// </summary>
		/// <returns>an enumerated collection of all the items in a tree using a Breadth First Search (BFS)</returns>
		public IEnumerable<T> GetItemsAsBFS()
		{
			return ExtractValues(GetChildrenAsBFS());
		}

		/// <summary>
		/// Gets an enumerated collection of all the items in a tree using a Depth First Search (DFS).
		/// </summary>
		/// <returns>an enumerated collection of all the items in a tree using a Depth First Search (DFS)</returns>
		public IEnumerable<T> GetItemsAsDFS()
		{
			return ExtractValues(GetChildrenAsBFS());
		}

		/// <summary>
		/// Gets all of the node's ancestors
		/// </summary>
		/// <returns>The ancestors of this node</returns>
		public IEnumerable<IParentedArbor<T>> GetAncestors()
		{
			IParentedArbor<T> current = this.Parent;
			while (null != current)
			{
				yield return current;
				current = current.Parent;
			}
		}

		/// <summary>
		/// Gets an enumerated collection of all the descendants in the tree.
		/// </summary>
		/// <returns>an enumerated collection of all the descendants in the tree.</returns>
		public IEnumerable<IBinaryArbor<T>> GetDescendants()
		{
			return GetChildrenAsBFS();
		}

		/// <summary>
		/// Gets an enumerated collection of all the nodes in a tree using a Breadth First Search (BFS).
		/// </summary>
		/// <returns>an enumerated collection of all the nodes in a tree using a Breadth First Search (BFS)</returns>
		public IEnumerable<IBinaryArbor<T>> GetChildrenAsBFS()
		{
			List<IBinaryArbor<T>> items = new List<IBinaryArbor<T>>();
			//Store the current element in the list.
			items.Add(this);
			return GetChildrenAsBFSRecursive (this);
		}

		private IEnumerable<IBinaryArbor<T>> GetChildrenAsBFSRecursive(IBinaryArbor<T> root)
		{
			//Dig down to our children, if any.
			List<IBinaryArbor<T>> items = new List<IBinaryArbor<T>>();
			if (null == root)
			{
				//No more items.
				return items;
			}
			if (null != root.Left)
			{
				items.Add (root.Left);
			}
			if (null != root.Right)
			{
				items.Add(root.Right);
			}

			if (null != Left)
			{
				items.AddRange (GetChildrenAsBFSRecursive(root.Left));
			}
			if (null != Right)
			{
				items.AddRange (GetChildrenAsBFSRecursive(root.Right));
			}
			return items;
		}

		/// <summary>
		/// Gets an enumerated collection of all the items in a tree using a Depth First Search (DFS).
		/// </summary>
		/// <returns>an enumerated collection of all the nodes in a tree using a Depth First Search (DFS)</returns>
		public IEnumerable<IBinaryArbor<T>> GetChildrenAsDFS()
		{
			List<IBinaryArbor<T>> items = new List<IBinaryArbor<T>>();
			//Dig down to our children, if any.
			if (null != Left)
			{
				items.AddRange (Left.GetChildrenAsBFS());
			}
			if (null != Right)
			{
				items.AddRange (Right.GetChildrenAsBFS());
			}
			if (null != Left)
			{
				items.Add (Left);
			}
			if (null != Right)
			{
				items.Add(Right);
			}
			//Store the current element in the list.
			items.Add(this);
			return items;
		}

		public override string ToString()
		{
			StringBuilder output = new StringBuilder (Value.ToString());
			if (null != Left)
			{
				
			}
			return output.ToString ();
		}

		/// <summary>
		/// Registers the parentage of adoptee as this object.
		/// </summary>
		/// <param name="adoptee">The node whose parentage should be set.</param>
		private void RegisterParentage(IBinaryArbor<T> adoptee)
		{
			if (null != adoptee)
			{
				adoptee.Parent = this;
			}
		}

	}
}

