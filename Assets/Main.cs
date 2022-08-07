using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public moving moving;
    public monster monster;

    public bool fog_enabled = true;

    public int object_count;

    public bool gameOver = false;

    private TextMeshProUGUI text;
    public GameObject text_object;

    public GameObject templates_obj;

    public GameObject gobj;

    public GameObject spawn_object;
    private UnityEngine.Rendering.Volume volume;

    public GameObject restart_btn;
    public GameObject exit_btn;

    public GameObject win_screen;

    // Start is called before the first frame update
    void Start()
    {
        start = Time.time;
        volume = gobj.GetComponent<UnityEngine.Rendering.Volume>();
        text = text_object.GetComponent<TextMeshProUGUI>();

        SpawnObjects();
    }

    string[] dialog = {
        "Seit 40 Jahren arbeite ich in diesem Kraftwerk...",
        "Und jetzt bin ich zum ersten mal eingeschlossen.",
        "Um zu enkommen, muss ich alle 4 Sussy-Imposter finden.",
        "Oh nein, etwas stimmt nicht mit dem Licht und ich höre Geräusche!!!"
    };

    public float dialog_time = 1;

    float start;

    bool[] imposters = { false, false, false, false };

    string c_text = "";
    float text_start;

    void SetText(string text)
    {
        this.c_text = text;
        text_start = Time.time;
    }

    bool started = false;

    // Update is called once per frame
    void Update()
    {
        float current_time = Time.time - start;
        if (!gameOver)
        {
            if (current_time > dialog.Length * dialog_time)
            {
                started = true;
                text.text = c_text;
                if (Time.time - text_start > dialog_time)
                {
                    this.c_text = "";
                }
                volume.enabled = fog_enabled;
                moving.moving_enabled = true;
                monster.moving_enabled = true;
            }
            else
            {
                int idx = (int)(current_time / dialog_time);
                if (idx >= 0 && idx <= dialog.Length)
                {
                    text.text = dialog[idx];
                }
                moving.moving_enabled = false;
                monster.moving_enabled = false;
            }
        } else {
            restart_btn.SetActive(true);
            exit_btn.SetActive(true);
        }
    }

    void SpawnObjects()
    {
        Transform[] childs = templates_obj.GetComponentsInChildren<Transform>();
        for (int i = 0; i < object_count; i++)
        {
            GameObject randomObject = childs[Random.Range(0, childs.Length)].gameObject;
            if (randomObject == templates_obj)
            {
                i--;
                continue;
            }

            float posx = Random.Range(-10.0f, 10.0f);
            float posy = Random.Range(-10.0f, 10.0f);
            GameObject new_obj = Instantiate(randomObject, spawn_object.transform);
            new_obj.transform.position = new Vector3(posx, posy);

            new_obj.SetActive(true);
        }
    }

    string[] imposter_colors = {
            "grünen", "roten", "rosa", "blauen"
        };

    public void CollectImposter(int i)
    {
        if (i >= 0 && i <= 3)
        {
            this.imposters[i] = true;
            SetText("Yay, ich habe den " + imposter_colors[i] + " Imposter gefunden!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && started)
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                if (!this.imposters[i])
                {
                    count++;
                }
            }
            if (count > 0)
            {
                SetText("Ich muss noch " + count + " weitere Imposter finden!");
            }
            else
            {
                gameOver = true;
                monster.moving_enabled = false;
                moving.moving_enabled = false;
                win_screen.SetActive(true);
                volume.enabled = false;
            }
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
