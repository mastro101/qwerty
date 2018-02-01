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
            if(OnStateChange(value) == true)
                _currentState = value;
            else
                Debug.Log("Nope");
        }
    }

    private State _currentState;

    bool OnStateChange(State newState)
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



    private void Start()
    {
        CurrentState = State.Setup;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CurrentState = State.Strategic;

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
}
