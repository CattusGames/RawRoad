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

	public static void Load(int count)
	{
		try
		{
			controller.Load(ref dataSet, fileName);
		}
		catch 
		{
			dataSet = new DataSet(count);
			dataSet.countUnlockedLevel = 1;
		}
	}

	public static void OnLevelFinished(int index, float time)
	{
		dataSet.Levels[index].BestTime = time;
		if(index+1 == dataSet.countUnlockedLevel)
			dataSet.countUnlockedLevel += 1;
	}
}