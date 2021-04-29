using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{

    [SerializeField] int lives = 5;
    [SerializeField] int damage = 1;
    [SerializeField] TextMeshProUGUI textMeshPro;

    private void Start()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        textMeshPro.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();
        if (lives <= 0)
        {
            FindObjectOfType<Level>().LoadLevelFailScene();
        }
    }
}
