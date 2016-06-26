using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using YHaplogroup;

namespace ArborTester
{
	[TestFixture ()]
	public class YHaplogroupTester
	{

		/// <summary>
		/// Verifies that a name can be found in a name search.
		/// </summary>
		[Test ()]
		public void TestPrimaryName()
		{
			YHaplo[] haplos = new YHaplo[6];
			haplos[0] = new YHaplo(new string[] {"A", "B", "C"});
			haplos[1] = new YHaplo(new string[] {"D", "E", "F"});
			haplos[2] = new YHaplo(new string[] {"G", "H", "I"});
			haplos[3] = new YHaplo(new string[] {"J", "K", "L"});
			haplos[4] = new YHaplo(new string[] {"M", "N", "O"});
			haplos[5] = new YHaplo(new string[] {"P", "Q", "R"});

			Assert.AreEqual(YHaplo.SearchForNameInHaplogroups(haplos,"Q").PrimaryName, "P");
			Assert.AreEqual(YHaplo.SearchForNameInHaplogroups(haplos,"A").PrimaryName, YHaplo.SearchForNameInHaplogroups(haplos,"C").PrimaryName);
			Assert.AreEqual(YHaplo.SearchForNameInHaplogroups(haplos,"I").PrimaryName, YHaplo.SearchForNameInHaplogroups(haplos,"H").PrimaryName);
		}

		/// <summary>
		/// Verifies that a name can be found in a name search.
		/// </summary>
		[Test ()]
		public void TestNameSearch()
		{
			YHaplo[] haplos = new YHaplo[6];
			haplos[0] = new YHaplo(new string[] {"A", "B", "C"});
			haplos[1] = new YHaplo(new string[] {"D", "E", "F"});
			haplos[2] = new YHaplo(new string[] {"G", "H", "I"});
			haplos[3] = new YHaplo(new string[] {"J", "K", "L"});
			haplos[4] = new YHaplo(new string[] {"M", "N", "O"});
			haplos[5] = new YHaplo(new string[] {"P", "Q", "R"});

			Assert.IsNotNull(YHaplo.SearchForNameInHaplogroups(haplos,"A"));
			Assert.IsNotNull(YHaplo.SearchForNameInHaplogroups(haplos,"E"));
			Assert.IsNotNull(YHaplo.SearchForNameInHaplogroups(haplos,"I"));
			Assert.IsNotNull(YHaplo.SearchForNameInHaplogroups(haplos,"Q"));
			Assert.IsNotNull(YHaplo.SearchForNameInHaplogroups(haplos,"R"));
			Assert.IsNull(YHaplo.SearchForNameInHaplogroups(haplos,"Z"));
			Assert.IsNull(YHaplo.SearchForNameInHaplogroups(haplos,"4"));
			Assert.IsNull(YHaplo.SearchForNameInHaplogroups(haplos,"A1"));
			Assert.IsNull(YHaplo.SearchForNameInHaplogroups(haplos,"R2"));

			Assert.AreEqual(YHaplo.SearchForNameInHaplogroups(haplos,"I").PrimaryName, YHaplo.SearchForNameInHaplogroups(haplos,"H").PrimaryName);

			Assert.IsTrue(YHaplo.SearchForNameInHaplogroups(haplos,"I").Names.Contains("G"));
			Assert.IsTrue(YHaplo.SearchForNameInHaplogroups(haplos,"I").Names.Contains("H"));
			Assert.IsTrue(YHaplo.SearchForNameInHaplogroups(haplos,"I").Names.Contains("I"));
			
			Assert.IsTrue(YHaplo.SearchForNameInHaplogroups(haplos,"P").Names.Contains("Q"));

			Assert.IsFalse(YHaplo.SearchForNameInHaplogroups(haplos,"P").Names.Contains("A"));
		}

		/// <summary>
		/// Verifies that a name can be found in a name search.
		/// </summary>
		[Test ()]
		public void TestNameSearchInDescendants()
		{
			YHaplo[] haplos = new YHaplo[6];
			haplos[0] = new YHaplo(new string[] {"A", "B", "C"});
			haplos[1] = new YHaplo(new string[] {"D", "E", "F"});
			haplos[2] = new YHaplo(new string[] {"G", "H", "I"});
			haplos[3] = new YHaplo(new string[] {"J", "K", "L"});
			haplos[4] = new YHaplo(new string[] {"M", "N", "O"});
			haplos[5] = new YHaplo(new string[] {"P", "Q", "R"});
			//Establish parentage
			haplos[0].Left = haplos[1];
			haplos[0].Right = haplos[2];
			haplos[1].Left = haplos[3];
			haplos[1].Right = haplos[4];
			haplos[2].Left = haplos[5];
			//Assert.IsTrue(haplos[0].cont
			Assert.AreEqual(haplos[0].GetDescendantWithName("R").PrimaryName, haplos[5].PrimaryName);

			Assert.AreNotEqual(haplos[0].GetDescendantWithName("R").PrimaryName, haplos[2].PrimaryName);

		}

