using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourPlatform : MonoBehaviour
{
    private GameObject item;

    public delegate void MouseDownHandler();

    public MouseDownHandler mouseDownHandler;

    public void OnMouseDown() {
        this.mouseDownHandler();
    }

    public void setItem(GameObject itemPrefab) {
        if (this.item != null) {
            Destroy(this.item);
            this.item = null;
        }

        this.item = Instantiate(
            itemPrefab,
            this.transform.position,
            Quaternion.identity
        );
    }
}
