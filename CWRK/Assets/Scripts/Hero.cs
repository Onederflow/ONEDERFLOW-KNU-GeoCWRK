using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float horizontalValue = 12f;
    public float verticalValue = 12f;
    public Transform centerOfPlanet;
    public CircleCollider2D colOfPlanet;
    Rigidbody2D rb;
    private Vector3 diff;
    public Quaternion quaterX;
    public Vector3 nexT;
    public float runSmooth = 0.06f;
    public float stopSmooth = 0.06f;
    public int countJumps = 0;
    public CameraControl cam;
    public float paralaxControl = 0;
    public float minHeroHeight;

    public float mileageAngle = 0;
    private float lastUpdateAngle = 0;
    private int countOfRuns = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Collider2D c = GetComponent<BoxCollider2D>();
        minHeroHeight = colOfPlanet.bounds.size.y / 2.0f + c.bounds.size.y / 2;
    }
    void FixedUpdate()
    {
        diff = (new Vector3(transform.position.x, transform.position.y, 0.0f) - new Vector3(centerOfPlanet.position.x, centerOfPlanet.position.y, 0.0f));//.normalized;
        quaterX = Quaternion.AngleAxis(Mathf.Rad2Deg * Mathf.Atan2(diff.x, diff.y) , Vector3.back);
        transform.rotation = quaterX;
        nexT = (Quaternion.Euler(0.0f, 0.0f, 90.0f) * diff).normalized;
        cam.direction = nexT;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsUp();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            IsUp();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Left();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Right();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            ReSet();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            ReSet();
        }


        float distantNow = Mathf.Sqrt(Mathf.Pow(cam.transform.position.x - centerOfPlanet.position.x, 2) + Mathf.Pow(cam.transform.position.y - centerOfPlanet.position.y, 2));
        paralaxControl = (distantNow - minHeroHeight);
        float tempAngle = Mathf.Rad2Deg * Mathf.Atan2(diff.x, diff.y);
        if (tempAngle <= 0)
            tempAngle += 360.0f;

        if (tempAngle >= 0.0 && tempAngle < 45.0 && lastUpdateAngle > 270.0 && lastUpdateAngle < 360.0)
            countOfRuns++;
        else if (lastUpdateAngle >= 0.0f && lastUpdateAngle < 45.0f && tempAngle > 270.0f && tempAngle < 360.0f)
            countOfRuns--;
        mileageAngle = countOfRuns * 360.0f + tempAngle;
        lastUpdateAngle = tempAngle;
    }

    private void Up(float value)
    {
        rb.AddForce(diff.normalized * value, ForceMode2D.Impulse);
    }
    public void Left()
    {
        Vector3 res = Vector3.Project(rb.velocity, diff) + nexT * horizontalValue;
        rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(res.x, res.y), runSmooth);
    }
    public void Right()
    {
        Vector3 res = Vector3.Project(rb.velocity, diff) - nexT * horizontalValue;
        rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(res.x, res.y), runSmooth);
    }

    public void ReSet()
    {
        Vector3 res = Vector3.Project(rb.velocity, diff);
        rb.velocity = Vector2.Lerp(rb.velocity,new Vector2(res.x, res.y), stopSmooth);
    }

    public void IsUp()
    {
        if (countJumps == 0)
        {
            Up(verticalValue);
            countJumps++;
        }
    }
}
