using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu, optionsMenu, quitToMainMenu, quitGameMenu;

    [SerializeField] private Image UIscreenshot;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        quitToMainMenu.SetActive(false);
        quitGameMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeInHierarchy)
        {
            StartCoroutine(TakeScreenshot());
            StartCoroutine(ShowPauseUI());
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }


    public void BackToGame()
    {
        pauseMenu.SetActive(false);
        quitGameMenu.SetActive(false);
        quitToMainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
    }

    public void OpenQuitToMainMenu()
    {
        quitToMainMenu.SetActive(true);
    }

    public void CloseQuitToMaiMenu()
    {
        quitToMainMenu.SetActive(false);
    }

    public void OpenQuitMenu()
    {
        quitGameMenu.SetActive(true);
    }

    public void CloseQuitMenu()
    {
        quitGameMenu.SetActive(false);
    }


    private IEnumerator TakeScreenshot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D screenshot = ScreenCapture.CaptureScreenshotAsTexture();
        Texture2D newScreenshot = new Texture2D(screenshot.width, screenshot.height, TextureFormat.RGB24, false);
        newScreenshot.SetPixels(screenshot.GetPixels());
        newScreenshot.Apply();
        Destroy(screenshot);

        Sprite screenshotSprite = Sprite.Create(newScreenshot, new Rect(0, 0, newScreenshot.width, newScreenshot.height), new Vector2(0.5f, 0.5f));
        UIscreenshot.enabled = true;
        UIscreenshot.sprite = screenshotSprite;
    }

    private IEnumerator ShowPauseUI()
    {
        yield return new WaitForEndOfFrame();
        pauseMenu.SetActive(true);
    }
}
