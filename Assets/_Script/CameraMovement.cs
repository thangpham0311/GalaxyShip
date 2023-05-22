using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5f; // tốc độ di chuyển

    // Update is called once per frame
    void Update()
    {
        // di chuyển camera về phía trước theo hướng forward
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
