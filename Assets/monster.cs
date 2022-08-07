using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    private Camera cam;
    public float speed = 5f;

    public float max_distance = 10f;
    public float teleport_distance = 5f;

    public bool moving_enabled = false;

    public GameObject player;

    private Plane[] planes;

    // Start is called before the first frame update
    SpriteRenderer spi;
    private Rigidbody2D rb;

    void Start()
    {
        spi = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving_enabled)
        {
            float distance = (player.transform.position - transform.position).magnitude;
            if (distance > max_distance)
            {
                Vector2 rnd = Random.insideUnitCircle.normalized * teleport_distance;
                Vector3 toPos;
                toPos.x = rnd.x;
                toPos.y = rnd.y;
                toPos.z = transform.position.z;

                 // Play a noise if an object is within the sphere's radius.
                if (Physics2D.OverlapCircle(player.transform.position + toPos, 3, LayerMask.GetMask("Collisions")) != null)
                { 
                   Debug.Log("no Teleport");
                } else {
                    Debug.Log("Teleport");
                    transform.Translate((player.transform.position + toPos) - transform.position);
                }
            }

            Vector3 dir = (player.transform.position - transform.position).normalized;
            if (dir.x < 0)
            {
                spi.flipX = true;
            }
            else
            {
                spi.flipX = false;
            }

            rb.AddForce(dir * speed, ForceMode2D.Impulse);
        }
    }
}
