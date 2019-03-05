using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;

    private GameObject playerInstance;

    public Maze mazePrefab;

	private Maze mazeInstance;

	private void Start ()
    {
        StartCoroutine(BeginGame());
    }
	
	private void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			RestartGame();
		}
	}

    [System.Obsolete]
    private IEnumerator BeginGame()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        yield return StartCoroutine(mazeInstance.Generate());
        playerInstance = Instantiate(playerPrefab, mazeInstance.GetCell(new IntVector2(UnityEngine.Random.RandomRange(0,20),UnityEngine.Random.RandomRange(0, 20))).transform.position, Quaternion.identity);
    }

	private void RestartGame () {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        if (playerInstance != null)
        {
            Destroy(playerInstance.gameObject);
        }
        StartCoroutine(BeginGame());
	}
}