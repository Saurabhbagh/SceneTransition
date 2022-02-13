using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class SceneManagerUtil : MonoBehaviour, IPointerClickHandler
{
    public Animator animator;
    public string Scene;
    public string previousScene;
    public Image Scene1;
    public Image Scene2;
    public Image Scene3;
    public List<Sprite> red;
    public List<Sprite> blue;
    public GameObject Restart;

    public static SceneManagerUtil Instance;
    private void Awake()
    {

        // Saves the Canvas from the begning.
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            SaveGameObject.SaveObject(gameObject);
        }
    }



        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
        string name = eventData.pointerCurrentRaycast.gameObject.name;
        if (name.Equals("Scene") || name.Equals("Scene2") || name.Equals("Scene3"))
        {
            Debug.Log(name);
            ChangetoNextScene(name);
        }
    }

    public void ChangetoNextScene(string scene)
    {
        ChangeImages(scene);
        animator.SetTrigger("FadeOut");
        Scene = scene;
        previousScene = SceneManager.GetActiveScene().name;
        ChangeScene();
    }

    void ChangeScene()
    {
        // if sphere is there 
        if (previousScene == "Scene3")
        {
            if(FindObjectOfType<Revolution>())
            {
                GameObject sphere = FindObjectOfType<Revolution>().gameObject;


                if (sphere != null)
                {
                    Destroy(sphere);
                }
            }
      }



        // load new scene

        Debug.Log("loading scene {Scene}");
        SceneManager.LoadScene(Scene);
        animator.SetTrigger("FadeInNewScene");
        var obj = FindObjectOfType<Revolution>();
        if (obj != null)
        {
            obj.enabled = false;
        }

        // if it comes from the scene2 
        if (previousScene == "Scene2")
        {
            FindObjectOfType<Revolution>().enabled = false; 
            
        }

    }


    void ChangeImages(string name)
    {
       switch (name)
        {
            case "Scene":
                Scene1.sprite = blue[0];
                Scene2.sprite = red[1];
                Scene3.sprite = red[2];
                Restart.SetActive(false);
                break;
            case "Scene2":
                Scene1.sprite = red[0];
                Scene2.sprite = blue[1];
                Scene3.sprite = red[2];
                Restart.SetActive(false);
                break;
            case "Scene3":
                Scene1.sprite = red[0];
                Scene2.sprite = red[1];
                Scene3.sprite = blue[2];
                Restart.SetActive(true);
                break;
            default:
                Debug.Log("Nothing");
                break;
        }
             
                        
    }
}
