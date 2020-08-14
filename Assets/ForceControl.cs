using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ForceControl : MonoBehaviour
{
    [SerializeField]
    float forceMagnitude = 1f;
    [SerializeField]
    float torqueMagnitude = 1f;
    [SerializeField]
    int targetFramerate = -1;

    Vector3 inputDir;
    Vector3 inputRot;
    Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        CheckTargetFrameRate();

        inputDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) {
            inputDir += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputDir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputDir += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputDir += Vector3.right;
        }

        inputRot = Vector3.zero;
        if (Input.GetKey(KeyCode.Q)) {
            inputRot += Vector3.down;
        }
        if (Input.GetKey(KeyCode.E)) {
            inputRot += Vector3.up;
        }
    }

    private void CheckTargetFrameRate() {
        if (this.targetFramerate != Application.targetFrameRate) {
            Application.targetFrameRate = this.targetFramerate;
        }
    }

    void FixedUpdate() {
        Vector3 force = inputDir.normalized * forceMagnitude;
        force = rb.rotation * force;

        rb.AddForce(force);
        rb.AddTorque(inputRot.normalized * torqueMagnitude);
    }
}
