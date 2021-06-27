using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataSet
{
	public int countLevels;
	public int countUnlockedLevel;

	public List<Level> Levels { get; private set; }
	
	public DataSet(int count)
	{
		countLevels = count;
		Levels = new List<Level>();
		for (int i = 0; i < countLevels; i++)
		{
			Levels.Add(new Level());
		}
	}
}
