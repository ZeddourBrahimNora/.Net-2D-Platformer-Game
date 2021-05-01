using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public List<Transform> points;
    public Transform platform;
    int goalPoint = 0;
    public float moveSpeed = 2; 

    // Update is called once per frame
    void Update()
    {
        MoveToNextPoint();

    }

    private void MoveToNextPoint()
    {
        //change the position of the platform ( move towards the goal point)
        platform.position = Vector2.MoveTowards(platform.position, points[goalPoint].position,Time.deltaTime*moveSpeed);
        //check 
        if (Vector2.Distance(platform.position, points[goalPoint].position) < 0.1f)
        {
            if (goalPoint == points.Count - 1)
                goalPoint = 0;
            else
                goalPoint++;
        }
    }
}
