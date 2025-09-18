using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("���� ����")]
    public int playerScore = 0;
    public int itemColledted = 0;

    [Header("UI ����")]
    public Text scoreText;
    public Text itemCountText;
    public Text gameStatusText;

    public static GameManager Instance;             // �̱��� ����

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectItem()
    {
        itemColledted++;
        Debug.Log($"������ ����! (�� : {itemColledted} ��");
    }

    public void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "���� : " + playerScore;
        }

        if (itemCountText != null)
        {
            itemCountText.text = "������ : " + itemColledted + "��";
        }
    }
}
