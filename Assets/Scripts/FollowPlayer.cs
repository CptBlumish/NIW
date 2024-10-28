using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(-17.72f, -3.35f, -10.64f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Cameramovement();
    }
    void Cameramovement()
    {
        transform.position = player.transform.position + offset;
    }
}
