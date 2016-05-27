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
		}
	}
}

