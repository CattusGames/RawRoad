using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Location: MonoBehaviour
{
	public string locationName;
	public bool IsOpened { get; set; }

	public bool IsFinished { get; set; }

	public List<Level> levels;
}
