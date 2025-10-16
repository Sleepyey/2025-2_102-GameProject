using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinIten : InteractableObject
{
    [Header("동전 설정")]
    public int coinValue = 10;
    public string questTag = "Coin";                        // 퀘스트에서 사용할 태그

    // Start
    protected override void Start()
    {
        base.Start();
        objectName = "동전";
        interactionText = "[E] 동전 함수";
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
