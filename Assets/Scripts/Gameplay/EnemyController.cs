using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform _target;
    [SerializeField]
    float speed;
    [SerializeField]
    float minRange;
    [SerializeField]
    float maxRange;
    // Start is called before the first frame update
    void Start()
    {
        _target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //followPlayer();
        if(Vector3.Distance(transform.position, _target.position) <= maxRange && Vector3.Distance(_target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
    }
    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, speed * Time.deltaTime);
    }
}