		[Test()]
		public void TestPopulateNonBinaryChildrenWithDummies()
		{
			YHaplo[] haplos = new YHaplo[6];
			haplos[0] = new YHaplo(new string[] {"A", "B", "C"});
			haplos[1] = new YHaplo(new string[] {"D", "E", "F"});
			haplos[2] = new YHaplo(new string[] {"G", "H", "I"});
			haplos[3] = new YHaplo(new string[] {"J", "K", "L"});
			haplos[4] = new YHaplo(new string[] {"M", "N", "O"});
			haplos[5] = new YHaplo(new string[] {"P", "Q", "R"});
			YHaplo root = new YHaplo (new string[] { "1", "01", "001" });
			root.PopulateNonBinaryChildrenWithDummies(haplos);
			//Check for all the children.
			Assert.IsNotNull(YHaplo.SearchForNameInHaplogroups(haplos,"A"));
			Assert.IsNotNull(YHaplo.SearchForNameInHaplogroups(haplos,"B"));
			Assert.IsNotNull(YHaplo.SearchForNameInHaplogroups(haplos,"D"));
			Assert.IsNotNull(YHaplo.SearchForNameInHaplogroups(haplos,"G"));
			Assert.IsNotNull(YHaplo.SearchForNameInHaplogroups(haplos,"J"));
			Assert.IsNotNull(YHaplo.SearchForNameInHaplogroups(haplos,"M"));
			Assert.IsNotNull(YHaplo.SearchForNameInHaplogroups(haplos,"P"));
			Assert.IsNull(YHaplo.SearchForNameInHaplogroups(haplos,"5"));
		}

		[Test()]
		public void TestPopulateFromText()
		{
			string lineDelimiter = "\n";
			string loadText = 
				"R1/Proto-Indo-European/null" + lineDelimiter +
				"R1b/Proto-Italo-Celto-Germanic/R1" + lineDelimiter +
				"R1b-U106,R1b-S21/Proto-West-Germanic/R1b" + lineDelimiter +
				"R1b-L21/Proto-Celtic/R1b" + lineDelimiter +
				"R1b-M222/Ui Neill/R1b-L21";
			var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes (loadText));
			var reader = new StreamReader(memoryStream);
			//Load from memory, not a file.
			var loader = new YHaploLoader(reader);
			YHaplo root = loader.Load();
			//Verify that the correct data was loaded.
			Assert.AreEqual(root.PrimaryName,"R1");
			Assert.AreNotEqual(root.PrimaryName,"R1b");
			Assert.IsNotNull(root.GetDescendantWithName("R1b-L21"));
			Assert.IsNotNull(root.GetDescendantWithName("R1b-M222"));

			//The son is not the father....
			Assert.IsNull(root.GetDescendantWithName("R1b-L21").GetDescendantWithName("R1b"));
			Assert.IsNull(root.GetDescendantWithName("R1b-M222").GetDescendantWithName("R1b"));

			//Grandparent/grandchild relationships are important.
			Assert.IsNotNull(root.GetDescendantWithName("R1b-L21").GetDescendantWithName("R1b-M222"));

			//Siblings are not in a parent/child relationship.
			Assert.IsNull(root.GetDescendantWithName("R1b-L21").GetDescendantWithName("R1b-S21"));

			//One is not one's own parent....
			Assert.IsNull(root.GetDescendantWithName("R1b-U106").GetDescendantWithName("R1b-S21"));
			Assert.IsNull(root.GetDescendantWithName("R1b-U106").GetDescendantWithName("R1b-U106"));
			Assert.IsNull(root.GetDescendantWithName("R1b-S21").GetDescendantWithName("R1b-S21"));
			Assert.IsNull(root.GetDescendantWithName("R1").GetDescendantWithName("R1"));
		}

		[Test ()]
		public void TestCase ()
		{
		}
	}
}

