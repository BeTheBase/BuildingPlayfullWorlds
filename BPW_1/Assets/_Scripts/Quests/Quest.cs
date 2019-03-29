using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool IsActive;

    public string Title;
    public string Description;

    public int Reward;

    public QuestGoal Goal;

    public void Complete()
    {
        IsActive = false;
        Debug.Log(Title + "was completed!");
    }
}
