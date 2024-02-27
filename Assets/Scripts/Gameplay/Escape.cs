using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{

    [SerializeField] private GameObject effect;
    //[SerializeField] private Transform target;
    
    private float _smoothing = 1.0f;
    private Vector3 targetPosition;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        Instantiate(effect, transform.position, transform.rotation);
        FindObjectOfType<PlayerController>().IncreaseFreedom();
        Destroy(gameObject);
    }
}
