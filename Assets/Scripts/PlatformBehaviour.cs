using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    public delegate void MouseDownHandler();

    public MouseDownHandler mouseDownHandler;

    void OnMouseDown() {
        this.mouseDownHandler();
    }
}
