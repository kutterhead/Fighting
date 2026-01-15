using UnityEngine;

public class impactZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    float distance = 0f;
    Vector3 lastposition;


    PlayerController player;
    SphereCollider sphereCollider;
    MeshRenderer meshRenderer;
    
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
        sphereCollider = GetComponent<SphereCollider>();
        meshRenderer = GetComponent<MeshRenderer>();    

        lastposition = transform.position;
    }
    private void FixedUpdate()
    {
        
   

        distance = (lastposition - transform.position).magnitude;
        lastposition = transform.position;
        if (distance<0.025f)
        {
            sphereCollider.enabled = false;

            meshRenderer.enabled = false;
        }
        else
        {
            sphereCollider.enabled = true;
            meshRenderer.enabled = true;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto impactado trigger:" + other.gameObject.name);
        Debug.Log("Potencia:" + distance);
        if (other.gameObject.CompareTag("Player"))
        {
            player.otherPlayer.getdamage(distance*10);
        }

    }
}
