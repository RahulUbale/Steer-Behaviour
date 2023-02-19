using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steer : MonoBehaviour
{    Vector3 velocity;
     Vector3 steering;
     public float maxSpeed = 1;
     public GameObject target;
     public float seekforce = 1;
     public float seekm =1;
     //public List<GameObject> cp;
    // int i=0;
     //public float d=5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
/*

        target = cp[i];
        if(Vector3.Distance(this.transform.position , target.transform.position)  < d) {
            i +=1;

            if(i >= cp.Count )
            {
                i= 0;
            }
        }
*/


        steering = CalF(target.transform.position);
        steering = Vector3.ClampMagnitude(steering,seekforce);
        steering *= seekm;


        velocity += steering * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity,maxSpeed);
        this.transform.position += velocity * Time.deltaTime;




        
    }
    


    public Vector3 CalSeek(Vector3 targetPosition)
    {
        Vector3 dv = targetPosition -this.transform.position;
        dv = dv.normalized;
        dv *= maxSpeed;


        Debug.DrawRay(this.transform.position,velocity,Color.green);
        Debug.DrawRay(this.transform.position,dv,Color.red);
        Debug.DrawRay(this.transform.position,steering,Color.blue);

         return dv-this.velocity;




    }

    public Vector3 CalF(Vector3 targetPosition)
    {
        Vector3 dv =  this.transform.position - targetPosition;
        dv = dv.normalized;
        dv *= maxSpeed;
         Debug.DrawRay(this.transform.position,velocity,Color.green);
        Debug.DrawRay(this.transform.position,dv,Color.red);
        Debug.DrawRay(this.transform.position,steering,Color.blue);

        return dv - this.velocity;






    }



}
