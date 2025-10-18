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
    public ItemData testItem;   // 인스펙터에 넣을 테스트 아이템(SO)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            InventoryManager.Instance?.AddItem(testItem, 1);
    }
}
