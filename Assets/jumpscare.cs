using UnityEngine;


public class jumpscare : MonoBehaviour
{
    public GameObject Picture;


    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) { // Player => Monster
            Picture.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
    }
}
