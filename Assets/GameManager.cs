using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string currentBird = "DEFAULT";
    public static string currentPipe = "GREEN";
    public string curScene;
    [Header("Game Over")]
    public Canvas gameOverCanvas;
    public GameObject gameOverCanvasHolder;
    private Animator gameOverCanvasHolderAnim;
    public Text gameOverScore;
    public Text _gameOverBestScore;
    public static Text gameOverBestScore;
    public GameObject NEWWWWWWWWWWWWWWWWWWWWWWWWWRECORD;

    public Button pauseButton;
    public Sprite pauseSprite;
    public Sprite playSprite;

    [Header("pog sounds lol")]
    private static AudioSource hit;
    public AudioSource _hit;
    private static AudioSource die;
    public AudioSource _die;
    private static AudioSource point;
    public AudioSource _point;
    private static AudioSource swooshing;
    public AudioSource _swooshing;
    private static AudioSource wing;
    public AudioSource _wing;

    public SpriteRenderer blackFade;

    public static int score;
    public static int bestScore;
    private static Text scoreText;
    public Text _scoreText;

    private bool openFade;
    private bool paused;

    private static bool STOPSTOPHESALREADYDEAD = false;

    public Canvas Sus;

    public static GameObject ground;
    public GameObject _ground;
    public static GameManager instance;

    void Start()
    {
        instance = this;
        blackFade.gameObject.SetActive(true);
        currentBird = PlayerPrefs.GetString("currentBird");
        currentPipe = PlayerPrefs.GetString("currentPipe");
        bestScore = PlayerPrefs.GetInt("bestScore");
        curScene = SceneManager.GetActiveScene().name;
        hit = _hit;
        die = _die;
        point = _point;
        swooshing = _swooshing;
        wing = _wing;
        scoreText = _scoreText;
        gameOverBestScore = _gameOverBestScore;
        ground = _ground;
        gameOverCanvasHolderAnim = gameOverCanvasHolder.GetComponent<Animator>();
        score = 0;
        STOPSTOPHESALREADYDEAD = false;
        StartCoroutine(fadeOut(blackFade, 0.5f));
    }

    public void pause() {
        if (paused) {
            paused = false;
            pauseButton.GetComponent<Image>().sprite = pauseSprite;
            Time.timeScale = 1f;
        } else {
            paused = true;
            pauseButton.GetComponent<Image>().sprite = playSprite;
            Time.timeScale = 0f;
        }
        Sus.gameObject.SetActive(paused);
    }

    // tankman ascends

    public static void gameOver() {
        if (STOPSTOPHESALREADYDEAD) {
            return;
        }
        STOPSTOPHESALREADYDEAD = true;
        hit.PlayOneShot(hit.clip);
        instance.gameOverScore.text = "" + score;
        if (score > bestScore) {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
            bestScore = PlayerPrefs.GetInt("bestScore");
            if (bestScore == 3) {
                SelectMenuYes.HAHAGETRICKROLLEDLMAO = true;
            }
            instance.NEWWWWWWWWWWWWWWWWWWWWWWWWWRECORD.SetActive(true);
        }
        gameOverBestScore.text = "" + bestScore;
        instance.gameOverCanvas.gameObject.SetActive(true);
    }

    public void menu() {
        die.PlayOneShot(die.clip);
        StartCoroutine(Resseti("MainMenu"));
    }
    
    public void menupause() {
        die.PlayOneShot(die.clip);
        StartCoroutine(Resseti("MainMenu", false));
    }

    public void reset(bool animate = true) {
        die.PlayOneShot(die.clip);
        StartCoroutine(Resseti(curScene, animate));
    }

    IEnumerator Resseti(string scene, bool animate = true) {
        Time.timeScale = 1f;
        if (animate)
            gameOverCanvasHolderAnim.SetBool("hide", true);
        openFade = true;
        StartCoroutine(fadeOut(blackFade));
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    IEnumerator fadeIn(SpriteRenderer img, float waitTime = 0) {
        yield return new WaitForSeconds(waitTime);
        if (openFade)
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
        if (!openFade)
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

    public static void increaseScore() {
        if (STOPSTOPHESALREADYDEAD) {
            return;
        }
        score++;
        if (score == 200) {
            PlayerPrefs.SetInt("unlocked_graybird", 1);
        }
        GameManager.soundPoint();
        scoreText.text = "" + score;
    }

    public static void soundPoint() {
        point.Play();
    }

    public static void soundWing() {
        wing.Play();
    }

    public static void soundHit() {
        hit.Play();
    }
}
