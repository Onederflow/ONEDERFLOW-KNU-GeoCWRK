using UnityEngine;
[ExecuteInEditMode]
public class LookAtPoint : MonoBehaviour
{
    public Vector3 centerOfPlanet;

    public void UpdateX()
    {
        Vector3 diff = (new Vector3(transform.position.x, transform.position.y, 0.0f) - new Vector3(centerOfPlanet.x, centerOfPlanet.y, 0.0f));//.normalized;
        Quaternion quaterX = Quaternion.AngleAxis(Mathf.Rad2Deg * Mathf.Atan2(diff.x, diff.y), Vector3.back);
        transform.rotation = quaterX;
    }
    public void Update()
    {
        Vector3 diff = (new Vector3(transform.position.x, transform.position.y, 0.0f) - new Vector3(centerOfPlanet.x, centerOfPlanet.y, 0.0f));//.normalized;
        Quaternion quaterX = Quaternion.AngleAxis(Mathf.Rad2Deg * Mathf.Atan2(diff.x, diff.y), Vector3.back);
        transform.rotation = quaterX;
    }
}