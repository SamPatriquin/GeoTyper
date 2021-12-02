using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] Transform target;
    [SerializeField] float cameraSmoothing = 0.5f;

    private void FixedUpdate() {
        float xPos = Mathf.Lerp(this.transform.position.x, target.transform.position.x, cameraSmoothing * Time.deltaTime);
        float yPos = Mathf.Lerp(this.transform.position.y, target.transform.position.y, cameraSmoothing * Time.deltaTime);
        this.transform.position = new Vector3(xPos, yPos, this.transform.position.z);
    }
}
