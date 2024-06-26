using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField ] public static bool gameIsPaused = false;
    [SerializeField] GameObject m_pauseScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            Time.timeScale = gameIsPaused ? 0f : 1f;
            m_pauseScreen.SetActive(!m_pauseScreen.activeSelf);
        }
        if (GameController.m_gameIsActive) {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    hit.collider.gameObject.GetComponent<TargetBase>().GotHit();
                }
            }
        }
    }
}
