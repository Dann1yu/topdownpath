using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _lazerPrefab;
    [SerializeField] private float _lazerSpeed = 10f;
    [SerializeField] private int solutionLength = 10;
    //private Queue solution;
    private GameObject p1;
    private Queue<string> myQueue = new Queue<string>();


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
            p1.transform.Translate(new Vector3(0,1,0));
            myQueue.Enqueue("up");
            Debug.Log(myQueue.Count);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            p1.transform.Translate(new Vector3(0,-1,0));
            myQueue.Enqueue("down");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            p1.transform.Translate(new Vector3(1,0,0));
            myQueue.Enqueue("right");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            p1.transform.Translate(new Vector3(-1,0,0));
            myQueue.Enqueue("left");
        }

        }


        
    }

    private void PlayerMovement()
    {
        
    }

    

    
}

