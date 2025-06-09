using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text currentExpText;
    [SerializeField] private TMP_Text maxExpText;
    [SerializeField] private Image expFillImage;
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private Button statusBackButton;
    [SerializeField] private Button inventoryBackButton;


    public void SetCharacterInfo(Character character)
    {
        nameText.text = $"{character.Name}";
        levelText.text = $"{character.Level}";
        currentExpText.text = $"{character.CurrentExp}";
        maxExpText.text = $"{character.MaxExp}";

        expFillImage.fillAmount = (float)character.CurrentExp / character.MaxExp;
    }

    private void Start()
    {
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);
        statusBackButton.onClick.AddListener(OpenMainMenu);
        inventoryBackButton.onClick.AddListener(OpenMainMenu);
    }

    private void OpenStatus()
    {
        UIManager.Instance.OpenUI(UIManager.Instance.UIStatus.gameObject);
    }

    private void OpenInventory()
    {
        UIManager.Instance.OpenUI(UIManager.Instance.UIInventory.gameObject);
    }

    private void OpenMainMenu()
    {
        UIManager.Instance.OpenUI(UIManager.Instance.UIMainMenu.gameObject);
    }

    public void HideButtons()
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
    }

    public void ShowButtons()
    {
        statusButton.gameObject.SetActive(true);
        inventoryButton.gameObject.SetActive(true);
    }
}
