using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiveNPC : InteractableObject
{
    [Header("NPC Quest Settings")]
    public QuestData questToGive;
    public string npcName = "NPC";
    public string questStartMessge = "새로운 퀘스트가 있습니다.";
    public string noQuestMessge = "퀘스트가 없습니다.";
    public string QuestAlreadyActiveMessge = "이미 진행중인 퀘스트가 있습니다.";

    private QuestManager questManager;

    // Start
    protected override void Start()
    {
        base.Start();

        questManager = FindObjectOfType<QuestManager>();

        if (questManager == null)
        {
            Debug.Log("QuestManager 가 없습니다.");
        }

        interactionText = "[E]" + npcName + "와 대화하기";
    }

    public override void Interact()
    {
        base.Interact();
        questManager.StartQuest(questToGive);
    }
}
