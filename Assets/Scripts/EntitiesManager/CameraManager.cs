using UnityEngine;

public class CameraManager : MonoBehaviour
{ 
    public float y_pos = 2F;

    void Update()
    {
       transform.position = new Vector3(transform.position.x, - y_pos, transform.position.z);
    }
}