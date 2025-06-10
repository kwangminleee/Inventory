using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Equipment, Consumable, Etc }
public enum EquipType { Weapon, Armor }

public class Item
{
    public string Name { get; private set; }
    public Sprite Icon { get; private set; }
    public ItemType ItemType { get; set; } = ItemType.Equipment;
    public EquipType EquipType { get; set; } = EquipType.Weapon;
    public int BonusAttack { get; set; } = 0;
    public int BonusDefense { get; set; } = 0;
    public bool IsEquipped { get; set; } = false;


    public Item(string name, Sprite icon)
    {
        Name = name;
        Icon = icon;
    }
}
