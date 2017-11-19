using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;
    public float movementSpeed;

    private Vector3 targetPosition;
    private static bool cameraExists;
    

	// Use this for initialization
	void Start () {

        // handle camera duplicaiton
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        

    }
	
	// Update is called once per frame
	void Update () {
        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);
	}
}
