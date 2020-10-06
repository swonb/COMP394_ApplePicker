using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Public Variables
    public GameObject applePrefab;
    public float speed = 1;
    public float leftAndRightEdge = 10;
    public float chanceToChangeDirection = .1f;    // 10 %
    public float appleDropInterval = 1;     // start with 1 sec
    public int direction = 1;       // 1 => to the right, -1 => to the left

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DropApple", 2f, appleDropInterval);    // (Method name, start time, interval)
    }

    void DropApple()
    {
        // TODO
        //Debug.Log("Drop Apple");
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        Vector3 pos = this.transform.position;
        float dx = speed * direction * Time.deltaTime;
        pos.x += dx;
        transform.position = pos;

        // Check for Direction Change
        ChangeDirection(pos.x);
    }

    void ChangeDirection(float px)
    {
        if (px < -leftAndRightEdge)
        {
            direction = 1;
        }
        else if (px > leftAndRightEdge)
        {
            direction = -1;
        }
    }

    private void FixedUpdate()
    {
        // Check for Random Direction Change
        if (Random.value < chanceToChangeDirection)
        {
            direction *= -1;
        }
    }
}
