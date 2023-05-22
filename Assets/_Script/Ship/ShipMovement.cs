using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 5f; // tốc độ di chuyển
    [SerializeField] protected float horizontalInput; // tốc độ di chuyển
    [SerializeField] protected float verticalInput; // tốc độ di chuyển
    [SerializeField] protected float distanceFromEdge = 0.7f;// khoảng cách giữa nhân vật và cạnh màn hình

    // giới hạn vị trí của nhân vật
    private float minX, maxX, minY, maxY;
    //private void Start()
    //{
    //    //tính toán giới hạn vị trí của nhân vật bằng kích thước của màn hình
    //    minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + distanceFromEdge;
    //    maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - distanceFromEdge;
    //    minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + distanceFromEdge;
    //    maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - distanceFromEdge;
    //}
    // Update is called once per frame
    private void Update()
    {
         this.horizontalInput = Input.GetAxis("Horizontal"); // lấy giá trị đầu vào ngang từ bàn phím
         this.verticalInput = Input.GetAxis("Vertical"); // lấy giá trị đầu vào dọc từ bàn phím
    }

    private void FixedUpdate()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        Vector2 movement = new Vector2(this.horizontalInput, this.verticalInput); // tạo một vector từ các giá trị đầu vào
        transform.parent.Translate(movement * speed * Time.fixedDeltaTime); // di chuyển nhân vật dựa trên vector và tốc độ

        //// giới hạn vị trí của nhân vật bằng kích thước của màn hình
        //float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        //float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        //transform.parent.position = new Vector3(clampedX, clampedY, transform.parent.position.z);

        // giới hạn vị trí nhân vật trong camera
        Vector3 cameraPos = Camera.main.transform.parent.position;
        float cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float cameraHeight = Camera.main.orthographicSize;
        float leftLimit = cameraPos.x - cameraWidth;
        float bottomLimit = cameraPos.y - cameraHeight;
        float topLimit = cameraPos.y + cameraHeight;
        Vector3 clampedPosition = transform.parent.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, leftLimit, Mathf.Infinity);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, bottomLimit, topLimit);
        transform.parent.position = clampedPosition;
    }
}
