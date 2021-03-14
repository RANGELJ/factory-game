using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOTranslator : MonoBehaviour
{
    private float speed = 1;
    private Vector3 targetPosition;

    private Vector3 computeDiference() {
        return this.targetPosition - transform.position;
    }

    private bool shouldApplyDiference(Vector3 difference) {
        return difference.x > 0
            || difference.x < 0
            || difference.y > 0
            || difference.y < 0
            || difference.z > 0
            || difference.z < 0;
    }

    private IEnumerator actualMoveTo() {
        Vector3 difference = this.computeDiference();

        while (this.shouldApplyDiference(difference)) {
            float step = this.speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, this.targetPosition, step);
            difference = this.computeDiference();
            yield return null;
        }
    }

    public void moveTo(float newSpeed, Vector3 newTargetPosition) {
        this.speed = newSpeed;
        this.targetPosition = newTargetPosition;
        StartCoroutine("actualMoveTo");
    }
}
