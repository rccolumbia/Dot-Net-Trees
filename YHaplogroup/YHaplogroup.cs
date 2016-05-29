using System;
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

		public override string ToString()
		{
			string outputValue = string.Empty;
			return string.Join (",", Names);
			
		}
	}
}

