using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Character
{
    public string Name { get; private set; }
    public int Attack { get; private set; }   // 기본 공격력
    public int Defense { get; private set; }  // 기본 방어력
    public int Health { get; private set; }
    public float Critical { get; private set; }
    public int Level { get; private set; }
    public int CurrentExp { get; private set; }
    public int MaxExp { get; private set; }
    public List<Item> Inventory { get; private set; }
    public Item EquippedWeapon { get; private set; }
    public Item EquippedArmor { get; private set; }

    public Character(string name, int attack, int defense, int health, float critical,
                     int level, int currentExp, int maxExp)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
        Health = health;
        Critical = critical;
        Level = level;
        CurrentExp = currentExp;
        MaxExp = maxExp;

        Inventory = new List<Item>();
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
    }

    public void Equip(Item item)
    {
        if (item.ItemType != ItemType.Equipment) return;

        if (item.EquipType == EquipType.Weapon)
        {
            if (EquippedWeapon != null)
                UnEquip(EquippedWeapon);

            EquippedWeapon = item;
        }
        else if (item.EquipType == EquipType.Armor)
        {
            if (EquippedArmor != null)
                UnEquip(EquippedArmor);

            EquippedArmor = item;
        }

        item.IsEquipped = true;

        UIManager.Instance.UIStatus.SetStatus(this);
        UIManager.Instance.UIInventory.UpdateUI();
    }

    public void UnEquip(Item item)
    {
        if (!item.IsEquipped) return;

        if (item == EquippedWeapon)
            EquippedWeapon = null;
        else if (item == EquippedArmor)
            EquippedArmor = null;

        item.IsEquipped = false;

        UIManager.Instance.UIStatus.SetStatus(this);
        UIManager.Instance.UIInventory.UpdateUI();
    }

    public int GetTotalAttack()
    {
        int total = Attack;
        foreach (var item in Inventory)
        {
            if (item.IsEquipped)
                total += item.BonusAttack;
        }
        return total;
    }

    public int GetTotalDefense()
    {
        int total = Defense;
        foreach (var item in Inventory)
        {
            if (item.IsEquipped)
                total += item.BonusDefense;
        }
        return total;
    }
}

