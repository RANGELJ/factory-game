using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    void Update() {
        if (Input.GetAxis("Mouse ScrollWheel")) {
            // forward
            Debug.Log("Forward");
        }
    }
}
