using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemData item;                   // �� ���Կ� �ִ� ������
    public int amount;                      // ������ ����

    [Header("UI Refernece")]
    public Image itemIcon;                  // ������ ������ �̹���
    public Text amountText;                 // ���� �ؽ�Ʈ
    public GameObject emptySlotImage;       // �� ���� �϶� ������ �̹���

    // Start
    void Start()
    {
        UpdateSlotUI();
    }

    public void SetItem(ItemData newItem, int newAmount)    // ���Կ� ������ ���� �ϴ� �Լ�
    {
        item = newItem;
        amount = newAmount;
        UpdateSlotUI();
    }

    void UpdateSlotUI()
    {
        if (item != null)                           // �������� ������
        {
            itemIcon.sprite = item.itemIcon;        // ������ ǥ��
            itemIcon.enabled = true;

            amountText.text = amount > 1 ? amount.ToString() : "";      // ������ 1�� ���� ������ ���� ǥ��
            if (emptySlotImage != null)
            {
                emptySlotImage.SetActive(false);                        // �� ���� �̹��� �����
            }
        }
        else
        {
            itemIcon.enabled = false;                                   // ������ �����
            amountText.text = "";                                       // �ؽ�Ʈ ����

            if (emptySlotImage != null)
            {
                emptySlotImage.SetActive(true);                         // �� ���� �̹��� ǥ��
            }
        }
    }

    public void AddAmount(int value)            // ������ ���� �߰��ϴ� �Լ�
    {
        amount += value;
        UpdateSlotUI();
    }

    public void RemoveAmount(int value)         // ������ ���� �����ϴ� �Լ�
    {
        amount -= value;

        if (amount <= 0)                        // ������ 0 ���ϸ� ���� ����
        {
            ClearSlot();
        }
        else
        {
            UpdateSlotUI();
        }
    }

    public void ClearSlot()                     // ������ ���� �Լ�
    {
        item = null;
        amount = 0;
        UpdateSlotUI();
    }
}
