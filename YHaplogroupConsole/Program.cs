using System;

namespace YHaplogroupConsole
{
	class MainClass
	{

		public static void Main (string[] args)
		{
			//Console.WriteLine ("Hello World!");
			int numArgs = args.Length;
			if (numArgs >= 1)
			{
				//First argument is the path to our haplogroup data. The rest of the arguments are haplogroups to search for.
				//Load data
				Instance instance = new Instance(args[0]);
				//Search for haplogroups
				for (int counter = 1;counter<numArgs;counter++)
				{
					//Search for a haplogroup with the argument's name and print details found, if any.
					Console.WriteLine(instance.GetHaplogroupDetails(args[counter]));
				}
			}
		}


	}
}
