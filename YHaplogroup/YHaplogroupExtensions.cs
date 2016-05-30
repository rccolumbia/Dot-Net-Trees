using System;
using System.Collections.Generic;
using Arbor;

namespace YHaplogroup
{
	public static class YHaplogroupExtensions
	{


		public static IEnumerable<YHaplogroup> AsHaplogroupCollection<T>(this IEnumerable<IBinaryArbor<T>> collection)
		{
			foreach (IBinaryArbor<T> node in collection)
			{
				yield return node as YHaplogroup;
			}
		}

		public static IEnumerable<YHaplogroup> AsHaplogroupCollection<T>(this IEnumerable<IParentedArbor<T>> collection)
		{
			foreach (IParentedArbor<T> node in collection)
			{
				yield return node as YHaplogroup;
			}
		}
	}
}

