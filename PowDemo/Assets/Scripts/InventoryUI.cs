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

    void updateInventoryUI() {                          // updates inventory ui with the help of InventorySlot
        //print("updating inventory ui");
        //for (int i = 0; i < slots.Length; i++)
        //{
        //    if (i<7)
        //    {
        //        slots[i].addItem(inventory.things[i]);
        //    }
        //    else
        //    {
        //        slots[1].clearSlot();
        //    }
        //}
        updateStarText();
    }

    private void updateStarText()
    {
        starText.text = ScoreKeeper.score.ToString();
    }
}