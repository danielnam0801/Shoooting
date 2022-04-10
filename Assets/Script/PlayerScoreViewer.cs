using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerScoreViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerController PlayerController;
    private TextMeshProUGUI textScore;
    void Start()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "Score " +PlayerController.Score;   
    }
}
