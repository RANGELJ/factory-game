using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private float maxHeight = 50f;
    private float minHeight = 5f;

    void Update() {
        float yPosition = transform.position.y;

        if (
            (yPosition < this.maxHeight && Input.GetAxis("Mouse ScrollWheel") > 0)
            || (yPosition > this.minHeight && Input.GetAxis("Mouse ScrollWheel") < 0)
        ) {
            transform.position = new Vector3(
                transform.position.x,
                yPosition + Input.GetAxis("Mouse ScrollWheel"),
                transform.position.z
            );
        }
    }
}
