using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    void Start()
    {
        p1 = Instantiate(_playerPrefab, new Vector3(0,1), Quaternion.identity);

        //solution = new int[solutionLength];
        //private Queue<int> myQueue = new Queue<int>();
    }

    

    private void Update() {

        if (myQueue.Count < solutionLength)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            //p1.transform.Translate(new Vector3(0,1,0));
            myQueue.Enqueue("up");
            Debug.Log(myQueue.Count);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            //p1.transform.Translate(new Vector3(0,-1,0));
            myQueue.Enqueue("down");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            //p1.transform.Translate(new Vector3(1,0,0));
            myQueue.Enqueue("right");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            //p1.transform.Translate(new Vector3(-1,0,0));
            myQueue.Enqueue("left");
        }

        }
        else
        {
            if (!playing)
            {
                PlayerMovement();
            }
            
        }


        
    }

    private void PlayerMovement()
    {
        playing = true;
        Debug.Log("amount: " + myQueue.Count);
        int amount = myQueue.Count;
        for (int i = 0; i < amount; i++)
        {
            Debug.Log("run" + i);
            string direction = myQueue.Dequeue();
            StartCoroutine(step(direction));
            Debug.Log("firest");
        
        }

    }

    IEnumerator step(string x)
    {
        Vector3 currentposition = p1.transform.position;
         if (x == "up")
            {
                p1.transform.Translate(new Vector3(0,1,0));
            }
            else if (x == "down")
            {
                p1.transform.Translate(new Vector3(0,-1,0));
            }
            else if (x == "right")
            {
                p1.transform.Translate(new Vector3(1,0,0));
            }
            else if (x == "left")
            {
                p1.transform.Translate(new Vector3(-1,0,0));
            }
            yield return new WaitForSeconds(5);
            Debug.Log("second ");

    }

        IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }    

    

    
}

