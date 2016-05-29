using NUnit.Framework;
using System;
using System.Collections.Generic;
using Arbor;

namespace ArborTester
{
	[TestFixture ()]
	public class BinaryArbor1Tester
	{
		[Test ()]
		public void TestCase ()
		{
		}

		[Test ()]
		public void PopulateWorksSize0 ()
		{
			BinaryArbor1<int> tree = new BinaryArbor1<int>();
			List<int> values = new List<int> ();
			tree.Populate(values);
			Assert.AreEqual(default(int),tree.Value);
			Assert.IsNull (tree.Left);
			Assert.IsNull (tree.Right);
		}

		[Test ()]
		public void PopulateWorksSize1 ()
		{
			BinaryArbor1<int> tree = new BinaryArbor1<int>();
			int[] values = { 1 };
			tree.Populate(values);
			Assert.AreEqual(values[0],tree.Value);
			Assert.IsNull (tree.Left);
			Assert.IsNull (tree.Right);
		}

		[Test ()]
		public void PopulateWorksSize2 ()
		{
			BinaryArbor1<int> tree = new BinaryArbor1<int>();
			int[] values = { 1, 2 };
			tree.Populate(values);
			Assert.AreEqual(values[0],tree.Value);
			Assert.AreEqual(values[1],tree.Right.Value);
		}

		[Test ()]
		public void PopulateWorksSize3 ()
		{
			BinaryArbor1<int> tree = new BinaryArbor1<int>();
			int[] values = { 1, 2, 3 };
			tree.Populate(values);
			Assert.AreEqual(values[0],tree.Left.Value);
			Assert.AreEqual(values[1],tree.Value);
			Assert.AreEqual(values[2],tree.Right.Value);
			Assert.IsNull (tree.Left.Right);
			Assert.IsNull (tree.Left.Left);
			Assert.IsNull (tree.Right.Left);
			Assert.IsNull (tree.Right.Right);
		}

		[Test ()]
		public void PopulateWorksSize4 ()
		{
			BinaryArbor1<int> tree = new BinaryArbor1<int>();
			int[] values = { 1, 2, 3, 4 };
			tree.Populate(values);
			Assert.AreEqual(values[0],tree.Left.Value);
			Assert.AreEqual(values[1],tree.Value);
			Assert.AreEqual(values[2],tree.Right.Value);
			Assert.AreEqual(values[3],tree.Right.Right.Value);
			Assert.IsNull (tree.Right.Left);
			Assert.IsNull (tree.Left.Left);
			Assert.IsNull (tree.Left.Right);
			Assert.IsNull (tree.Right.Right.Left);
			Assert.IsNull (tree.Right.Right.Right);
			Assert.AreEqual (tree.Left.Parent.Value, tree.Value);
			Assert.AreEqual (tree.Right.Parent.Value, tree.Value);
			Assert.AreEqual (tree.Right.Right.Parent.Value, tree.Right.Value);
		}

		[Test ()]
		public void AsBFS4()
		{
			BinaryArbor1<int> tree = new BinaryArbor1<int>(2, new BinaryArbor1<int>(1, null, null), new BinaryArbor1<int>(2, null, new BinaryArbor1<int>(3, null, null)));
			int[] targetValues = { 2, 1, 3, 4 };
			AssertCollectionEquality (tree.GetItemsAsBFS (), targetValues);

		}

		[Test ()]
		public void AsDFS4()
		{
			BinaryArbor1<int> tree = new BinaryArbor1<int>(2, new BinaryArbor1<int>(1, null, null), new BinaryArbor1<int>(2, null, new BinaryArbor1<int>(3, null, null)));
			int[] targetValues = { 1, 4, 3, 2 };
			AssertCollectionEquality (tree.GetItemsAsDFS (), targetValues);

		}

		/// <summary>
		/// Iterates over two collections and asserts that the collections have the same length and that they have the same elements when compared 1 to 1 by using Assert.AreEqual.
		/// </summary>
		/// <param name="left">The left collection</param>
		/// <param name="right">The right collection</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		private void AssertCollectionEquality<T>(IEnumerable<T> left, IEnumerable<T> right)
		{
			List<T> leftList = new List<T> (left);
			List<T> rightList = new List<T> (right);
			Assert.AreEqual (leftList.Count, rightList.Count);
			//Now we know that they are the same length. Now check the elements.
			int size = leftList.Count;
			for (int counter = 0; counter < size; counter++)
			{
				Assert.AreEqual (leftList [counter], rightList [counter]);
			}
		}
	}
}

