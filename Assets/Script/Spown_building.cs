using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Spown_Building : MonoBehaviour
{
    public GameObject buildingPrefab;
    public GameObject coinPrefab;
    public Rigidbody2D player;
    private float moveSpeed = 0.1f;
    public float coinSpawnRate = 1f;
    private List<GameObject> building_list = new List<GameObject>();
    private float minDistance = 4f;
    private float maxDistance = 6f;
    [SerializeField] private TextMeshProUGUI ScoreValue;
    //public Camera_Script cam;


    void Start()
    {
        SpawnStartingBuildings();
    }

    void Update()
    {
        foreach (GameObject building in building_list)
        {
            float bottomYPosition = building.transform.position.y - building.transform.localScale.y / 2f;

            if (player.transform.position.y < bottomYPosition)
            {
                GameOver();
                return;
            }
        }

        if (player.transform.position.x >= building_list[3].transform.position.x)
        {
            Destroy(building_list[0]);
            building_list.RemoveAt(0);
            SpawnBuilding();
        }
    }

    void SpawnStartingBuildings()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnBuilding();
        }
    }
    void SpawnBuilding()
    {
        Vector3 buildingPosition;
        if (building_list.Count == 0)
            buildingPosition = new Vector3(transform.position.x, 0, 0);
        else
            buildingPosition = new Vector3(building_list[building_list.Count - 1].transform.position.x + Random.Range(minDistance, maxDistance),
                                           0, 0);

        GameObject newBuilding = Instantiate(buildingPrefab, buildingPosition, transform.rotation);

        float buildingHeight = Random.Range(2f, 5f);

        //position of the bottom of the building
        float bottomYPosition = newBuilding.transform.position.y - newBuilding.transform.localScale.y / 2f;

        //scale while the bottom position fixed
        newBuilding.transform.localScale = new Vector3(newBuilding.transform.localScale.x, buildingHeight, newBuilding.transform.localScale.z);

        //new position based on the adjusted scale
        float newYPosition = bottomYPosition + newBuilding.transform.localScale.y / 2f;
        newBuilding.transform.position = new Vector3(newBuilding.transform.position.x, newYPosition, newBuilding.transform.position.z);
        building_list.Add(newBuilding);

        if (Random.value < coinSpawnRate)
        {
            // Set coin position on top of the building
            Vector3 coinPosition = new Vector3(buildingPosition.x, newYPosition + newBuilding.transform.localScale.y / 2f + 0.6f, 0);
            GameObject newCoin = Instantiate(coinPrefab, coinPosition, transform.rotation);
            newCoin.GetComponent<Coin>().SetBuilding(this);
        }
    }
    void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //startCanvas.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
