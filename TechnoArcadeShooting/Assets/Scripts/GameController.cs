using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public float m_partyGameTime;
    [SerializeField] public float m_countdownValue;
    [SerializeField] public float m_partyMinutes;
    [SerializeField] public float m_partySeconds;
    [SerializeField] GameObject m_objectSpawner;
    public static  int m_actualScore;



    public float m_currentCountdown;


    public static bool m_gameIsActive;
    private void Awake()
    {
        m_gameIsActive = false;
        m_actualScore = 0;
        //m_objectSpawner.GetComponent<ObjectSpawner>().StartSpawn();

    }
    private void Update()
    {
        if (m_countdownValue >= 0)
        { 
            m_currentCountdown = Mathf.FloorToInt(m_countdownValue % 60);
            m_countdownValue -= Time.deltaTime;
        }
        else
        {
            if(m_partyGameTime >= 0)
            {
                m_partyMinutes = Mathf.FloorToInt(m_partyGameTime / 60);
                m_partySeconds = Mathf.FloorToInt(m_partyGameTime % 60);
                m_partyGameTime -= Time.deltaTime;
                m_gameIsActive = true;
            }
            else
            {
                m_gameIsActive = false;
                // Stop Spawner & player interract  + Score + menu etc..
            }        
        }
    }
}
