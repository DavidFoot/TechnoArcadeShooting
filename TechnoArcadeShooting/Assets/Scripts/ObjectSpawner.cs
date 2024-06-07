using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform m_container;
    [SerializeField] private GameObject m_PrefabTarget;
    [SerializeField] private List<Transform> m_spawnerOriginList; 
    [SerializeField] private float m_velocity;
    [SerializeField] private float m_initPoolQuantity;
    [SerializeField] private float m_spawnDelay;
    [SerializeField] private MonoScript m_scriptTarget;
    private static Queue<GameObject> m_objectPool = new Queue<GameObject>();
    private GameObject m_target;

    private void Start()
    {
        for (int i = 0; i < m_initPoolQuantity; i++)
        {
            CreateNewObject();
        }
        StartCoroutine("StartThrowingObjects");
    }
    private GameObject CreateNewObject()
    {
        m_target = Instantiate(m_PrefabTarget, m_container);
        m_target.name = m_PrefabTarget.name;        
        m_objectPool.Enqueue(m_target);
        m_target.SetActive(false);
        m_target.AddComponent<TargetBase>();
        return m_target;
    }
    public GameObject GetAvailableObject()
    {
        if( m_objectPool.Count > 0)
        {
            return m_objectPool.Dequeue();
        }
        return CreateNewObject();
    }
    public static void disableObject(GameObject _object)
    {
        _object.SetActive(false);
        _object.GetComponent<Rigidbody>().isKinematic = true;
        m_objectPool.Enqueue(_object);
    }
    IEnumerator StartThrowingObjects() 
    {
        while(true)
        {
            if (GameController.m_gameIsActive) {
                int m_spawnerIndex = UnityEngine.Random.Range(0, m_spawnerOriginList.Count);
                m_target = GetAvailableObject();
                m_target.SetActive(true);
                m_target.transform.position = m_spawnerOriginList[m_spawnerIndex].transform.position;
                m_target.GetComponent<Rigidbody>().isKinematic=false;
                m_target.GetComponent<Rigidbody>().AddForce(m_spawnerOriginList[m_spawnerIndex].transform.up * m_velocity, ForceMode.Impulse);
                m_target.GetComponent<Rigidbody>().AddTorque(new Vector3(1, 0, 1) * m_velocity, ForceMode.Impulse);              
            }
            yield return new WaitForSeconds(m_spawnDelay);
        }
    }

}
