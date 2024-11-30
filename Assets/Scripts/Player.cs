using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Player : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _lazerPrefab;
    [SerializeField] private int solutionLength = 10;
    //private Queue solution;
    private GameObject p1;
    private Queue<string> myQueue = new Queue<string>();
    private bool playing = false;

    private float moveSpeed = 5f;
    // private Transform movePoint;



    void Start()
    {
        p1 = Instantiate(_playerPrefab, new Vector3(0,1), Quaternion.identity);
        // movePoint.parent = null;

        //solution = new int[solutionLength];
        //private Queue<int> myQueue = new Queue<int>();
    }

    

    private void Update() {

        if (myQueue.Count < solutionLength)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && (p1.transform.position.y < 8)) 
        {
            p1.transform.Translate(new Vector3(0,1,0));
            myQueue.Enqueue("up");
            Debug.Log(myQueue.Count);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && (p1.transform.position.y > 0)) 
        {
            p1.transform.Translate(new Vector3(0,-1,0));
            myQueue.Enqueue("down");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && (p1.transform.position.x < 15)) 
        {
            p1.transform.Translate(new Vector3(1,0,0));
            myQueue.Enqueue("right");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (p1.transform.position.x > 0)) 
        {
            p1.transform.Translate(new Vector3(-1,0,0));
            myQueue.Enqueue("left");
        }

        }
        else
        {
            if (!playing)
            {
                //PlayerMovement();
            }
            
        }

        // transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        // if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
        // {
        //     movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f); 
        // }

        // if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        // {
        //     movePoint.position += new Vector3(Input.GetAxisRaw("Vertical"), 0f); 
        // }
    }

    // private void PlayerMovement()
    // {
    //     playing = true;
    //     Debug.Log("amount: " + myQueue.Count);
    //     int amount = myQueue.Count;
    //     for (int i = 0; i < amount; i++)
    //     {
    //         Debug.Log("run" + i);
    //         string direction = myQueue.Dequeue();
    //         System.Threading.Thread.Sleep(1000);
    //         StartCoroutine(step(direction));
    //         Debug.Log("firest");
        
    //     }

    // }

    // IEnumerator step(string x)
    // {
    //     Vector3 currentposition = p1.transform.position;
    //      if (x == "up")
    //         {
    //             p1.transform.Translate(new Vector3(0,1,0));
    //         }
    //         else if (x == "down")
    //         {
    //             p1.transform.Translate(new Vector3(0,-1,0));
    //         }
    //         else if (x == "right")
    //         {
    //             p1.transform.Translate(new Vector3(1,0,0));
    //         }
    //         else if (x == "left")
    //         {
    //             p1.transform.Translate(new Vector3(-1,0,0));
    //         }
    //         yield return new WaitForSeconds(5);
    //         Debug.Log("second ");

    // }

    //     IEnumerator Example()
    // {
    //     print(Time.time);
    //     yield return new WaitForSeconds(5);
    //     print(Time.time);
    // }



    /*
    Example function for providing movement for player
    @param x: value of last player input in queue
    */
    // private void stepEx(string x) {

      
    //     switch(x)
    //     {
    //         case "up":
    //             p1.transform.position = Vector3.MoveTowards(p1.transform.position, new Vector3(0,5,0), 2.2f);
    //             // p1.transform.Translate(new Vector3(0,1,0));
    //             //p1.velocity = new Vector2(2,0);
    //             break;
            
    //         case "down":
    //             p1.transform.Translate(new Vector3(0,-1,0));
    //             Thread.Sleep(50);
    //             break;
            
    //         case "right":
    //             p1.transform.Translate(new Vector3(1,0,0));
    //             Thread.Sleep(50);
    //             break;
            
    //         case "left":
    //             p1.transform.Translate(new Vector3(-1,0,0));
    //             Thread.Sleep(50);
    //             break;
    //     }
    // }
    
    // private void PlayerMovement()
    // {
    //     playing = true;
    //     Debug.Log("amount: " + myQueue.Count);
    //     int amount = myQueue.Count;
    //     for (int i = 0; i < amount; i++)
    //     {
    //         Debug.Log("run" + i);
    //         string direction = myQueue.Dequeue();
    //         stepEx(direction);
    //         Debug.Log("firest");
    //     }

    // }

    
}

