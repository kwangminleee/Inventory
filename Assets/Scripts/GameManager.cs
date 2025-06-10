using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Character Character { get; private set; }

    [SerializeField] private Sprite[] itemIcons;

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

        Item axe = new Item("도끼", itemIcons[0])
        {
            ItemType = ItemType.Equipment,
            EquipType = EquipType.Weapon,
            BonusAttack = 10,
            BonusDefense = 0
        };

        Item bow = new Item("활", itemIcons[1]);
        Item dagger = new Item("대검", itemIcons[2]);
        Item hammer = new Item("망치", itemIcons[3]);
        Item helmet = new Item("투구", itemIcons[4]);
        Item potionblue = new Item("파란포션", itemIcons[5]);
        Item potionred = new Item("빨간포션", itemIcons[6]);
        Item spear = new Item("창", itemIcons[7]);
        Item wand = new Item("완드", itemIcons[8]);
        Item letter = new Item("편지", itemIcons[9]);
        Item map = new Item("지도", itemIcons[10]);


        Character.AddItem(axe);
        Character.AddItem(bow);
        Character.AddItem(dagger);
        Character.AddItem(hammer);
        Character.AddItem(helmet);
        Character.AddItem(potionblue);
        Character.AddItem(potionred);
        Character.AddItem(spear);
        Character.AddItem(wand);
        Character.AddItem(letter);
        Character.AddItem(map);


        UIManager.Instance.UIMainMenu.SetCharacterInfo(Character);
        UIManager.Instance.UIStatus.SetStatus(Character);
        UIManager.Instance.UIInventory.InitInventoryUI(Character.Inventory);
    }
}
