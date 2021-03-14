using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourGenerator : MonoBehaviour {
    public int energyOutput = 10;
    public int fuel = 100;

    void Update() {
        if (PlatformsGrid.EXECUTE_UPDATE) {
            if (this.fuel > 0) {
                fuel -= 1;
            }
        }
    }
}
