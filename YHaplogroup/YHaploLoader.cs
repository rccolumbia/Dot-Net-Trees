using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YHaplogroup
{
	public class YHaploLoader
	{
		#region Private Fields

		StreamReader dataSource;

		#endregion

		public YHaploLoader (StreamReader inputFile)
		{
			dataSource = inputFile;
		}
		public YHaploLoader (string inputFile) : this(new StreamReader(inputFile))
		{
		}

		public IEnumerable<YHaplo> Load()
		{
			//Read the raw records.
			IEnumerable<KeyValuePair<YHaplo,string>> rawRecords = ReadHaplos(dataSource);
			//Collate them into a relationship tree.
			foreach (KeyValuePair<YHaplo,string> rawRecord in rawRecords)
			{
				YHaplo current = rawRecord.Key;
				string parent = rawRecord.Value;
				//Find all children
				var children = from KeyValuePair<YHaplo,string> potentialChild in rawRecords where potentialChild.Value == current.PrimaryName select potentialChild.Key;
				current.PopulateNonBinaryChildrenWithDummies(children);
			}
			//stub for now
			return null;

		}

		private IEnumerable<KeyValuePair<YHaplo,string>> ReadHaplos(StreamReader readFrom)
		{
			
			string record;
			record = readFrom.ReadLine ();
			while (record != null)
			{
				string[] recordElements = record.Split ('/');
				string[] names = recordElements[0].Split (',');
				string description = recordElements[1];
				string parent = recordElements[2];
				YHaplo newHaplo = new YHaplo (names, description);
				yield return new KeyValuePair<YHaplo,string> (newHaplo,parent);
				record = readFrom.ReadLine();
			}
		}
	}
}

