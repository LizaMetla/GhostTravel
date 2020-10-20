using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public GameObject PlayerObj;
    public GameObject[] ObstaclesArr;

    int playerDistanceIndex = -1;
    int obstacleCount;
    int obstacleIndex = 0;
    int distanceToNext = 50;


    void Start()
    {
        obstacleCount = ObstaclesArr.Length;
        InstantiateObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        int PlayerDistance = (int)(PlayerObj.transform.position.y / (distanceToNext / 2));

        if(playerDistanceIndex != PlayerDistance)
        {
            InstantiateObstacle();
            playerDistanceIndex = PlayerDistance;
        }
    }

    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(ObstaclesArr[0], new Vector3(0, obstacleIndex * distanceToNext), Quaternion.identity);
        newObstacle.transform.SetParent(transform);
        obstacleIndex++;
    }
}
