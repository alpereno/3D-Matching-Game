using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> eventListeners = new List<GameEventListener>();


    public void raise()
    {
        for (int i = eventListeners.Count-1; i >= 0 ; i--)
        {
            eventListeners[i].onEventRaised();
        }
    }

    //public void raise(int thingsCount)
    //{
    //    for (int i = eventListeners.Count - 1; i >= 0; i--)
    //    {
    //        eventListeners[i].onEventRaised(thingsCount);
    //    }
    //}

    public void registerListener(GameEventListener eventListener)
    {
        if (!eventListeners.Contains(eventListener))
        {
            eventListeners.Add(eventListener);
        }
    }

    public void unregisterListener(GameEventListener eventListener) 
    {
        if (eventListeners.Contains(eventListener))
        {
            eventListeners.Remove(eventListener);
        }
    }
}
