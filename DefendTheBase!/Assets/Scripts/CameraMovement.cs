using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float camraSpeed = 0;

    private float xMax;
    private float yMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * camraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * camraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * camraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * camraSpeed * Time.deltaTime);
        }
        
    }


    private void SetLimits(Vector3 maxTile)
    {
        Vector3 worldPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));
        xMax = maxTile.x - worldPoint.x;
        yMax = maxTile.y - worldPoint.y;
    }
}
