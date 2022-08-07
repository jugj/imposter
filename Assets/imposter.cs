using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imposter : MonoBehaviour
{
    public int n = 0;

    public Main manager;

    Vector3 podest_pos;
    // Start is called before the first frame update
    void Start()
    {
         podest_pos = this.transform.position;

        float posx = Random.Range(-10.0f, 10.0f);
        float posy = Random.Range(-10.0f, 10.0f);

        this.transform.position = new Vector3(posx, posy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
                manager.CollectImposter(this.n);
                
            this.transform.position = podest_pos;
        }
    }
}
