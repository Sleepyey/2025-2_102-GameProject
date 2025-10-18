using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    [Header("��ȣ �ۿ� ����")]
    public float interactionRange = 2.0f;                   // ��ȣ �ۿ� ����
    public LayerMask interactionLayerMask = 1;              // ��ȣ �ۿ��� ���̾�
    public KeyCode interactionKey = KeyCode.E;              // ��ȣ �ۿ� Ű (EŰ)

    [Header("UI ����")]
    public Text interactionText;                            // ��ȣ �ۿ� UI �ؽ�Ʈ
    public GameObject interactionUI;                        // ��ȣ �ۿ� UI �ؽ�Ʈ ��ü

    private Transform playerTransform;
    private InteractableObject currentInteractable;        // ������ ������Ʈ�� ��� Ŭ����

    // Start
    void Start()
    {
        playerTransform = transform;
        HideInteractionUI();
    }

    // Update
    void Update()
    {
        CheckForInteractables();
        HandleInteractionInput();
    }

    void HandleInteractionInput()                                                   // ���ͷ��� �Է� �Լ�
    {
        if (currentInteractable != null && Input.GetKeyDown(interactionKey))       // ���ͷ��� Ű ���� ������ ��
        {
            currentInteractable.Interact();                                        // �ൿ�� �Ѵ�
        }
    }

    void ShowInteractionUI(string text)                                             // ���ͷ��� UI â�� ����
    {
        if (interactionUI != null)
        {
            interactionUI.SetActive(true);
        }

        if (interactionText != null)
        {
            interactionText.text = text;
        }
    }

    void HideInteractionUI()                                                        // ���ͷ��� UI â�� �ݴ´�
    {
        if (interactionUI != null)
        {
            interactionUI.SetActive(false);
        }
    }

    void CheckForInteractables()
    {
        Vector3 checkPosition = playerTransform.position + playerTransform.forward * (interactionRange * 0.5f);

        Collider[] hitColliders = Physics.OverlapSphere(checkPosition, interactionRange, interactionLayerMask);     // ��ü�� �浹�� ��� �ݶ��̴� �迭

        InteractableObject closestInteractable = null;              // ���� ����� ��ü ����
        float closestDistance = float.MaxValue;                     // �Ÿ� ����

        foreach (Collider collider in hitColliders)                 // ���� ����� ��ü �Ǻ�
        {
            InteractableObject interactable = collider.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                float distance = Vector3.Distance(playerTransform.position, collider.transform.position);
                // �÷��̾ �٤������� ���ῡ �ִ��� Ȯ�� (���� üũ)
                Vector3 directionToObject = (collider.transform.position - playerTransform.position).normalized;
                float angle = Vector3.Angle(playerTransform.forward, directionToObject);

                if (angle < 90f && distance < closestDistance)
                {
                    closestDistance = distance;
                    closestInteractable = interactable;
                }
            }
        }

        // ��ȣ �ۿ� ������Ʈ ���� üũ
        if (closestInteractable != currentInteractable)
        {
            if (currentInteractable != null)
            {
                currentInteractable.OnPlayerExit();                            // ���� ������Ʈ���� ����
            }

            currentInteractable = closestInteractable;

            if (currentInteractable != null)
            {
                currentInteractable.OnPlayerEnter();                           // �� ������Ʈ ����
                ShowInteractionUI(currentInteractable.GetInteractionText());
            }
            else
            {
                HideInteractionUI();
            }
        }
    }
}
