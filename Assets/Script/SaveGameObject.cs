using UnityEngine;

// will make sure the gameobject is not destroyed. 
public class SaveGameObject : MonoBehaviour
{
    public static void SaveObject(GameObject name)
    {
        DontDestroyOnLoad(name);
    }
}
