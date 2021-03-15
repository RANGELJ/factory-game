using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainCamera : MonoBehaviour {
    public float speed = 0.01F;

    void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if (
                !EventSystem.current.IsPointerOverGameObject(touch.fingerId)
                && touch.phase == TouchPhase.Moved
            ) {
                Vector2 touchDeltaPosition = touch.deltaPosition;
                transform.Translate(
                    -touchDeltaPosition.x * speed,
                    -touchDeltaPosition.y * speed,
                    0
                );
            }
        }
    }
}
