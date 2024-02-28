using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CountScore : MonoBehaviour
{
    public int score;
    public int finalScore;
    public UnityEvent winAction;

    public void UpdateScore(){
        score = score + 1;
        if (score == finalScore){
            winAction.Invoke();
        }
    }
}
 