using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ScriptableEvent")]
public class ScriptableEvent : ScriptableObject, ISerializationCallbackReceiver
{
    private List<ScriptableEventListener> listenerList  = new();

    public void Register(ScriptableEventListener _listener)
    {
        listenerList.Add(_listener);
    }

    public void UnRegister(ScriptableEventListener _listener)
    {
        if (listenerList.Count <= 0)
            return;

        listenerList.Remove(_listener);
    }

    public void RaiseEvent()
    {
        // tell listeners that event was raised
        for (int i = 0; i < listenerList.Count; i++)
        {
            listenerList[i].OnEventRaised();
        }
    }

    public void OnBeforeSerialize()
    {
        //throw new System.NotImplementedException();
    }

    public void OnAfterDeserialize()
    {
        listenerList.Clear();
    }
}
