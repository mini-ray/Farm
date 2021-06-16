using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedHealth : MonoBehaviour
{
    [SerializeField] int pointsForWeeds = 1;

    
    public int hp = 3;
    

    void Start()
    {
        
    }

    public void ReduceHP(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("+1 point");
            FindObjectOfType<ScoreText>().AddToScore(pointsForWeeds);
            
        }
    }
}
