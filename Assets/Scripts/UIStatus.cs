using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TMP_Text attackText;
    [SerializeField] private TMP_Text defenseText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text criticalText;

    public void SetStatus(Character character)
    {
        attackText.text = $"{character.GetTotalAttack()}";
        defenseText.text = $"{character.GetTotalDefense()}";
        healthText.text = $"{character.Health}";
        criticalText.text = $"{character.Critical}";
    }

}
