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


		/// <summary>
		/// Loads a collection of YHaplos, builds them into a tree, and returns the root
		/// </summary>
		/// <returns>The root of the collection. If no root (record with no parent) is found, returns null</returns>
		public YHaplo Load()
		{
			//Read the raw records.
			KeyValuePair<YHaplo,string>[] rawRecords = ReadHaplos(dataSource).ToArray();
			//Collate them into a relationship tree.
			YHaplo root = null;
			foreach (KeyValuePair<YHaplo,string> rawRecord in rawRecords)
			{
				YHaplo current = rawRecord.Key;
				string parent = rawRecord.Value;
				if ("null" == parent)
				{
					//This is the root
					root = current;
				}
				//Find all children
				var children = from KeyValuePair<YHaplo,string> potentialChild in rawRecords where potentialChild.Value == current.PrimaryName select potentialChild.Key;
				var childrenArray = children.ToArray();
				current.PopulateNonBinaryChildrenWithDummies(childrenArray);
			}
			//return from KeyValuePair<YHaplo,string> validRecord in rawRecords where true select validRecord.Key;
			return root;

		}

		private IEnumerable<KeyValuePair<YHaplo,string>> ReadHaplos(StreamReader readFrom)
		{
			
			string record;
			record = readFrom.ReadLine ();
			while (record != null)
			{
				string[] recordElements = record.Split ('/');
				if (null == recordElements)
				{
					throw new FileLoadException("Could not parse record. The data found was " + record);
				}
				if (3 != recordElements.Count())
				{
					//Read error
					throw new FileLoadException("Record does not have three slash delimited sections. The record found was " + record);
				}
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

