using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private float y_pos;

    private void Start()
    {
        y_pos = transform.position.y;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, y_pos, transform.position.z);
    }
}
