using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CosmeticScript : MonoBehaviour
{
    public Dictionary<string, string> details = new Dictionary<string, string> { };
    public Dictionary<string, string> pipeDetails = new Dictionary<string, string> { };
    public AudioSource sus;
    public Text curBird;
    public Text curPipe;
    private bool menucool;
    public GameObject birdCatalog;
    public GameObject pipeCatalog;
    public Animator defaultBirdBoi;
    public Animator redBirdBoi;
    public Animator blueBirdBoi;
    public Animator pinkBirdBoi;
    public Animator greenBirdBoi;
    public SpriteRenderer fadek;

    // Start is called before the first frame update
    void Start()
    {
        fadek.gameObject.SetActive(true);
        details.Add("BLUE", "Blue jay");
        details.Add("RED", "Cardinal/Cheep Cheep");
        details.Add("DEFAULT", "Plain ol' birdy");
        details.Add("PINK", "Pinkie");
        details.Add("GREEN", "Grass boi");
        details.Add("BROWN", "Flappy poop");
        pipeDetails.Add("GREEN", "Green pipe");
        pipeDetails.Add("RED", "Red pipe");
        if (birdCatalog.activeInHierarchy)
        {
            animatebirds();
        }
        string thing1 = PlayerPrefs.GetString("currentBird");
        if (thing1 == "") {
            thing1 = "DEFAULT";
        }
        string thing2 = PlayerPrefs.GetString("currentPipe");
        if (thing2 == "") {
            thing2 = "GREEN";
        }
        updateText(curBird, $"Bird: {thing1} - {details[thing1]}");
        updateText(curPipe, $"Pipe: {thing2} - {pipeDetails[thing2]}");
        StartCoroutine(fadeOut(fadek, 0.2f));
    }

    void animatebirds()
    {
        defaultBirdBoi.Play("DEFAULT_BIRD_FLY");
        redBirdBoi.Play("RED_BIRD_FLY");
        blueBirdBoi.Play("BLUE_BIRD_FLY");
        pinkBirdBoi.Play("PINK_BIRD_FLY");
        greenBirdBoi.Play("GREEN_BIRD_FLY");
    }

    public void selectbiRD(string bird)
    {
        sus.PlayOneShot(sus.clip);
        PlayerPrefs.SetString("currentBird", bird);
        string thing = PlayerPrefs.GetString("currentBird");
        updateText(curBird, $"Bird: {thing} - {details[thing]}");
    }
    public void selectPiPE(string pipe)
    {
        sus.PlayOneShot(sus.clip);
        PlayerPrefs.SetString("currentPipe", pipe);
        string thing = PlayerPrefs.GetString("currentPipe");
        updateText(curPipe, $"Pipe: {thing} - {pipeDetails[thing]}");
    }

    void updateText(Text text2update, string text = "oh hey code snooper fun fact red sus lmao") // gotem lol {
    {
        text2update.text = text;
    }

    public void birdshow() {
        sus.PlayOneShot(sus.clip);
        if (!birdCatalog.activeInHierarchy) {
            pipeCatalog.SetActive(false);
            birdCatalog.SetActive(true);
            animatebirds();
        }
    }

    public void pipeshow() {
        sus.PlayOneShot(sus.clip);
        if (!pipeCatalog.activeInHierarchy) {
            birdCatalog.SetActive(false);
            pipeCatalog.SetActive(true);
        }
    }

    public void menu()
    {
        StartCoroutine(domenu());
    }

    IEnumerator domenu(string menu = "MainMenu") {
        sus.PlayOneShot(sus.clip);
        StartCoroutine(fadeIn(fadek));
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(menu);
    }

    IEnumerator fadeIn(SpriteRenderer img, float waitTime = 0) {
        yield return new WaitForSeconds(waitTime);
        if (menucool)
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
        if (!menucool)
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
