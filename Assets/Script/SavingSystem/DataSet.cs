using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataSet
{
	public int countLocations;
	public int countUnlockedLocation;
	public int countLevels;
	public int countUnlockedLevel;

	public List<Level> Levels { get; private set; }
	public List<Location> Locations { get; private set; }
	
	public DataSet(List<Location> locations)
	{
		Levels = new List<Level>();
		Locations = new List<Location>(locations);
		countLocations = Locations.Count;

		for (int i = 0; i < countLocations; i++)
		{
            for (int j = 0; j < Locations[i].levels.Count; j++)
            {
				Levels.Add(Locations[i].levels[j]);
			}
		}
		countLevels = Levels.Count;
	}
}
