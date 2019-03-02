using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest _Quest;

    public GameObject PlayerObject;
    public GameObject QuestWindow;

    public Text TitleText;
    public Text DescribtionText;
    public Text RewardText;

    public void OpenQuestWindow()
    {
        QuestWindow.SetActive(true);
        TitleText.text = _Quest.Title;
        DescribtionText.text = _Quest.Description;
        RewardText.text = _Quest.Reward.ToString();
    }

    public void AcceptQuest()
    {
        QuestWindow.SetActive(false);
        _Quest.IsActive = true;
    }
}
