using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinIten : InteractableObject
{
    [Header("���� ����")]
    public int coinValue = 10;
    public string questTag = "Coin";                        // ����Ʈ���� ����� �±�

    // Start
    protected override void Start()
    {
        base.Start();
        objectName = "����";
        interactionText = "[E] ���� �Լ�";
        interactionType = InteractionType.Item;
    }

    protected override void CollectItem()
    {
        if (QuestManager.Instance != null)
        {
            QuestManager.Instance.AddCollectProgress(questTag);
        }
        Destroy(gameObject);
    }
}
