using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour
{

    public float moveSpeed;
    public float rotationSpeed;
    public GameObject bullet;
    public Transform shootPoint;
    public Animator animator;

    private Rigidbody body;
    private Vector3 foRward, rigHt;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
        foRward = Camera.main.transform.forward;
        foRward.y = 0;
        foRward = Vector3.Normalize(foRward);
        rigHt = Quaternion.Euler(new Vector3(0,90,0)) * foRward;
    }

    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 rot = transform.eulerAngles;
            transform.LookAt(hit.point);
            transform.eulerAngles = new Vector3(rot.x, transform.eulerAngles.y, rot.z);
        }

        Vector3 rightMovement = rigHt * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = foRward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        if(Input.GetAxis("Horizontal")!=0.0f || Input.GetAxis("Vertical")!=0.0f)
        {
            animator.SetBool("MovingOrNot", true);
        }   
        else
        {
            animator.SetBool("MovingOrNot",false);
        }    
        transform.position += rightMovement;
        transform.position += upMovement;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }


    void Shoot()
    {
       GameObject Bullet =  Instantiate(bullet,shootPoint.position,shootPoint.rotation);
       Destroy(Bullet,2.0f); 
    }
}