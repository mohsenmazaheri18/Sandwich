using UnityEngine;

public class Moving : MonoBehaviour
{

    [Header("Component Sandwich in Game")] public GameObject[] component_Sandwich;

    [Header("New Place In Plate")] public Transform[] place = new Transform[5];

    public GameObject[] _placeStatus;
    
    bool alive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    private Vector3 forwardMove;
    private Vector3 horizontalMove;

    private bool move;
    private void Start()
    {
        //Find all of Component in Game
        component_Sandwich = GameObject.FindGameObjectsWithTag("Component_Sandwich");
    }
    private void Update () {
        if (!alive) return;

        if (Input.GetKey(KeyCode.Space))
        {
            move = true;
            Debug.Log(move);
            if (move)
            {
                forwardMove = -transform.up * (speed * Time.fixedDeltaTime);
                horizontalMove= transform.right * (horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier);
                rb.MovePosition(rb.position + forwardMove + horizontalMove);
            }
        }
        else
        {
            move = false;
            Debug.Log(move);
        }


        
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5) {
            
        }
    }

    private int _countCool = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Component_Sandwich"))
        {
            Debug.Log(_countCool);
            HelpedMehod(_countCool);

            if (component_Sandwich[_countCool].transform.GetChild(0))
            {
                
            }
        }
    }

    public GameObject[] parent_of_sandwich;
    private void HelpedMehod(int placed)
    {
        Debug.Log("parrented");
        component_Sandwich[placed].transform.position = place[placed].position;
        component_Sandwich[placed].transform.SetParent(parent_of_sandwich[placed].transform);
        component_Sandwich[placed].GetComponent<BoxCollider>().enabled = false;
        component_Sandwich[placed].transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        _countCool += 1;

        // _placeStatus[1].SetActive(true);
        // _placeStatus[0].SetActive(false);
    }
}
