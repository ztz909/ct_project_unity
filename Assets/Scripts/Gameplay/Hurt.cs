using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hurt : MonoBehaviour
{
    float _waitToLoad = 2.0f;
    bool _reloading;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_reloading)
        {
            _waitToLoad -= Time.deltaTime;
            if(_waitToLoad <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            _reloading = true;
        }

    }
}
