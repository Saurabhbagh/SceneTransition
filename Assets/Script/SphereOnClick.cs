using UnityEngine;

/// <summary>
/// This will be attached to each spheere so when clicked on it will save the instance and will keep them in the ceter of the next scene.  
/// </summary>
public class SphereOnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        SaveGameObject.SaveObject(this.gameObject);
        FindObjectOfType<Fader>().Fade(this.gameObject.name);
    }
}
