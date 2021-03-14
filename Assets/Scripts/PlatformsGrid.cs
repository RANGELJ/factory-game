using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsGrid : MonoBehaviour
{
    private static int FRAMES_BETWEEN_UPDATE = 20;
    private static int FRAMES_COUNTER = 0;
    public static bool EXECUTE_UPDATE = false;


    public GameObject platformPrefab;
    public int totalRows = 1;
    public int totalColumns = 1;
    public float distanceBetwenPlatforms = 5;
    public float initialMoney = 500;

    private GameObject[] grid;
    private int selectedPlatformIndex;

    private void SetSelectedPlatform(int newPlatformIndex) {
        selectedPlatformIndex = newPlatformIndex;
        GameObject selectedPlatform = grid[newPlatformIndex];

        Vector3 platformPosition = selectedPlatform.transform.position;

        Camera.main.GetComponent<GOTranslator>().moveTo(10.1f, new Vector3(
            platformPosition.x,
            Camera.main.transform.position.y,
            platformPosition.z - 1
        ));
    }

    private GameObject InstantiatePlatform(
        int platformIndex,
        Vector3 position
    ) {
        GameObject platform = Instantiate(
            platformPrefab,
            position,
            Quaternion.identity
        );

        platform.GetComponent<BehaviourPlatform>().mouseDownHandler = () => {
            this.SetSelectedPlatform(platformIndex);
        };

        return platform;
    }

    void Start() {
        grid = new GameObject[totalRows * totalColumns];

        for (int rowNumber = 0; rowNumber < totalRows; rowNumber +=1 ) {
            float xDistance = distanceBetwenPlatforms * rowNumber;
            for (int columnNumber = 0; columnNumber < totalColumns; columnNumber += 1) {
                float yDistance = distanceBetwenPlatforms * columnNumber;

                int platformIndex = rowNumber + (columnNumber * totalRows);

                grid[platformIndex] = this.InstantiatePlatform(
                    platformIndex,
                    new Vector3(xDistance, 0, yDistance)
                );
            }
        }

        this.SetSelectedPlatform(0);
    }

    void Update() {
        EXECUTE_UPDATE = FRAMES_COUNTER == FRAMES_BETWEEN_UPDATE;
        if (EXECUTE_UPDATE) {
            FRAMES_COUNTER = 0;
        }
        FRAMES_COUNTER += 1;
    }
}
