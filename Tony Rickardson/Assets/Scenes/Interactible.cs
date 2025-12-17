using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField] public bool carColider = false;

   GameObject SelectedObject;

    public KeyCode interactKey = KeyCode.F;

    CarMovement carMovement;


    private void Start()
    {
        carMovement = GetComponent<CarMovement>();
        SelectedObject = FindAnyObjectByType<PlayerMovement>().gameObject;
    }
        
    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && carColider)
        {
            SelectedObject.SetActive(false);
            print(SelectedObject.name);
            carMovement.insideCar = true;

            SelectedObject.transform.SetParent(transform, true);
        }
        else if (Input.GetKeyDown(interactKey))
        {
            SelectedObject.SetActive(true);
            carMovement.insideCar = false;

            SelectedObject.transform.SetParent(null, true);
        }
    }
    //  && isPowered
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            carColider = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            carColider = false;
        }
    }
}
