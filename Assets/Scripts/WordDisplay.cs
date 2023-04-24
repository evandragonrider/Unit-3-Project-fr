using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public GameObject enemy;
    public float Movespeed = 1f;
    public int fontSize =16;
    public Color textColor = Color.white;
    public void SetWord (string word){
        text.text = word;
    }
    public void SetEnemy(GameObject enemyObj)
{
    enemy = enemyObj;
}
    public void RemoveLetter(){
        text.text = text.text.Remove(0,1);
        text.color = Color.red;
    }
    public void RemoveWord(){
        Destroy(gameObject);
    }
    private void Update(){
        transform.Translate(-Movespeed * Time.deltaTime, 0f, 0f);
    if (enemy != null)
    {
        enemy.transform.position = transform.position + new Vector3(0f, 0.5f, 0f);
    }
    }
   }

