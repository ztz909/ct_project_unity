using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifetime;
    private void Update()
    {
        Destroy(gameObject, lifetime);
    }
}