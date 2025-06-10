using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    private List<UISlot> slotList = new List<UISlot>();
    private Item selectedItem;
    private UISlot selectedSlot;

    public void InitInventoryUI(List<Item> items)
    {
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }

        slotList.Clear();

        foreach (var item in items)
        {
            GameObject slotObj = Instantiate(slotPrefab, slotParent);
            UISlot slot = slotObj.GetComponent<UISlot>();
            slot.SetItem(item);
            slot.ItemClicked += OnItemSlotClicked;
            slotList.Add(slot);
        }

        ClearSelection();
    }

    private void OnItemSlotClicked(Item item, UISlot slot)
    {
        selectedItem = item;
        selectedSlot = slot;

        if (item.ItemType == ItemType.Equipment)
        {
            if (item.IsEquipped)
            {
                GameManager.Instance.Character.UnEquip(item);
            }
            else
            {
                GameManager.Instance.Character.Equip(item);
            }
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        InitInventoryUI(GameManager.Instance.Character.Inventory);
        UIManager.Instance.UIStatus.SetStatus(GameManager.Instance.Character);
        ClearSelection();
    }

    private void ClearSelection()
    {
        selectedItem = null;
        selectedSlot = null;
    }
}

