using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int LevelCompleted;
    public bool TutorialCompleted;

    // Constructor values are default
    public GameData()
    {
        this.LevelCompleted = 0;
        this.TutorialCompleted = false;
    }
}
