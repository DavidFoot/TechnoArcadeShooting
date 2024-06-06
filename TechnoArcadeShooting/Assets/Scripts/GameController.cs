using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public int m_partyGameTime;
    [SerializeField] public GameObject m_managerUI;
    private bool m_active;
    private void Awake()
    {
        m_active = true;
        StartCoroutine("TestCoroutine");
        Debug.Log("Start de la coroutine");
    }
    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(m_partyGameTime);
        m_active = false;
        Debug.Log("Coroutine en fonction");
    }
    private void Update()
    {
        if (m_active)
        {
            Debug.Log("Jeux en cours");
            // Afficher le Timer dans la UI
        }
        else
        {
            Debug.Log("Jeux est fini");
            /* 
             * Time Scale 0 + Afficher le menu Score + Retourner Scene de Depart avec bouton Ok dans le panel ? 
             */

        }
    }
}
