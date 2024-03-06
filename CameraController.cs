using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeeds;
    public int screenEdge = 50;
    public float zoomSpeed;
    public float minY, maxY;

    public bool canMove;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canMove = !canMove;
        }

        if (!canMove)
        {
            return;
        }
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y > Screen.height - screenEdge)
        {
            transform.Translate(Vector3.right * panSpeeds * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y < screenEdge)
        {
            transform.Translate(Vector3.left * panSpeeds * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x < screenEdge)
        {
            transform.Translate(Vector3.forward * panSpeeds * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x > Screen.width - screenEdge)
        {
            transform.Translate(Vector3.back * panSpeeds * Time.deltaTime, Space.World);
        }

        float wheel = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= wheel * zoomSpeed;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
