using UnityEngine;

public class Revolution : MonoBehaviour
{

    [SerializeField]
    GameObject centerSphereGameObject;
    [SerializeField]
    private float radiusToCenterSphere = 5f;
    [SerializeField]
    private float angularSpeed;
    [SerializeField]
    float speed = 5f;
    
    [SerializeField]
    private Vector2 center;

    [SerializeField]
    bool clockwise = false;

    
    void Update()
    {
        //setting the ceter everytime the internal spehere moves unless set to itself. 
       if(centerSphereGameObject!=null)
        {
            center = centerSphereGameObject.transform.position;
            if (clockwise)
            {
                angularSpeed += speed * Time.deltaTime;
            }
            else
            {
                angularSpeed -= speed * Time.deltaTime;
            }

            var offset = new Vector2(Mathf.Sin(angularSpeed), Mathf.Cos(angularSpeed)) * radiusToCenterSphere;

            transform.position = center + offset;
        }

    }
}
