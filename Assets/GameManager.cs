using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text textPoint;
    public Text textVictory;
    public GameObject Food;
    public int point = 0;

    float minX = -9f;
    float maxX = 9f;
    float minY = -4f;
    float maxY = 4f;

    
    void Awake()
    {
        MakeInstance();
        
    }

    private void Start()
    {
        RandomFood();
        UpdatePoint();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void RandomFood()
    {
        float x, y;
        if (transform.position.x > 0)
        {
            x = Random.Range(minX, 0);
        }
        else
        {
            x = Random.Range(0, maxX);
        }
        y = Random.Range(minY, maxY);
        
        Instantiate(Food, new Vector2(x, y), Quaternion.identity);
    }

    public void UpdatePoint()
    {
        textPoint.text = "Point: " + point;
    }

    public void Victory()
    {
        textVictory.gameObject.SetActive(true);
        Destroy(gameObject); 
    }
    
}
