using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour {

    public enum State
    {
        Setup,      // = 0
        Strategic,  // = 1
        Combat,     // = 2
        End,        // = 3
    }

    public State CurrentState
    {
        get
        {
            return _currentState;
        }
        set
        {
            if (CheckStateChange(value) == true)
            {
                OnStateEnd(_currentState);
                _currentState = value;                
                OnStateStart(_currentState);
            }
            else
                Debug.Log("Nope");
        }
    }

    private State _currentState;

    #region StateMachine
    /// <summary>
    /// Chiamatoi dopo aver settato un nuovo state come current <paramref name="newState"/>
    /// </summary>
    /// <param name="newState"></param>
    void OnStateStart(State newState)
    {
        switch (newState)
        {
            case State.Setup:
                Debug.Log("Enter" + CurrentState);
                break;
            case State.Strategic:
                Debug.Log("Enter" + CurrentState);                
                break;
            case State.Combat:
                Debug.Log("Enter" + CurrentState);
                break;
            case State.End:
                Debug.Log("Enter" + CurrentState);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Controlla in che current sei
    /// </summary>
    void OnStateUpdate()
    {
        switch (CurrentState)
        {
            case State.Setup:
                Debug.Log("Setup");
                break;
            case State.Strategic:
                Debug.Log("Strategic");
                break;
            case State.Combat:
                Debug.Log("Combat");
                break;
            case State.End:
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Chiamata prima di uscire dallo stato <paramref name="oldState"/>
    /// </summary>
    /// <param name="oldState"></param>
    void OnStateEnd(State oldState)
    {
        switch (oldState)
        {
            case State.Setup:
                Debug.Log("Exit" + CurrentState);
                break;
            case State.Strategic:
                Debug.Log("Exit" + CurrentState);
                break;
            case State.Combat:
                Debug.Log("Exit" + CurrentState);
                break;
            case State.End:
                Debug.Log("Exit" + CurrentState);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Controlla se è possibile cambiare lo stato in quello richiesto in <paramref name="newState"/>
    /// </summary>
    /// <param name="newState"></param>
    /// <returns></returns>
    bool CheckStateChange(State newState)
    {
        switch (newState)
        {
            case State.Setup:
            case State.Strategic:
                if (CurrentState != State.Setup)
                    return false;
                return true;
                break;
            case State.Combat:
                if (CurrentState != State.Strategic)
                    return false;
                return true;
                break;
            case State.End:
                if (CurrentState != State.Combat)
                    return false;
                return true;
                break;
            default:
                return false;
                break;
        }
    }
    #endregion

    private void Start()
    {
        CurrentState = State.Setup;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            CurrentState = State.Setup;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            CurrentState = State.Setup;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            CurrentState = State.Setup;
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            CurrentState = State.Setup;

        OnStateUpdate();
    }
}
