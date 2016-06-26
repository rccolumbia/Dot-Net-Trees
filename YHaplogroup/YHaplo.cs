using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arbor;

namespace YHaplogroup
{
	/// <summary>
	/// This class holds information on a specific Y-Chromosome Haplogroup (yHG). This class exists in an IS A relationship with a tree class because the relationships of a haplogroup are an inherent part of its identity.
	/// </summary>
	public class YHaplo : BinaryArbor1<IList<string>>
	{
		#region fields

		#endregion

		public YHaplo ()
		{
		}

		public YHaplo (IEnumerable<string> names)
		{
			Names = new List<string>(names);
		}

		public YHaplo (IEnumerable<string> names, string description) : this(names)
		{
			Description = description;
		}
			
		#region Properties

		/// <summary>
		/// Gets or sets whether this object is a dummy placeholder object
		/// </summary>
		/// <value><c>true</c> if this instance is dummy; otherwise, <c>false</c>.</value>
		public bool IsDummy { get; set; }

		/// <summary>
		/// Gets the primary name of the haplogroup.
		/// </summary>
		/// <value>the primary name of the haplogroup</value>
		public string PrimaryName
		{
			get
			{
				return Names [0];
			}
			//Should a set be permitted?
		}

		/// <summary>
		/// Gets or sets a list of names associated with this haplogroup. The first item represents the primary name.
		/// </summary>
		/// <value>The names.</value>
		public IList<string> Names
		{
			get
			{
				if (null == Value)
				{
					//Create an empty one.
					Value = new List<string>();
				}
				return Value;
					
			}
			set
			{
				Value = value;
			}

		}

		/// <summary>
		/// Gets or sets this haplogroup's description
		/// </summary>
		/// <value>The description.</value>
		public string Description {get;set;}

		#endregion

		/// <summary>
		/// Populates the Children of this node with more than two children via the use of dummy intermediary YHaplo instances.
		/// </summary>
		/// <param name="children">The children to populate</param>
		public void PopulateNonBinaryChildrenWithDummies(IEnumerable<YHaplo> children)
		{
			YHaplo[] childArray = children.ToArray ();
			int childCount = childArray.Count();
			if (0 == childCount)
			{
				//Nothing to add.
				return;
			}
			if (1 == childCount)
			{
				Left = childArray [0];
				return;
			}
			if (2 == childCount)
			{
				Left = childArray [0];
				Right = childArray [1];
				return;
			}
			//There are more than 2 nodes. We will need dummies.
			//Store the first child
			Left = childArray[0];
			//Create a dummy to store the rest
			YHaplo right = new YHaplo() {IsDummy = true};
			//Recurse
			//This would be easier with C :)
			List<YHaplo> rest = new List<YHaplo>(childArray);
			rest.Remove (rest[0]);
			Right = right;
			right.PopulateNonBinaryChildrenWithDummies(rest);

		}

		/// <summary>
		/// Determines if this haplogroup has the specified name among its names.
		/// </summary>
		/// <returns>whether this haplogroup has the specified name among its names</returns>
		/// <param name="name">The name to search for</param>
		public bool HasName(string name)
		{
			foreach (string assignedName in Names)
			{
				if (name == assignedName)
				{
					return true;
				}
			}
			//Didn't find it.
			return false;
		}

		/// <summary>
		/// Finds the haplogroup with the specified name in a collection, if any
		/// </summary>
		/// <returns>the haplogroup with the specified name, null otherwise</returns>
		/// <param name="name">The name to search for</param>
		/// <param name="haplogroups">The haplogroups to search</param>
		public static YHaplo SearchForNameInHaplogroups(IEnumerable<YHaplo> haplogroups, string name)
		{
			foreach (YHaplo haplogroup in haplogroups)
			{
				if (haplogroup.HasName(name))
				{
					//Found it.
					return haplogroup;
				}
			}
			//Didn't find it.
			return null;
		}

		/// <summary>
		/// Finds the descendant of this haplogroup with the specified name, if any.
		/// </summary>
		/// <returns>the descendant of this haplogroup with the specified name, null otherwise</returns>
		/// <param name="name">The name to search for</param>
		public YHaplo GetDescendantWithName(string name)
		{
			return SearchForNameInHaplogroups(GetDescendants().AsHaplogroupCollection(), name);
		}

		/// <summary>
		/// Finds the ancestor of this haplogroup with the specified name, if any.
		/// </summary>
		/// <returns>the ancestor of this haplogroup with the specified name, null otherwise</returns>
		/// <param name="name">The name to search for</param>
		public YHaplo GetAncestorWithName(string name)
		{
			return SearchForNameInHaplogroups(GetAncestors().AsHaplogroupCollection(), name);
		}

		/// <summary>
		/// Determines if this haplogroup has the specified name among its descendants' names.
		/// </summary>
		/// <returns>whether this haplogroup has the specified name among its descendants' names</returns>
		/// <param name="name">The name to search for</param>
		public bool HasDescendantWithName(string name)
		{
			return null != GetDescendantWithName(name);
		}

		/// <summary>
		/// Determines if this haplogroup has the specified name among the names of its ancestors' names.
		/// </summary>
		/// <returns>whether this haplogroup has the specified name among its ancestors' names</returns>
		/// <param name="name">The name to search for</param>
		public bool HasAncestorWithName(string name)
		{
			return null != GetAncestorWithName(name);
		}

		/// <summary>
		/// Gets a comma delimited string of all the names of this haplogroup.
		/// </summary>
		/// <returns>a comma delimited string of all the names of this haplogroup</returns>
		public string GetNamesString()
		{
			string outputValue = string.Empty;
			return string.Join (",", Names);
		}

		public IEnumerable<YHaplo> GetDescendantsAsYHaplos()
		{
			foreach (var haplo in GetDescendants())
			{
				yield return haplo as YHaplo;
			}
		}

		public override string ToString()
		{
			StringBuilder introduction = new StringBuilder("My names are: ");
			introduction.Append(GetNamesString ());
			introduction.Append(" . ");
			introduction.Append("My description is: ");
			introduction.Append(Description);
			introduction.Append(" . ");
			if (null != Parent)
			{	
				introduction.Append ("My parent's name is: ");
				introduction.Append (((YHaplo)Parent).PrimaryName);
				introduction.Append (" . ");
			}
			else
			{
				introduction.Append ("I have no parent.");
			}
			introduction.Append("I have ");
			introduction.Append(Children.Count ().ToString());
			introduction.Append(" children.");
			return introduction.ToString();
		}
	}
}

