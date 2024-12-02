using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public string texte;
    public Transform player;
    private bool hasPlayer=false;
    
    void Start()
    {
        // Initialization code
    }

    void Update()
    {
        float dist =Vector2.Distance(gameObject.transform.position, transform.position);

        if (dist<=1.5f)
        {
            hasPlayer=true;
        }
        else { hasPlayer=false; }

        // Check for player interaction

        if (hasPlayer && Input.GetKey(KeyCode.X))
        {
            Interact();
        }
    }

    void Interact()
    {
        // Implement interaction logic
        Debug.Log("a");

    }
}