using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class LevelsController
{

	public static DataSet dataSet;

	private static string fileName = "Save.road";

	private static IOController controller = new IOController();

	public static void Save()
	{
		controller.Save(dataSet, fileName);
	}

	public static void Load(List<Location> locations) 
	{
		try
		{
			controller.Load(ref dataSet, fileName);
		}
		catch
		{
			for (int i = 0; i < locations.Count; i++)
			{
				locations[i].levels[0].IsOpened = true;
			}
			dataSet = new DataSet(locations);
			dataSet.countUnlockedLocation = 1;
			dataSet.countUnlockedLevel = 1;
		}
	}

	public static void OnLevelFinished(int index, float time)
	{
		dataSet.Levels[index].BestTime = time;

		if(index+1 == dataSet.countUnlockedLevel)
        {
			dataSet.Levels[index + 1].IsOpened = true;
			dataSet.countUnlockedLevel += 1;
		}

	}
	public static void OnLocationFinished(int index)
    {
		dataSet.Locations[index].IsFinished = true;
		dataSet.countUnlockedLocation += 1;
		
    }
}