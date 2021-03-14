using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourPlatform : MonoBehaviour
{
    public delegate void MouseDownHandler();

    public MouseDownHandler mouseDownHandler;

    void OnMouseDown() {
        this.mouseDownHandler();
    }
}
