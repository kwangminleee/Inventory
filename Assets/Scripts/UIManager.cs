﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private UIMainMenu uiMainMenu;
    [SerializeField] private UIStatus uiStatus;
    [SerializeField] private UIInventory uiInventory;
   

    public UIMainMenu UIMainMenu => uiMainMenu;
    public UIStatus UIStatus => uiStatus;
    public UIInventory UIInventory => uiInventory;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void OpenUI(GameObject targetUI)
    {
        uiStatus.gameObject.SetActive(false);
        uiInventory.gameObject.SetActive(false);

        if (targetUI == uiMainMenu.gameObject)
        {
            uiMainMenu.ShowButtons();
        }
        else
        {
            uiMainMenu.HideButtons();
        }

        targetUI.SetActive(true);
    }
}
