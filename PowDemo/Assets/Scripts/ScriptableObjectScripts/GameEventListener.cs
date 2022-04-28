using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with")]
    public GameEvent gameEvent;

    [Tooltip("Response to invoke when event is raised")]
    public UnityEvent response;

    // public UnityEvent<int> responseThingsCount;

    private void OnEnable()
    {
        gameEvent.registerListener(this);
    }

    private void OnDisable()
    {
        gameEvent.unregisterListener(this);
    }

    public void onEventRaised()
    {
        response.Invoke();
    }

    //public void onEventRaised(int thingsCount)
    //{
    //    responseThingsCount.Invoke(thingsCount);
    //}
}
