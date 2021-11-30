using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HUDState{
    public void EnterState(HUDController ctx);
    public void OnStateExit();
}
