using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnLocation = new Vector3(0f, 3f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20f){
            Kill();
        }
    }

    private void Kill() {
        transform.position = respawnLocation;
        transform.rotation = Quaternion.identity;
    }
}
