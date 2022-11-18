using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePatronScript : MonoBehaviour
{
    public GameObject StartPoint;
    public GameObject EndPoint;

    public float enemySpeed;

    private bool isGoingRight;
    void Start()
    {
        if (!isGoingRight)   transform.position = StartPoint.transform.position;
        else  transform.position = EndPoint.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGoingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, enemySpeed * Time.deltaTime);
            if(transform.position == EndPoint.transform.position)
            {
                transform.localScale = new Vector3(1, 1, 1);
                isGoingRight = true;
            }    
        }

        if (isGoingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPoint.transform.position, enemySpeed * Time.deltaTime);
            if (transform.position == StartPoint.transform.position)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                isGoingRight = false;
         
                
            }
        }
     
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(StartPoint.transform.position,EndPoint.transform.position);
    }
}
