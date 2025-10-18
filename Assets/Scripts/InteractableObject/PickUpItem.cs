using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : InteractableObject
{
    public ItemData itemData;                                                       // �� ������Ʈ�� ���� ������ ������
    public int amount = 1;                                                          // ������ ����

    public override void Interact()
    {
        base.Interact();

        if (InventoryManager.Instance != null)                                      // �κ��丮 �Ŵ����� ������
        {
            bool added = InventoryManager.Instance.AddItem(itemData, amount);       // �κ��丮�� ������ �߰� �õ�

            if (added)
            {
                Debug.Log($"[PickUp] added? {added}");
                Destroy(gameObject);                                                // �����ϸ� ������Ʈ ����
            }
        }
    }
}
