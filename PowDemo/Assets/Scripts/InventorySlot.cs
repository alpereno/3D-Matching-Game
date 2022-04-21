using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{                                               // The task of this class is to update every slot
    public Image icon;
    Thing thing;

    public void addItem(Thing newThing)
    {
        thing = newThing;
        icon.sprite = thing.icon;
    }

    public void clearSlot()
    {
        thing = null;
        icon.sprite = null;
    }
}
