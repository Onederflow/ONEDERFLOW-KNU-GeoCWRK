using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform tr;
    public Camera cCamera;
    public Rigidbody2D rg;
    public float horisontalSmooth = 0.06f;
    public float vangaSmooth = 0.4f;
    public float roundSmooth = 0.06f;
    public float sizeSmooth = 0.06f;
    public Vector3 direction;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 proPos = Vector3.Project(rg.velocity, direction);
        Vector3 vanga = new Vector3(tr.position.x + proPos.x * vangaSmooth, tr.position.y + proPos.y * vangaSmooth, 0.0f);
        transform.position = Vector3.Lerp(transform.position, vanga, horisontalSmooth);
        transform.rotation = Quaternion.Lerp(transform.rotation, tr.rotation, roundSmooth);
        cCamera.orthographicSize = Mathf.Lerp(cCamera.orthographicSize, 5.0f + Mathf.Sqrt(rg.velocity.x * rg.velocity.x + rg.velocity.y * rg.velocity.y) / 10.0f, sizeSmooth);
    }
}
