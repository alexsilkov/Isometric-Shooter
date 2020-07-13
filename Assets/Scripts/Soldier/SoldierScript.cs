using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour
{

    public float moveSpeed;
    public float rotationSpeed;
    public GameObject bullet;
    public Transform shootPoint;

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
        
        float forward = Input.GetAxis("Vertical");
        float right = Input.GetAxis("Horizontal");
        transform.Translate(right * moveSpeed * Time.deltaTime, 0, forward * moveSpeed * Time.deltaTime, Space.Self);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        Instantiate(bullet,shootPoint.position,shootPoint.rotation);
    }
}