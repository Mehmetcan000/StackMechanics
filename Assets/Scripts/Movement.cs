using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float swipeSpeed;

    public float moveSpeed;

    private Camera cam;


    
    void Start()
    {
        cam = Camera.main;
    }

    


    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            Move();
        }
        
    }

    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;


        Ray ray=cam.ScreenPointToRay(mousePos);

        RaycastHit hit;

        if (Physics.Raycast(ray,out hit,Mathf.Infinity))
        {
            GameObject firstCube = AtmRush.instance.cubes[0];
            Vector3 hitVector = hit.point;
            hitVector.y = firstCube.transform.localPosition.y;
            hitVector.z = firstCube.transform.localPosition.z;

            firstCube.transform.localPosition = Vector3.MoveTowards(firstCube.transform.localPosition, hitVector, Time.deltaTime * swipeSpeed);

        }
    }


    
}
