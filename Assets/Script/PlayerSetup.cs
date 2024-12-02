using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] notLocalPlayer;

    Camera defaultCam;

    void Start()
    {
        if (!isLocalPlayer)
        {
            foreach(var component in notLocalPlayer)
            {
                component.enabled = false;
            }
        }
        else
        {
            defaultCam = Camera.main;
            if (defaultCam != null)
            {
                defaultCam.gameObject.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        if (defaultCam != null)
        {
            defaultCam.gameObject.SetActive(false);
        }
    }
}
