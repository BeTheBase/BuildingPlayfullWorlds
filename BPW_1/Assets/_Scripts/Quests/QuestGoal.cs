using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoalType
{
    Find,
    Escape
}

[System.Serializable]
public class QuestGoal
{
    public GoalType _GoalType;

    public int RequiredAmount;
    public int CurrentAmount;

    public bool IsReached()
    {
        return (CurrentAmount >= RequiredAmount);
    }

    public void FoundItem()
    {
        if (_GoalType == GoalType.Find)
            CurrentAmount++;
    }

    public void Escaped()
    {
        if (_GoalType == GoalType.Escape)
            CurrentAmount++;
    }
}
