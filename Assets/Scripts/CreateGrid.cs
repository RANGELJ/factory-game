using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public GameObject platformPrefab;
    public int totalRows = 1;
    public int totalColumns = 1;
    public float distanceBetwenPlatforms = 5;

    private GameObject[] grid;
    private int selectedPlatformIndex;

    private void setSelectedPlatform(int newPlatformIndex) {
        selectedPlatformIndex = newPlatformIndex;
        GameObject selectedPlatform = grid[newPlatformIndex];

        Vector3 platformPosition = selectedPlatform.transform.position;

        Camera.main.GetComponent<GOTranslator>().moveTo(3.8f, new Vector3(
            platformPosition.x,
            Camera.main.transform.position.y,
            platformPosition.z
        ));
    }

    void Start() {
        grid = new GameObject[totalRows * totalColumns];

        for (int rowNumber = 0; rowNumber < totalRows; rowNumber +=1 ) {
            float xDistance = distanceBetwenPlatforms * rowNumber;
            for (int columnNumber = 0; columnNumber < totalColumns; columnNumber += 1) {
                float yDistance = distanceBetwenPlatforms * columnNumber;

                int platformIndex = rowNumber + (columnNumber * totalRows);

                grid[platformIndex] = Instantiate(
                    platformPrefab,
                    new Vector3(xDistance, 0, yDistance),
                    Quaternion.identity
                );
            }
        }

        this.setSelectedPlatform(0);
    }
}
