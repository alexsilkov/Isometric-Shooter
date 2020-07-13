using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;

    private Vector3 lastPos;

    void Start()
    {
        lastPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        RaycastHit raycastHit;
        if (Physics.Linecast(lastPos,transform.position, out raycastHit))
        {
            Destroy(gameObject);
            if (raycastHit.transform.tag.Equals("Enemy"))
            {
                raycastHit.transform.gameObject.GetComponent<ZombieScript>().Death();
            }    
        }
    }
}
