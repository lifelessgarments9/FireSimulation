using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button newGameButton;
    public Button tutorialLevelButton;
    public Button hearingImpairedLevelButton;
    public Button settingsButton;
    public Button exitButton;

    public GameObject settingsMenu;  // Ссылка на меню настроек
    public GameObject mainMenuObj;   // Ссылка на основное меню

    void Start()
    {
        // Проверяем, чтобы ссылки были назначены
        if (settingsMenu == null)
        {
            Debug.LogError("⚠ settingsMenu не назначен в инспекторе!");
            return;
        }

        if (mainMenuObj == null)
        {
            Debug.LogError("⚠ mainMenuObj не назначен в инспекторе!");
            return;
        }

        settingsMenu.SetActive(false); // Скрываем настройки при старте

        // Привязываем кнопки к методам
        newGameButton?.onClick.AddListener(StartNewGame);
        tutorialLevelButton?.onClick.AddListener(StartTutorialLevel);
        hearingImpairedLevelButton?.onClick.AddListener(StartHearingImpairedLevel);
        settingsButton?.onClick.AddListener(OpenSettings);
        exitButton?.onClick.AddListener(ExitGame);
    }

    public void StartNewGame() => SceneManager.LoadScene("FireScene");

    public void StartTutorialLevel() => SceneManager.LoadScene("FireScene");

    public void StartHearingImpairedLevel() => SceneManager.LoadScene("FireScene");

    public void OpenSettings()
    {
        Debug.Log("📌 Открываем настройки");
        mainMenuObj.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("❌ Выход из игры");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
