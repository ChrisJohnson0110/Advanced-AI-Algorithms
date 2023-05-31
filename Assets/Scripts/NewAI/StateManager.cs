using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State sCurrentState;


    // Start is called before the first frame update
    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = sCurrentState?.RunCurrentState(); //if not null run next state

        if (nextState != null)
        {
            //switch to the next state
            SwitchToTheNextState(nextState);
        }

    }

    /// <summary>
    /// switch the current state to the given state
    /// </summary>
    /// <param name="a_sNextState"></param>
    private void SwitchToTheNextState(State a_sNextState)
    {
        sCurrentState = a_sNextState;
    }

}
