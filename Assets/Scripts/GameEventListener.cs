using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IListener
{
    [SerializeField]
    [Tooltip("The event that this listener is waiting for.")]
    private Event _event;

    [SerializeField]
    [Tooltip("The actions to perform when the event is raised.")]
    private UnityEvent _actions = new UnityEvent();

    [SerializeField]
    [Tooltip("The GameObject that will raise this event. " +
        "Actions are only performed when this game object raises the event.")]
    private GameObject _intendedSender;
    
    /// <summary>
    /// Initializes all default values
    /// </summary>
    /// <param name="listenerEvent">The event this object should listen for</param>
    /// <param name="sender">The game object that will raise this event</param>
    public void Init(Event listenerEvent, GameObject sender = null)
    {
        _event = listenerEvent;
        _intendedSender = sender;
        _actions = new UnityEvent();
    }

    void Start()
    {
        if (!_event)
            _event = ScriptableObject.CreateInstance<Event>();

        _event.AddListener(this);
    }

    public void AddAction(UnityAction action)
    {
        if(_actions == null)
            _actions = new UnityEvent();

        _actions.AddListener(action);
    }

    public void ClearAction()
    {
        _actions.RemoveAllListeners();
    }

    public void Invoke(GameObject sender = null)
    {
        if (_intendedSender == sender || _intendedSender == null)
            _actions?.Invoke();
    }
}
