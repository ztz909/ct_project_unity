using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    float _smoothing = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame(late update in order to happen after the regular update
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            //targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            //targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothing);
        }
        
    }
}
