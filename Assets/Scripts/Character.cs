using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Character
{
    public string Name { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public float Critical { get; private set; }
    public int Level { get; private set; }
    public int CurrentExp { get; private set; }
    public int MaxExp { get; private set; }
    public List<Item> Inventory { get; private set; }

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
}
