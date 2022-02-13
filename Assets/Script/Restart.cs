using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
   
    public void RestartLevel()
    {
        FindObjectOfType<SceneManagerUtil>().ChangetoNextScene("Scene");

    }
}
