using UnityEngine;
[ExecuteInEditMode]
public class CenterRotation : MonoBehaviour
{
    public Transform centerOfPlanet;
    public void ToCenter()
    {
        Vector3 diff = (new Vector3(transform.position.x, transform.position.y, 0.0f) - new Vector3(centerOfPlanet.position.x, centerOfPlanet.position.y, 0.0f));//.normalized;
        Quaternion quaterX = Quaternion.AngleAxis(Mathf.Rad2Deg * Mathf.Atan2(diff.x, diff.y), Vector3.back);
        transform.rotation = quaterX;
    }
    private void Update()
    {
        ToCenter();
    }
}
