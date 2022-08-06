using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class moving : MonoBehaviour
{
    public float speed = 5f;

  private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("w")){
        rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);}
          if(Input.GetKey("s")){
       rb.AddForce(Vector2.down * speed, ForceMode2D.Impulse);}
        if(Input.GetKey("d")){
        rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);}
          if(Input.GetKey("a")){
        rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);}
        
    }
}
