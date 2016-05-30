﻿using System;
using System.Collections.Generic;
using Arbor;

namespace YHaplogroup
{
	/// <summary>
	/// This class holds information on a specific Y-Chromosome Haplogroup (yHG). This class exists in an IS A relationship with a tree class because the relationships of a haplogroup are an inherent part of its identity.
	/// </summary>
	public class YHaplogroup : BinaryArbor1<YHaplogroupInformation>
	{
		#region fields

		private IList<string> names;

		#endregion

		public YHaplogroup ()
		{
		}

		#region Properties

		/// <summary>
		/// Gets or sets a list of names associated with this haplogroup. The first item represents the primary name.
		/// </summary>
		/// <value>The names.</value>
		IList<string> Names
		{
			get
			{
				if (null == names)
				{
					//Create an empty one.
					names = new List<string>();
				}
				return names;
					
			}
			set
			{
				names = value;
			}

		}

		#endregion


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
		public static YHaplogroup SearchForNameInHaplogroups(IEnumerable<YHaplogroup> haplogroups, string name)
		{
			foreach (YHaplogroup haplogroup in haplogroups)
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
		public YHaplogroup GetDescendantWithName(string name)
		{
			return SearchForNameInHaplogroups(GetDescendants().AsHaplogroupCollection(), name);
		}

		/// <summary>
		/// Finds the ancestor of this haplogroup with the specified name, if any.
		/// </summary>
		/// <returns>the ancestor of this haplogroup with the specified name, null otherwise</returns>
		/// <param name="name">The name to search for</param>
		public YHaplogroup GetAncestorWithName(string name)
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

		public override string ToString()
		{
			return GetNamesString();
		}
	}
}

