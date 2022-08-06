using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class moving : MonoBehaviour
{
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w")){
        transform.Translate(Vector2.up*speed*Time.deltaTime, Space.World);}
          if(Input.GetKey("s")){
        transform.Translate(Vector2.down*speed*Time.deltaTime, Space.World);}  
        if(Input.GetKey("d")){
        transform.Translate(Vector2.right*speed*Time.deltaTime, Space.World);}
          if(Input.GetKey("a")){
        transform.Translate(Vector2.left*speed*Time.deltaTime, Space.World);}
        
    }
    
    private void OnCollisionEnter2D(Collision2D Monster){
    Destroy(gameObject);}
}
