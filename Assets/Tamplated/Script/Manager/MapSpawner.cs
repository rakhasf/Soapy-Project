using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject[] mapPrefabs;   
    public Transform spawnPoint;      

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int rand = Random.Range(0, mapPrefabs.Length);
            Instantiate(mapPrefabs[rand], spawnPoint.position, Quaternion.identity);
        }
    }
}