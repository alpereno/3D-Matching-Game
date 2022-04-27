using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;
    InventorySlot[] slots;
    [SerializeField] TMP_Text starText;

    private void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChanged += updateInventoryUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // we have to access current index in things so why I couldn't use ScriptableObject Event System right there
    void updateInventoryUI() {                          // updates inventory ui with the help of InventorySlot
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.things.Count)
            {
                slots[i].addItemIcon(inventory.things[i].icon);
            }
            else
            {
                slots[i].clearSlot();
            }
        }
        updateStarText();
    }

    private void updateStarText()
    {
        starText.text = ScoreKeeper.score.ToString();
    }
}
