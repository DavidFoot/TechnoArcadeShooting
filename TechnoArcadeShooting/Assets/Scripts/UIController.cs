using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject m_settingsPanel;
    [SerializeField] private AudioMixer m_audioMixer;

    public void Awake()
    {
       // m_settingsPanel.SetActive(false);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
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
