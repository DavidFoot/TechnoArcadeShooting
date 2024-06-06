using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject m_settingsPanel;
    [SerializeField] private AudioMixer m_audioMixer;
    private int m_gameTimer;
    public void Awake()
    {
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        InputController.gameIsPaused = false;
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
    public void ToggleSettingsPanel()
    {
        m_settingsPanel.SetActive(!m_settingsPanel.activeSelf);
    }
    public void SlideMasterVolume(float value)
    {
        m_audioMixer.SetFloat("MasterVolume", value);
    }
    public void SlideMusicVolume(float value) 
    {
        m_audioMixer.SetFloat("MusicsVolume", value);
    }
    public void SlideSFXVolume(float value)
    {
        m_audioMixer.SetFloat("SFXVolume",value);
    }
}
