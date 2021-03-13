using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float TouchZoomSpeed = 0.1f;
    public float ZoomMinBound = 0.1f;
    public float ZoomMaxBound = 179.9f;

    private Camera cam;

    void Start() {
        cam = GetComponent<Camera>();
    }

    void Zoom(float deltaMagnitudeDiff, float speed) {
        cam.fieldOfView += deltaMagnitudeDiff * speed;
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, ZoomMinBound, ZoomMaxBound);
    }

    void Update() {
        if (Input.touchSupported && Input.touchCount == 2) {
            if (Input.touchCount == 2) {
                Touch tZero = Input.GetTouch(0);
                Touch tOne = Input.GetTouch(1);

                Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                float oldTouchDistance = Vector2.Distance (tZeroPrevious, tOnePrevious);
                float currentTouchDistance = Vector2.Distance (tZero.position, tOne.position);

                float deltaDistance = oldTouchDistance - currentTouchDistance;
                this.Zoom(deltaDistance, TouchZoomSpeed);
            }
        }
    }
}
