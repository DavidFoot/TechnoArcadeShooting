using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject m_settingsPanel;
    [SerializeField] private AudioMixer m_audioMixer;

    [SerializeField] private GameController m_gc;

    [SerializeField] GameObject m_countdown;
    [SerializeField] GameObject m_timer;
    [SerializeField] GameObject m_score;

    private int m_gameTimer;
    public void Awake() { 
    }
    private void Update()
    {

        m_countdown.SetActive(true);
        if (m_gc.m_countdownValue >= 0)
        {
            if (m_gc.m_currentCountdown != 0)
            {
                m_countdown.GetComponent<TextMeshProUGUI>().text = m_gc.m_currentCountdown.ToString();
            }
            else
            {
                m_countdown.GetComponent<TextMeshProUGUI>().text = "START";
            }
        }
        else
        {
            m_countdown.SetActive(false);
            m_timer.SetActive(true);
            m_score.SetActive(true);
            if (m_gc.m_partyGameTime >= 0)
            {
                m_timer.GetComponent<TextMeshProUGUI>().text = "Temps Restant: " + string.Format("{0:00}:{1:00}", m_gc.m_partyMinutes, m_gc.m_partySeconds);
                m_score.GetComponent<TextMeshProUGUI>().text= "Score : " + GameController.m_actualScore;
            }
            else
            {
                m_countdown.GetComponent<TextMeshProUGUI>().text = "FINI!";
                m_countdown.SetActive(true);
            }
        }
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
