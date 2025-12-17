using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class CarMovement : MonoBehaviour
{
    [SerializeField]public bool insideCar = false;
    [SerializeField, Range(1, 50)] float force = 7;          //player force
    [SerializeField, Range(1, 50)] float rotforce = 7;       //player rotations force
    [SerializeField, Range(1, 50)] float torquelimit = 7;    //player rotations fart
    [SerializeField, Range(1, 50)] float forceLimitX = 7;    //Max force limit i X-axel
    [SerializeField, Range(1, 50)] float forceLimitY = 7;    //Max force limit i Y-axel
    Rigidbody2D rb; //en Rigidbody2D




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //h�mta component (Rigidbody2D)
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * 
         *  if (Input.GetKey(KeyCode.W))
         *  {
         *  rb.velocity = transform.up * 5 * Time.deltaTime;
         *  }
         *  
         */
        if (insideCar)
        {
            float horz = Input.GetAxis("Horizontal"); //Horizontal alex
            float vert = Input.GetAxis("Vertical"); //Vertical alex

            rb.AddTorque(-horz * rotforce * Time.deltaTime); //spelare roterar
            rb.AddForce(transform.up * vert * force * Time.deltaTime); //spelare kan r�ra sig verticalt

            rb.linearVelocity = new Vector2(Mathf.Clamp(rb.linearVelocity.x, -forceLimitX, forceLimitX), Mathf.Clamp(rb.linearVelocity.y, -forceLimitY, forceLimitY)); //en force Cap f�r gubbens movment b�de verticalt och horizontalt
            rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -torquelimit, torquelimit); //max rotations fart f�r gubbens rotation
        }
    }
}
