
using Unity.VisualScripting;
using UnityEngine;

public class TargetBase : MonoBehaviour
{
    // Start is called before the first frame update
    public void GotHit()
    {
        GameController.m_actualScore +=10;
        ObjectSpawner.disableObject(gameObject);
    }
    private void Update()
    {
        if(gameObject.transform.position.y < -8)
        {
            ObjectSpawner.disableObject(gameObject);
        }
    }
}
