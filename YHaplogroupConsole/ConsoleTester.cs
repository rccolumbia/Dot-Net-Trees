using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YHaplogroup;
using Arbor;

namespace YHaplogroupConsole
{
	public class ConsoleTester
	{

		public ConsoleTester()
		{

		}
	

		public string GetHaplogroupDetails(YHaplo haplo)
		{
			StringBuilder result = new StringBuilder ("");
			result.Append(haplo.ToString());
			result.Append("\n");
			return result.ToString();
		}

		public void BFSTest()
		{
			BinaryArbor1<int> tree = GetTestTree();
			int[] targetValues = { 2, 1, 3, 4, 5, 6, 7 };
			var result = tree.GetItemsAsBFS().ToArray ();

			Console.WriteLine("Expected: " + ListElements(targetValues));
			Console.WriteLine("Actual  : " + ListElements(result));
		}

		public void DFSTest()
		{
			BinaryArbor1<int> tree = GetTestTree();
			int[] targetValues = { 2, 1, 4, 5, 3, 6, 7};
			var result = tree.GetItemsAsDFS().ToArray ();

			Console.WriteLine("Expected: " + ListElements(targetValues));
			Console.WriteLine("Actual  : " + ListElements(result));
		}

		public static string ListElements(IEnumerable<int> elements)
		{
			StringBuilder output = new StringBuilder("Count(int): ");
			output.Append(elements.Count ());
			output.Append(" Elements: ");
			foreach (int element in elements)
			{
				output.Append(element.ToString());
				output.Append (" ");
			}
			return output.ToString();
		}

		public static string ListElements<T>(IEnumerable<IBinaryArbor<T>> elements)
		{
			StringBuilder output = new StringBuilder("Count: ");
			output.Append(elements.Count ());
			output.Append(" Elements: ");
			foreach (IBinaryArbor<T> element in elements)
			{
				output.Append(element.Value.ToString());
				output.Append (" ");
			}
			return output.ToString();
		}

		private BinaryArbor1<int> GetTestTree()
		{
			BinaryArbor1<int> leftEnd = new BinaryArbor1<int> (1, new BinaryArbor1<int> (4, null, null), new BinaryArbor1<int> (5, null, null));
			BinaryArbor1<int> rightEnd = new BinaryArbor1<int> (3, new BinaryArbor1<int> (6, null, null), new BinaryArbor1<int> (7, null, null));
			BinaryArbor1<int> tree = new BinaryArbor1<int> (2, leftEnd, rightEnd);
			return tree;
		}
	}
}

