using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class IOController
{
	public void Save(DataSet dataSet, string fileName)
	{
		BinaryFormatter bFormatter = new BinaryFormatter();
		using (var fStream = new FileStream(fileName,
			FileMode.Create,
			FileAccess.Write, FileShare.None))
		{
			bFormatter.Serialize(fStream, dataSet);
		}
	}

	public void Load(ref DataSet dataSet, string fileName)
	{
		BinaryFormatter bFormatter = new BinaryFormatter();
		using (FileStream fSteam = File.OpenRead(fileName))
		{
			fSteam.Position = 0;
			dataSet = (DataSet)bFormatter.
				Deserialize(fSteam);
		}
	}
}
