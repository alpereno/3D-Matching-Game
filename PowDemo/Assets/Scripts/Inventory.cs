using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event System.Action onItemChanged;       // to update InventoryUI
    public event System.Action onGameOver;          // to deactive controller and gameOver
    public event System.Action onMatching;          // to add score when onMatching
    public static Inventory instance;

    public List<Thing> things = new List<Thing>();
    private int slotNumber = 7;

    private void Awake()
    {
        if (instance != null)
        {
            print("2 or more instance ");
            // destroy this ?
            //return;
        }
        instance = this;
    }


    public void add(Thing thingToAdd) {     // when touching an object adds it to the inventory
        if (things.Count < slotNumber )     // checks limits
        {
            things.Add(thingToAdd);
            int i = 0;

            foreach (Thing inventoryItem in things)     // checks an object is the same type as the object touching
            {
                if (inventoryItem .GetType() == thingToAdd.GetType())
                {
                    i++;
                    print(inventoryItem.GetType()+" " + i);
                }
            }
            if (i == 3)                                 // if there are 3 object of the same type destroys them and gives points
            {
                //print("item to be remove = " + thingToAdd.thingName);
                removeThings(thingToAdd);
                if (onMatching != null)
                {
                    onMatching();
                }
            }

            if (onItemChanged != null)
            {
                onItemChanged();
            }
        }
        else
        {
            // game over event
            print("Index out of range and things count = " + things.Count);
            if (onGameOver != null)
            {
                onGameOver();
            }
            return;
        }
    }

    void removeThings(Thing thingToRemove)          // if there was a match it will destroy them
    {
        int[] indexes = new int[7];
        int[] indexofRemove = new int[3];
        int x = 0;
        int i = 0;
        foreach (Thing item in things)
        {
            if (item.GetType() == thingToRemove.GetType())
            {
                indexes[i] = things.IndexOf(thingToRemove);
                // print("silinecek indisler = " + i);
                indexofRemove[x] = i;
                x++;
                i++;
            }
            else
            {
                i++;
            }
        }
        remove(indexofRemove[2]);
        remove(indexofRemove[1]);
        remove(indexofRemove[0]);
    }

    public void remove(int index) {
        things.RemoveAt(index);
    }

    private void printList()
    {
        print("--------------");
        foreach (Thing item in things)
        {
            print(item.thingName);
        }
    }
}
