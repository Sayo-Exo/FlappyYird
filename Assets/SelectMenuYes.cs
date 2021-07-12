using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMenuYes : MonoBehaviour
{
    public static bool HAHAGETRICKROLLEDLMAO;
    public GameObject rickman;
    public GameObject bg;
    public AudioSource susus;
    private bool playwow;
    public SpriteRenderer fadeyes;
    public GameObject AREYOUSUREYOUWANTTODELETEYOURSAVEDATA;
    // Start is called before the first frame update

    void Start()
    {
        fadeyes.gameObject.SetActive(true);
        if (HAHAGETRICKROLLEDLMAO) {
            bg.SetActive(false);
            rickman.SetActive(true);
        }
        StartCoroutine(fadeOut(fadeyes, 0.2f));
    }

    public void resetDataPrompt() {
        AREYOUSUREYOUWANTTODELETEYOURSAVEDATA.SetActive(true);
    }

    public void resetData() {
        PlayerPrefs.SetInt("bestScore", 0);
        PlayerPrefs.SetString("currentBird", "DEFAULT");
        PlayerPrefs.SetString("currentPipe", "GREEN");
        AREYOUSUREYOUWANTTODELETEYOURSAVEDATA.SetActive(false);
    }

    public void dontResetData() {
        AREYOUSUREYOUWANTTODELETEYOURSAVEDATA.SetActive(false);
    }

    public void play() {
        StartCoroutine(startplay());
    }

    public void dressup() {
        StartCoroutine(startplay("CosmeticSelect"));
    }

    public void multiplayerwoooo() {
        StartCoroutine(startplay("Lobby"));
    }

    IEnumerator startplay(string sussus_amogus = "Game") {
        susus.PlayOneShot(susus.clip);
        StartCoroutine(fadeIn(fadeyes));
        GameSetupController.multiplayer = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sussus_amogus);
    }

    IEnumerator fadeIn(SpriteRenderer img, float waitTime = 0) {
        yield return new WaitForSeconds(waitTime);
        if (playwow)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }

    IEnumerator fadeOut(SpriteRenderer img, float waitTime = 0) {
        yield return new WaitForSeconds(waitTime);
        if (!playwow)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }
}
