using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour          // base class to reference
{
    public string thingName;
    public Sprite icon;
    //public int piece;
    //public int id;

    public void interact() {
        // do some stuff here

        pickUp();
    }

    private void pickUp()
    {
        // add to inventory
        //print("picking up stuff from Thing class Thing name is = " + thingName);
        Inventory.instance.add(this);

        Destroy(gameObject);       
    }
}
