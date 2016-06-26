using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arbor;

namespace YHaplogroup
{
	public static class YHaplogroupExtensions
	{


		public static IEnumerable<YHaplo> AsHaplogroupCollection<T>(this IEnumerable<IBinaryArbor<T>> collection)
		{
			foreach (IBinaryArbor<T> node in collection)
			{
				yield return node as YHaplo;
			}
		}

		public static IEnumerable<YHaplo> AsHaplogroupCollection<T>(this IEnumerable<IParentedArbor<T>> collection)
		{
			foreach (IParentedArbor<T> node in collection)
			{
				yield return node as YHaplo;
			}
		}

		public static string GetHaplogroupDossiers(this IEnumerable<YHaplo> collection)
		{
			StringBuilder dossiers = new StringBuilder ("Total haplos: ");
			dossiers.Append (collection.ToArray().Count());
			dossiers.Append (". \n");
			foreach (YHaplo haplo in collection)
			{
				dossiers.Append(haplo.ToString());
				dossiers.Append ("\n");
			}
			return dossiers.ToString ();
		}
	}
}

