using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");


        rb.MovePosition(transform.position + new Vector3(horz, vert, 0) * Time.deltaTime * 10);
    }
}
