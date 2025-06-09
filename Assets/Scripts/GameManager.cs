using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Character Character { get; private set; }


    private void Start()
    {
        SetData();
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void SetData()
    {
        Character = new Character("Chad", 35, 40, 100, 25, 10, 9, 12);

        UIManager.Instance.UIMainMenu.SetCharacterInfo(Character);
        UIManager.Instance.UIStatus.SetStatus(Character);
    }
}
