using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform m_TankToFollowTransform = null;
    

    // Use this for initialization
    void Start () {
		
	}

    private void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {

    }
}
