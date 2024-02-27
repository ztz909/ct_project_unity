using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EffectPosition : MonoBehaviour
{
    [SerializeField] Transform target;

    private Vector3 _targetPosition;
    
    private float _smoothing = 1.0f;
    private void Start()
    {
        //target = GetComponentInParent<Transform>();
        _targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
    private void Update()
    {
        if (transform.position != target.position)
        {
            _targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            //targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            //targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, _targetPosition, _smoothing);
        }
    }
}
