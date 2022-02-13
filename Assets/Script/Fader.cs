using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public List<GameObject> sphere;
    public GameObject cube;

    private void Start()
    {

        if (cube != null)
        {
            StartCoroutine(FadeTo(1f, 3.0f, cube));
        }
    }


    public void Fade (string name )
    {
        // fade the others than the one selected. 
        switch (name)
        {
            case "Sphere1":
                MaterialFade(sphere[1]);
                MaterialFade(sphere[2]);
                sphere[0].GetComponent<LerpMotion>().enabled = true;
                break;
            case "Sphere2":
                MaterialFade(sphere[0]);
                MaterialFade(sphere[2]);
                sphere[1].GetComponent<LerpMotion>().enabled = true;
                break;
            case "Sphere3":
                MaterialFade(sphere[0]);
                MaterialFade(sphere[1]);
                sphere[2].GetComponent<LerpMotion>().enabled = true;
                break;
            default:
                Debug.Log("Nothing");
                break;
        }

        FindObjectOfType<SceneManagerUtil>().ChangetoNextScene("Scene3");

    }


    public void MaterialFade(GameObject sphere)
    {
        //dark to light
        StartCoroutine(FadeTo(0f, 1.0f,sphere));
        // change scene
        

    }


    public IEnumerator FadeTo(float aValue, float aTime,GameObject gameObject)
    {
        float alpha = gameObject.GetComponent<MeshRenderer>().material.color.a;
        float r= gameObject.GetComponent<MeshRenderer>().material.color.r;
        float b= gameObject.GetComponent<MeshRenderer>().material.color.b;
        float g= gameObject.GetComponent<MeshRenderer>().material.color.g;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(r, b, g, Mathf.Lerp(alpha, aValue, t));
            gameObject.GetComponent<MeshRenderer>().material.color = newColor;
            yield return null;
        }

       

    }
}
