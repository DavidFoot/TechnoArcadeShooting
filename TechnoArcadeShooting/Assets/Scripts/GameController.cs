using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public float m_partyGameTime;
    [SerializeField] public float m_countdownValue;
    [SerializeField] public GameObject m_countdown;
    [SerializeField] public GameObject m_timer;
    public static bool m_gameIsActive;
    private void Awake()
    {
        m_gameIsActive = false;
    }
    private void Update()
    {
        m_countdown.SetActive(true);
        if (m_countdownValue >= 0) 
        {

            float seconds = Mathf.FloorToInt(m_countdownValue % 60);
            if (seconds != 0)
            {
                m_countdown.GetComponent<TextMeshProUGUI>().text = seconds.ToString();
            }
            else
            {
                m_countdown.GetComponent<TextMeshProUGUI>().text = "START";
            }
            m_countdownValue -= Time.deltaTime;
        }
        else
        {
            m_countdown.SetActive(false);
            m_timer.SetActive(true);
            if(m_partyGameTime >= 0)
            {
                float minutes = Mathf.FloorToInt(m_partyGameTime / 60);
                float seconds = Mathf.FloorToInt(m_partyGameTime % 60);
                m_timer.GetComponent<TextMeshProUGUI>().text = "Temps Restant: " + string.Format("{0:00}:{1:00}", minutes, seconds);
                m_partyGameTime -= Time.deltaTime;
                m_gameIsActive = true;
                Debug.Log("JEu en cours");
            }
            else
            {
                Debug.Log("JEu FIni ");
                m_gameIsActive = false;
                // Stop Spawner & player interract  + Score + menu etc..
            }        
        }
    }
}
