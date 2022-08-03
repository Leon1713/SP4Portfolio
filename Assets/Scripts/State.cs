using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public GameObject objectReference;
    public virtual void enter()
    {
        
    }

    public virtual void update()
    {

    }

    public virtual void exit()
    {

    }
}
