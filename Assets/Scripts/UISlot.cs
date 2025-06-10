using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text equipText;
    private Button button;

    private Item item;
    private bool isEquipped = false;

    public delegate void OnItemClicked(Item item, UISlot slot);
    public event OnItemClicked ItemClicked;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        equipText.gameObject.SetActive(false);
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
        iconImage.sprite = item.Icon;
        iconImage.enabled = true;
        SetEquipped(item.IsEquipped);
    }

    public void ClearSlot()
    {
        item = null;
        iconImage.sprite = null;
        iconImage.enabled = false;
        SetEquipped(false);
    }

    private void OnClick()
    {
        if (item != null)
        {
            ItemClicked?.Invoke(item, this);
        }
    }

    public void SetEquipped(bool equipped)
    {
        isEquipped = equipped;
        equipText.gameObject.SetActive(isEquipped);
    }
}
