using System;
using System.Text;
using YHaplogroup;

namespace YHaplogroupConsole
{
	public class Instance
	{
		#region properties

		private YHaplo Root {get; set;}

		#endregion

		public Instance()
		{
			
		}

		public Instance (string path)
		{
			LoadHaplogroupTree(path);
		}

		public void LoadHaplogroupTree(string path)
		{
			//Load it
			YHaploLoader loader = new YHaploLoader(path);
			Root = loader.Load();
		}

		public string GetHaplogroupDetails(string haploToSearchFor)
		{
			YHaplo found = Root.FindInFamily(haploToSearchFor);
			if (null != found)
			{
				//Found something. Get information on it.
				return GetHaplogroupDetails(found);
			}
			//Nothing found.
			StringBuilder notFoundMessage = new StringBuilder("YHaplo ");
			notFoundMessage.Append(haploToSearchFor);
			notFoundMessage.Append(" not found.");
			return notFoundMessage.ToString();
		}

		public string GetHaplogroupDetails(YHaplo haplo)
		{
			StringBuilder result = new StringBuilder ("");
			result.Append(haplo.ToString());
			result.Append("\n");
			return result.ToString();
		}
	}
}

