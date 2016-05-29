using System;
using Arbor;

namespace YHaplogroup
{
	/// <summary>
	/// This class holds information on a specific Y-Chromosome Haplogroup (yHG). This class exists in an IS A relationship with a tree class because the relationships of a haplogroup are an inherent part of its identity.
	/// </summary>
	public class YHaplogroup : BinaryArbor1<YHaplogroupInformation>
	{
		public YHaplogroup ()
		{
		}
	}
}

