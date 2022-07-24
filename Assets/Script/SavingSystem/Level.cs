using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[Serializable]
public class Level
{
	public string levelName;

	public Image levelImage;

	public int sceneID;
	public bool IsOpened { get; set; }
	public bool IsFinished { get; set; }
	public float BestTime { get; set; }
}
