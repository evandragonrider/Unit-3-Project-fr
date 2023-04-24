using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay = 1f;
    public Transform[] spawnPoints;

    private WordGenerator wordGenerator;
    private WordManager wordManager;

    private void Start()
    {
        wordGenerator = FindObjectOfType<WordGenerator>();
        wordManager = FindObjectOfType<WordManager>();

        StartCoroutine(SpawnWordEnemies());
    }

    public IEnumerator SpawnWordEnemies()
    {
          while (true)
    {
        // Get a random spawn point
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the enemy prefab at the random spawn point
        GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        // Find the Text component on the enemy prefab
        Text enemyText = enemy.GetComponentInChildren<Text>();

        // Create a new instance of the Word class
        Word newWord = new Word(WordGenerator.GetRandomWord(), new WordDisplay { text = enemyText });

        // Add the new Word instance to the WordManager's activeWords list
        wordManager.AddWord(newWord);

        // Wait for the specified spawn delay before spawning the next enemy
        yield return new WaitForSeconds(spawnDelay);
    }
}






}