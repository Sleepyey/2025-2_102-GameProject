using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiveNPC : InteractableObject
{
    [Header("NPC Quest Settings")]
    public QuestData questToGive;
    public string npcName = "NPC";
    public string questStartMessge = "���ο� ����Ʈ�� �ֽ��ϴ�.";
    public string noQuestMessge = "����Ʈ�� �����ϴ�.";
    public string QuestAlreadyActiveMessge = "�̹� �������� ����Ʈ�� �ֽ��ϴ�.";

    private QuestManager questManager;

    // Start
    protected override void Start()
    {
        base.Start();

        questManager = FindObjectOfType<QuestManager>();

        if (questManager == null)
        {
            Debug.Log("QuestManager �� �����ϴ�.");
        }

        interactionText = "[E]" + npcName + "�� ��ȭ�ϱ�";
    }

    public override void Interact()
    {
        base.Interact();
        questManager.StartQuest(questToGive);
    }
}
