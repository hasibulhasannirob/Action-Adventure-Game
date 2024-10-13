using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    private List<SpawnPoint> spawnPointList;
    private List<Character> spawnCharacters;
    private bool hasSpawned;
    public Collider _collider;
    public UnityEvent OnAllSpawnedCharacterEliminated;

    private void Awake()
    {
        var spawnPointArray = transform.parent.GetComponentsInChildren<SpawnPoint>();
        spawnPointList = new List<SpawnPoint>(spawnPointArray);
        spawnCharacters = new List<Character>();
    }

    private void Update()
    {
        if (!hasSpawned || spawnCharacters.Count == 0)
        {
            return;
        }

        bool allSpawnedAreDead = true;
        foreach (Character c in spawnCharacters)
        {
            if (c.CurrentState != Character.CharacterState.Dead)
            {
                allSpawnedAreDead = false;
                break;
            }
        }

        if (allSpawnedAreDead)
        {
            if (OnAllSpawnedCharacterEliminated != null)
            {
                OnAllSpawnedCharacterEliminated.Invoke();
            }
            spawnCharacters.Clear();
        }
    }

    public void SpawnCharacters()
    {
        if (hasSpawned)
        {
            return;
        }
        hasSpawned = true;

        foreach (SpawnPoint point in spawnPointList)
        {
            if (point.EnemyToSpawn != null)
            {
                GameObject spawnedGameObject = Instantiate(point.EnemyToSpawn, point.transform.position, point.transform.rotation);
                spawnCharacters.Add(spawnedGameObject.GetComponent<Character>());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SpawnCharacters();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, _collider.bounds.size);
    }
}
