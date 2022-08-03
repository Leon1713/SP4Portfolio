using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFireExplode : MonoBehaviour
{
    public GameObject explosionFirePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Instantiate(explosionFirePrefab, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
