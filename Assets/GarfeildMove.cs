using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GarfeildMove : MonoBehaviour
{
    public int f = -4;
    float t = 0;
    float moveTime = .5f;
    public float yVal = -0.5f;
    public float deltaY = 0.3f;
    Vector3 oldPosition;
    Vector3 newPosition;
    Vector3 finalPosition;
    public bool moveComplete;
    public string movePhase;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Debug.Log(f);
        newPosition = new Vector3(-4 * 2.24f, yVal, 0);
        moveComplete = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && f > -4 && moveComplete)
        {
           
            moveComplete = false;
            movePhase = "I";
            oldPosition = transform.position;
            sr.flipX = true;
            f--;
            t = 0;
            newPosition = new Vector3(f * 2.24f + 1.12f, yVal + deltaY, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && f < 4 && moveComplete)
        {
          
            moveComplete = false;
            movePhase = "I";
            oldPosition = transform.position;
            sr.flipX = false;
            f++;
            t = 0;
            newPosition = new Vector3(f * 2.24f - 1.12f, yVal + deltaY, 0);
            transform.position = Vector3.Lerp(oldPosition, newPosition, t / moveTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localScale = new Vector3(1, 0.15f, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, .5f, 1);
        }
        t += Time.deltaTime;
        if (t >= (moveTime / 2))
        {
            if (movePhase == "I")
            {
                oldPosition = transform.position;
                movePhase = "II";
                t = t - moveTime / 2;
            }
            newPosition = new Vector3(f * 2.24f, yVal - deltaY, 0);
        }
        if (t > moveTime)
        {
            moveComplete = true;
        }
        // Debug.Log(t / moveTime + " " + moveComplete + " " + movePhase);
        transform.position = Vector3.Lerp(oldPosition, newPosition, t / moveTime);
    }
}