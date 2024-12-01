using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Player : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _lazerPrefab;
    [SerializeField] private Sprite _playerLeft;
    [SerializeField] private Sprite _playerRight;
    [SerializeField] private Sprite _playerVert;
    // [SerializeField] private Sprite wall;
    [SerializeField] private Sprite _wallUp;
    [SerializeField] private Sprite _wallDown;
    [SerializeField] private Sprite _wallLeft;
    [SerializeField] private Sprite _wallRight;
    [SerializeField] private GameObject _defaultWall;
    [SerializeField] private int solutionLength = 10;
    [SerializeField] private Tile _tilePrefab;
    //private Queue solution;
    private GameObject p1;
    private Queue<string> myQueue = new Queue<string>();
    private bool playing = false;
    private GameObject jimmy;
    private GameObject wall;
    private float moveSpeed = 5f;
    bool[,] gridChecker = new bool[16, 9];
    bool[,] gridPortals = new bool[16, 9];
    bool[,] gridTraps = new bool[16, 9];





    void Start()
    {
        p1 = Instantiate(_playerPrefab, new Vector3(0,1), Quaternion.identity);
        // movePoint.parent = null;
        createWalls();
        createPortal();
        createTrap();
        
        //solution = new int[solutionLength];
        //private Queue<int> myQueue = new Queue<int>();
    }

    

    private void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) && (p1.transform.position.y < 8)) 
        {
            bool test = checkWalls(0,1);
            if (test)
            {
                p1.GetComponent<SpriteRenderer>().sprite = _playerVert;
                p1.transform.Translate(new Vector3(0,1,0));
            }
            else 
            {
                wallAdder("up");
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && (p1.transform.position.y > 0)) 
        {
            bool test = checkWalls(0,-1);
            if (test)
            {
                p1.GetComponent<SpriteRenderer>().sprite = _playerVert;
                p1.transform.Translate(new Vector3(0,-1,0));
            }
            else 
            {
                wallAdder("down");
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && (p1.transform.position.x < 15)) 
        {
            bool test = checkWalls(1,0);
            if (test)
            {
                p1.GetComponent<SpriteRenderer>().sprite = _playerRight;
                p1.transform.Translate(new Vector3(1,0,0));
            }
            else 
            {
                wallAdder("right");
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (p1.transform.position.x > 0)) 
        {
            bool test = checkWalls(-1,0);  
            if (test)
            {
                p1.GetComponent<SpriteRenderer>().sprite = _playerLeft;
                p1.transform.Translate(new Vector3(-1,0,0));
            }
            else 
            {
                wallAdder("left");
            }
        }
        

        darkness();
        checktraps();
        
        
        


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



    private bool checkWalls(int x, int y)
    {
        for (int i = 0; i < gridChecker.GetLength(0); i++) // Loop through rows
        {
            for (int j = 0; j < gridChecker.GetLength(1); j++) // Loop through columns
            {
                if (gridChecker[(int)p1.transform.position.x + x, (int)p1.transform.position.y + y] == true)
                {
                    return false;
                }
                
            }
             
        }
        return true;

    }

    private void checktraps()
    {
        if (gridTraps[(int)p1.transform.position.x, (int)p1.transform.position.y] == true)
        death();
    }

    private void createWalls()
    {
        gridChecker[3,5] = true;
        gridChecker[4,5] = true;
    }

    private void createPortal()
    {
        gridPortals[6,6] = true;
    }

    private void createTrap()
    {
        gridTraps[8,8] = true;
    }


    private void death()
    {
        p1.transform.position = new Vector3(0,0,0);
    }

    private void darkness()
    {
        int x = (int)p1.transform.position.x;
        int y = (int)p1.transform.position.y;

        jimmy = GameObject.Find("Tile " + x + " " + y);
        // Get the current color
        Color currentColor = jimmy.GetComponent<SpriteRenderer>().color;

        // Modify the alpha component
        currentColor.a = 1f; // alpha values are between 0 (fully transparent) and 1 (fully opaque)

        // Set the color back
        jimmy.GetComponent<SpriteRenderer>().color = currentColor;

    }

    private void wallAdder(string direction)
    {
        int x = (int)p1.transform.position.x;
        int y = (int)p1.transform.position.y;

        switch(direction)
        {
            case "up":
                wall = GameObject.Find("Tile " + x + " " + y);
                wall.GetComponent<SpriteRenderer>().sprite = _wallUp;
                wall.transform.position = new Vector3(x,(float)(y+0.7f),0);
                break;
            
            case "down":
                wall = GameObject.Find("Tile " + x + " " + y);
                wall.GetComponent<SpriteRenderer>().sprite = _wallDown;
                wall.transform.position = new Vector3(x,(float)(y-0.7f),0);
                break;

            case "left":
                wall = GameObject.Find("Tile " + x + " " + y);
                wall.GetComponent<SpriteRenderer>().sprite = _wallLeft;
                wall.transform.position = new Vector3((float)(x-0.5f),y,0);
                wall.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            
            case "right":
                wall = GameObject.Find("Tile " + x + " " + y);
                wall.GetComponent<SpriteRenderer>().sprite = _wallRight;
                wall.transform.position = new Vector3((float)(x+0.5f),y,0);
                wall.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
        }

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

