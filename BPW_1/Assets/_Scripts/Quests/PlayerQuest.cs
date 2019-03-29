using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    public int TimeLeft = 500;

    public Quest _Quest;

    public void TriggerQuest()
    {
        if(_Quest.IsActive)
        {
            _Quest.Goal.FoundItem();
            if(_Quest.Goal.IsReached())
            {
                TimeLeft += _Quest.Reward;
                _Quest.Complete();
            }
        }
    }
}
