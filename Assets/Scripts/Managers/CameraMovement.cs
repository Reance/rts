using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 0;

    private float xMaxLimit;

    private float yMaxLimit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
	}

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up*cameraSpeed*Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
        }
        transform.position=new Vector3(Mathf.Clamp(transform.position.x,0,xMaxLimit),Mathf.Clamp(transform.position.y,-1,yMaxLimit),-10);
    }

    public void SetLimits(Vector3 maxTile)
    {
        Vector3 wp=Camera.main.ViewportToWorldPoint(new Vector3(1,1));
        xMaxLimit = maxTile.x-wp.x;
        yMaxLimit = maxTile.y-wp.y;
    }
}
