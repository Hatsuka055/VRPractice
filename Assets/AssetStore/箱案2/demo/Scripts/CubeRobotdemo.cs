using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRobotdemo : MonoBehaviour
{
    public GameObject fire;
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public GameObject pointD;
    public Animator rleg;
    public Animator lleg;
    public Animator head;
    public Animator lid;
    public Animator engine;
    Rigidbody rb;
    public Vector3 force;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        force = new Vector3(0, 0, 0);
        
    }

    
    void Update()
    {
        //OPEN and CLOSE LEGs
        if (Input.GetKeyDown("j"))
        {
            if (rleg.GetBool("open") && lleg.GetBool("open"))
            {
                Foldlegs();
                Stopwalk();
            }
            else
            {
                Openlegs();
            }
        }

        //ON and OFF ENGINE
        if (Input.GetKeyDown("k"))
        {
            if (engine.GetBool("ON"))
            {
                Offengine();
            }
            else if(lleg.GetBool("open"))
            {
                Onengine();
            }
        }

        //OPEN and CLOSE HEAD
        if (Input.GetKeyDown("l"))
        {
            if (head.GetBool("open"))
            {
                Closehead();
            }
            else
            {
                Openhead();
            }
        }

        //OPEN and CLOSE BACKLID
        if (Input.GetKeyDown("m"))
        {
            if (lid.GetBool("open"))
            {
                Closelid();
            }
            else
            {
                Openlid();
            }
        }

        //MOVEMENT
        //walk
        if (!engine.GetBool("ON"))
        {
            if (Input.GetKeyDown("w"))
            {
                if (lleg.GetBool("open"))
                {
                    Walkstart();
                }
            }
            if (Input.GetKey("w"))
            {
                if (lleg.GetBool("walk"))
                {
                    transform.Translate(10f * Time.deltaTime * transform.localScale.x, 0, 0);
                }
            }
            if (Input.GetKey("a"))
            {
                if (lleg.GetBool("walk"))
                {
                    transform.Rotate(0, -40f * Time.deltaTime, 0);
                }
            }
            if (Input.GetKey("d"))
            {
                if (lleg.GetBool("walk"))
                {
                    transform.Rotate(0, 40f * Time.deltaTime, 0);
                }
            }

            if (Input.GetKeyUp("w"))
            {
                if (lleg.GetBool("walk"))
                {
                    Stopwalk();
                }
            }
        }

        //ENGINE
        if (engine.GetBool("ON"))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Foldlegs();
                //transform.Translate(0, 2f * Time.timeScale * transform.localScale.x, 0);
                force.y = 3.0f;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Foldlegs();
                force.y = -3.0f;
                //transform.Translate(0, 2f * Time.timeScale * transform.localScale.x, 0);
            }
            
            if (Input.GetKeyDown("w"))
            {
                force.x = 3f;
            }
            if (Input.GetKeyDown("s"))
                {
                    force.x = -3f;
                }
            if (Input.GetKeyDown("a"))
                {
                    force.z = 3f;
                }
            if (Input.GetKeyDown("d"))
                {
                    force.z = -3f;
                }
            if (Input.GetKeyUp("w"))
                {
                    force.x = 0f;
                }
            if (Input.GetKeyUp("s"))
                {
                    force.x = 0f;
                }
            if (Input.GetKeyUp("a"))
                {
                    force.z = 0f;
                }
            if (Input.GetKeyUp("d"))
                {
                    force.z = 0f;
                }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                force.y = 0f;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                force.y = 0f;
                
            }
           
            

            rb.AddRelativeForce(force*Time.deltaTime*80);
            rb.AddForce(-3f * rb.velocity);


        }
    }


    void Openlegs()
    {
        rleg.SetBool("open", true);
        lleg.SetBool("open", true);
    }
    void Foldlegs()
    {
        rleg.SetBool("open", false);
        lleg.SetBool("open", false);
    }
    void Onengine()
    {
        Stopwalk();
        engine.SetBool("ON", true);
    }
    void Offengine()
    {
        engine.SetBool("ON", false);
    }

    void EngineOn()
    {
        Instantiate(fire, pointA.transform.position, pointA.transform.rotation, pointA.transform);
        Instantiate(fire, pointB.transform.position, pointB.transform.rotation, pointB.transform);
        Instantiate(fire, pointC.transform.position, pointC.transform.rotation, pointC.transform);
        Instantiate(fire, pointD.transform.position, pointD.transform.rotation, pointD.transform);
        
    }

    void EngineOff()
    {
        Destroy(pointA.transform.Find("FireEffect(Clone)").gameObject);
        Destroy(pointB.transform.Find("FireEffect(Clone)").gameObject);
        Destroy(pointC.transform.Find("FireEffect(Clone)").gameObject);
        Destroy(pointD.transform.Find("FireEffect(Clone)").gameObject);
    }
    void Openhead()
    {
        head.SetBool("open", true);
    }
    void Closehead()
    {
        head.SetBool("open", false);
    }
    void Walkstart()
    {
        rleg.SetBool("walk", true);
        lleg.SetBool("walk", true);
    }
    void Stopwalk()
    {
        rleg.SetBool("walk", false);
        lleg.SetBool("walk", false);
    }
    void Openlid()
    {
        lid.SetBool("open", true);
    }
    void Closelid()
    {
        lid.SetBool("open", false);
    }


}
