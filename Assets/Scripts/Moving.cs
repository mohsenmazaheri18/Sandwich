using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{


    //Public Function
    [Header("Component Sandwich in Game")] public GameObject[] component_Sandwich;

    [Header("New Place In Plate")] public Transform[] place;
    public GameObject[] parent_of_sandwich;

    [Header("Speed To Move")] public float speed = 5;

    [Header("RigidBody Plate To Move")] [SerializeField]
    Rigidbody rb;

    [SerializeField] float horizontalMultiplier = 2;

    [Header("Collision Parent")] public GameObject parent_of_CS;

    [Header("Prefab Player and Spawn Point")]
    public GameObject player;

    public GameObject spawnPoint, player_Scene;

    [Header("Canvas Win && Lose")]
    public GameObject Lose;
    public GameObject Win;

    [Header("Start Game")] public GameObject TouchHelp;

    //Private Function
    private bool alive = true;
    private int _countCoolplace = 0;
    private int _countCom = 0;
    private int _countLose = 0;
    private Vector3 forwardMove;
    private Vector3 horizontalMove;
    private bool move;
    private float horizontalInput;
    private Touch theTouch;

    private void Start()
    {
        //Find all of Component in Game
        move = true;
    }
    private void Update()
    {
        transform.rotation = rb.rotation;
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Moved)
            {
                if (move)
                {
                    transform.position = new Vector3(
                        transform.position.x + theTouch.deltaPosition.x * speed, transform.position.y,
                        transform.position.z);
                }
                
                /*horizontalMove = transform.right *
                                 (horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier);
                rb.MovePosition(rb.position + forwardMove + horizontalMove);*/
            }

            if (theTouch.phase==TouchPhase.Stationary)
            {
                if (move)
                {
                    rb.velocity = new Vector3(0, 0, 30f);
                    forwardMove = -transform.up * (10f * Time.fixedDeltaTime);
                }
            }

            if (theTouch.phase==TouchPhase.Began)
            {
                TouchHelp.SetActive(false);
            }
        }

       // horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -3)
        {

            Lose.SetActive(true);
            // //spawn again
            // transform.position = spawnPoint.transform.position;
            // transform.rotation = Quaternion.Euler(-90, 0, 0);
            // rb.isKinematic = true;
            // rb.isKinematic = false;
            // RisingWater();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Component_Sandwich"))
        {
            Debug.Log(_countCoolplace);
            Debug.Log(_countCom);
            HelpedMehod(_countCoolplace, _countCom);
        }

        if (other.gameObject.CompareTag("Next_CS"))
        {
            
        }
        
        if (other.gameObject.CompareTag("Trap"))
        {
            GetTrap();
        }

        if (other.gameObject.CompareTag("Win"))
        {
            Win.SetActive(true);
            move = false;
        }

    }

    private void HelpedMehod(int placed, int comSan)
    {
     /*   Debug.Log("parrented");
        
        component_Sandwich[comSan].transform.position = place[placed].position;
        component_Sandwich[comSan].transform.SetParent(parent_of_sandwich[placed].transform);
        component_Sandwich[comSan].transform.rotation = parent_of_sandwich[comSan].transform.rotation;
        component_Sandwich[comSan].GetComponent<Component_Sandwich_Anim>().enabled = false;
        component_Sandwich[comSan].GetComponent<BoxCollider>().enabled = false;
        component_Sandwich[comSan].transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
         _countCoolplace += 1;
        //_countCom += 1;*/
    }

    private void GetTrap()
    {
        for (int i = 0; i < _countCom; i++)
        {
            StartCoroutine(WaitToDestroy());
            component_Sandwich[i].transform.SetParent(parent_of_CS.transform);
            component_Sandwich[i].transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
            component_Sandwich[i].AddComponent<Rigidbody>();
        }

        _countCoolplace = 0;
    }

    // private void RisingWater()
    // {
    //     for (int i = 0; i < _countCom; i++)
    //     {
    //         component_Sandwich[i].SetActive(false);
    //         _countCool = 0;
    //     }
    // }

    private IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < _countCom; i++)
        {
            component_Sandwich[i].SetActive(false);
            Debug.Log(_countLose);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RetryGame()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
