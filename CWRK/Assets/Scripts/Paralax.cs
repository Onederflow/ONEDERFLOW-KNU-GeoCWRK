using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float basicRadius;
    public float power = 1.4f;
    public float rotationRate = 1;
    public Hero hero;
    void FixedUpdate()
    {
        Vector3 temp = hero.quaterX * new Vector3(0.0f, basicRadius + power * hero.paralaxControl, 0.0f);
        Vector3 newpos = new Vector3(temp.x, temp.y, 0.0f);
        transform.position = new Vector3(temp.x, temp.y, transform.position.z);
        Quaternion quaterX = Quaternion.AngleAxis(rotationRate * hero.mileageAngle, Vector3.back);
        transform.rotation = quaterX;
    }
}
