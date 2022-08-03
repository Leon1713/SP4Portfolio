using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updateScore : MonoBehaviour
{
    public ScoreManager scoreMan;
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = scoreMan.getScore();
    }
}
