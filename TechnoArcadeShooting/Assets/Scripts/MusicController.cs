using UnityEngine;

public class MusicController : MonoBehaviour
{
    private MusicController musicController;
    // Start is called before the first frame update
    private void Awake()
    {
        if (musicController == null)
        {
            musicController = GetComponent<MusicController>();
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
