using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveController : Singleton<MoveController>
{

    enum MovePhase { Idle, Moving }

    // Start is called before the first frame update
    abstract public void MoveTo(Vector2 to);

    // Update is called once per frame
    void Update()
    {
        
    }
}
