using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;                        // �̱��� ����

    [Header("Inventory Setting")]
    public int inventorySize = 20;                                  // �κ��丮 ���� ����
    public GameObject inventoryUI;                                  // �κ��丮 UI �г�
    public Transform itemSlotParent;                                // ���Ե��� �� �θ� ������Ʈ
    public GameObject itemSletPrefab;                               // ���� ������

    [Header("Input")]
    public KeyCode inventoryKey = KeyCode.I;                        // �κ�Ʈ�� ���� Ű
    public List<InventorySlot> slots = new List<InventorySlot>();   // ��� ���� ����Ʈ
    private bool isInventoryOpen = false;                           // �κ��丮�� �����ִ��� Ȯ��

    // Awake
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Start
    void Start()
    {
        CreateInventorySlots();
        inventoryUI.SetActive(false);
    }

    // Update
    void Update()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            ToggleInventory();
        }
    }

    void CreateInventorySlots()                     // �κ��丮 ���Ե��� �����ϴ� �Լ�
    {
        for (int i = 0; i < inventorySize; i++)
        {
            GameObject slotObject = Instantiate(itemSletPrefab, itemSlotParent);
            InventorySlot slot = slotObject.GetComponent<InventorySlot>();
            slots.Add(slot);                                                        // ����Ʈ�� �߰�
        }
    }

    public void ToggleInventory()                       // �κ��丮 UI�� ���ų� �ݴ� �Լ�
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryUI.SetActive(isInventoryOpen);

        if (isInventoryOpen)
        {
            Cursor.lockState = CursorLockMode.None;     // �κ��丮�� ������ Ŀ�� ���̱�
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;   // �κ��丮�� ������ Ŀ�� ���ñ�
            Cursor.visible = false;
        }
    }

    public bool AddItem(ItemData item, int amount = 1)
    {
        foreach (InventorySlot slot in slots)                       // 1�ܰ�: �̹� �ִ� �����ۿ� �߰� �õ� (����)
        {
            if (slot.item == item && slot.amount < item.maxStack)   // ���� �������̰� �ִ� ���ú��� ������
            {
                int spaceLeft = item.maxStack - slot.amount;        // ���� ���� ���
                int amountToAdd = Mathf.Min(amount, spaceLeft);     // �߰��� ����
                slot.AddAmount(amountToAdd);

                amount -= amountToAdd;                              // ���� �߰��� ������ ���� ������ ���Ѵ�..

                if (amount <= 0)
                {
                    return true;
                }
            }
        }

        foreach (InventorySlot slot in slots)                        // 2�ܰ�: �� ���Կ� �߰�
        {
            if (slot.item == null)                                   // �� ���Կ� �߰�
            {
                slot.SetItem(item, amount);
                return true;
            }
        }
        Debug.Log("�κ��丮�� ���� ��");
        return false;
    }

    public void RemoveItem(ItemData item, int amount = 1)           // �������� �κ��丮���� ���� �ϴ� �Լ�
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == item)
            {
                slot.RemoveAmount(amount);
                return;
            }
        }
    }

    public int GetItemCount(ItemData item)          // Ư�� �������� �� ������ ��ȯ�ϴ� �Լ�
    {
        int count = 0;
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == item)
            {
                count += slot.amount;
            }
        }
        return count;
    }
}
