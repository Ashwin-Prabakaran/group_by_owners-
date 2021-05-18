using System;
using System.IO;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace GroupbyOwners
{
	class Program
	{
		/// <summary>
		/// Get details of File and owner of the file.
		/// </summary>
		class FileDetailsInput
		{
			//Declaring input variable.
			public Dictionary<string, string> userDict = new Dictionary<string, string>();
			string confirmation;
			public void GetFileDetails()
			{
				do
				{
					//Get File Name.
					Console.WriteLine("Enter Filename");
					string fileName = Console.ReadLine();
					
					//Get File Owner Name.
					Console.WriteLine("Enter Owner name");
					string ownerName = Console.ReadLine();

					//Add in Dictionary.
					userDict.Add(fileName, ownerName);

					Console.WriteLine("Do you want to add more file and owner names YES/NO");
					confirmation = Console.ReadLine().ToUpper();

				} while (confirmation == "YES");

				Console.WriteLine("Final Input List is:");
				foreach (KeyValuePair<string, string> inputDetails in userDict)
				{
					Console.WriteLine("{0}, {1} \n",inputDetails.Key, inputDetails.Value);
				}
			}
		}
		static void Main(string[] args)
		{
			//Declaring Output variables.
			Dictionary<string, List<string>> ownerFiles = new Dictionary<string, List<string>>();
			string ownerName = "";
			FileDetailsInput fileDetailsInput = new FileDetailsInput();

			//To get User Details.
			fileDetailsInput.GetFileDetails();

			foreach (KeyValuePair<string, string> userInfoValue in fileDetailsInput.userDict)
			{
				List<string> value = new List<string>();
				if (!ownerFiles.ContainsKey(userInfoValue.Value))
				{
					ownerName = userInfoValue.Value;// assigning owner key.
					foreach (KeyValuePair<string, string> userInfoKey in fileDetailsInput.userDict)
					{
						if (ownerName == userInfoKey.Value)
						{
							value.Add(userInfoKey.Key);//Updating values.
						}
					}
					ownerFiles.Add(ownerName, value);
				}
			}

			Console.WriteLine("Aurthos and their resppective files");
			foreach (KeyValuePair<string, List<string>> outputDetails in ownerFiles)
			{

				Console.WriteLine("{0}, [{1}] \n", outputDetails.Key, string.Join(", ",outputDetails.Value));
			}

			Console.ReadLine();
		}
	}
}
