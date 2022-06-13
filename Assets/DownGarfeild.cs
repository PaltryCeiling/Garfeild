using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownGarfeild : MonoBehaviour
{ 

         public int f = -4;
float t = 0;
float moveTime = .5f;
Vector3 oldPosition;
Vector3 newPosition;
Vector3 finalPosition;
public bool moveComplete;
public string movePhase;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && moveComplete)
        {
            moveComplete = false;
            movePhase = "I";
            oldPosition = transform.position;
          
            t = 0;
            newPosition = new Vector3(oldPosition.x, -2, 0);
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
            newPosition = new Vector3(oldPosition.x, -2f, 0);
        }


        if (t > moveTime)

        {
            moveComplete = true;
        }

        Debug.Log(t / moveTime + " " + moveComplete + " " + movePhase);

        transform.position = Vector3.Lerp(oldPosition, newPosition, t / moveTime);
        oldPosition = transform.position;
    }
}
