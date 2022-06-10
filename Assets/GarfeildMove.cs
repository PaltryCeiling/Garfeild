using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarfeildMove : MonoBehaviour
{
    public int f = -4;
    float t = 0;
    float moveTime = 4f;
    Vector3 oldPosition;
    Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(f);
        
        newPosition = new Vector3(-4 * 2.24f, -0.22f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && f > -4)
        {
            oldPosition = transform.position;
            f--;
            t = 0;
            newPosition = new Vector3(f * 2.24f + 1.12f, 1, 0);
        }

            if (Input.GetKeyDown(KeyCode.RightArrow) && f < 4)
            {
                oldPosition = transform.position;
                f++;
                t = 0;
            
            
                newPosition = new Vector3(f * 2.24f - 1.12f, 1, 0);
            
          


            }
        t += Time.deltaTime;

        if (t > moveTime / 2)
        {
            
            newPosition = new Vector3(f * 2.24f, -0.22f, 0);
        }
        Debug.Log(t / moveTime);

         transform.position = Vector3.Lerp(oldPosition, newPosition, t / moveTime );

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            oldPosition = transform.position;
            
            t = 0;
            newPosition = new Vector3(f, -1, 0);
        }
    }
    
    }

