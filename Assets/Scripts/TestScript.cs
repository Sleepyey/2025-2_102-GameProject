using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start
    void Start()
    {
        
    }

    // Update
    public ItemData testItem;   // �ν����Ϳ� ���� �׽�Ʈ ������(SO)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            InventoryManager.Instance?.AddItem(testItem, 1);
    }
}
