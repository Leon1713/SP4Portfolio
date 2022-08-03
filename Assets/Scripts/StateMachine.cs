using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// sort of migration of sm from cpp to unity
public class StateMachine  // attach to obj
{
    Dictionary<string, State> keyValues = new Dictionary<string, State>();
    public StateMachine(string name)
    {
        stateUser = name; 
    }
    State currState = null;
    State nextState = null;
    string stateUser;
    
    public string getCurrState()
    {
        string temp = "no such state";
        foreach(string key in keyValues.Keys)
        {
            if(keyValues[key] == currState)
            {
                temp = key;
                return temp;
            }
        }
        return temp;
    }
    public void addState(string stateName, State state)
    {
        if(state == null)
        {
            return;
        }
        if(currState == null)
        {
            currState = nextState = state;
        }
        keyValues.Add(stateName, state);
    }

    public void setNextState(string name)
    {
        State temp = null;
        keyValues.TryGetValue(name, out temp);
        if(temp == null)
        {
            Debug.Log("no state could be found with " + name + " did u forget to add state ?");
        }
        else
        {
            nextState = temp;
        }
    }

    public void update()
    {
        if (currState == null && nextState == null)
        {
            return;
        }
       else if(nextState != null)
       {
            currState.exit();
            currState = nextState;
            currState.enter();
            nextState = null;
            return;
       }
       else if(currState != null)
       {
            currState.update();
       }
    }



}
