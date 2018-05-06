using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupSpawner : MonoBehaviour {

    [SerializeField]
    private List<GameObject> spawns;

    private List<Vector3> spawnedLocations = new List<Vector3>();

    private LevelManager level;
    private int GRID_SQUARE_SIZE = 200;
    private Vector3 prevGridPos;

	// Use this for initialization
	void Start () {
        level = LevelManager.Find();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 gridPos = playerGridPos();
        if (spawnedLocations.Count == 0 || !gridPos.Equals(prevGridPos))
        {
            for (float x = gridPos.x - 2; x <= gridPos.x + 1; x++)
            {
                for (float y = gridPos.y - 2; y <= gridPos.y + 1; y++)
                {
                    Vector3 pos = new Vector3(x, y, 0);
                    if (!spawnedLocations.Contains(pos))
                    {
                        SpawnAt(pos);
                    }
                }
            }
        }

        prevGridPos = gridPos;        
	}

    private Vector3 playerGridPos()
    {
        Vector3 playerPos = level.player.transform.position;
        Vector3 playerGridPos = playerPos / GRID_SQUARE_SIZE;
        playerGridPos.x = Mathf.FloorToInt(playerGridPos.x);
        playerGridPos.y = Mathf.FloorToInt(playerGridPos.z);
        playerGridPos.z = 0;

        return playerGridPos;
    }

    private GameObject SpawnAt(Vector3 gridPos)
    {
        spawnedLocations.Add(gridPos);
        Vector3 posistionRandomness = Random.insideUnitCircle / 2;
        posistionRandomness.y = 0;

        Vector3 spawnGridLocation = new Vector3(gridPos.x + 0.5f, 0, gridPos.y + 0.5f);

        Vector3 spawnPos = (spawnGridLocation + posistionRandomness) * GRID_SQUARE_SIZE;

        GameObject willSpawn = spawns[Random.Range(0, spawns.Count)];
        return Instantiate(willSpawn, spawnPos, Quaternion.identity);
    }
}
