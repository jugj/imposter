using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscare : MonoBehaviour
{
    public GameObject Picture;

    public GameObject gobj;

    public Main main;

    private UnityEngine.Rendering.Volume volume;

    Vector3 podest_pos;

    void Start() {
        volume = gobj.GetComponent<UnityEngine.Rendering.Volume>();
    }


    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Monster")) {
            main.gameOver = true;
            volume.enabled = false;
            Picture.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
    }
}
