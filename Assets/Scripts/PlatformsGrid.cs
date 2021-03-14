using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsGrid : MonoBehaviour
{
    private static int FRAMES_BETWEEN_UPDATE = 20;
    private static int FRAMES_COUNTER = 0;
    public static bool EXECUTE_UPDATE = false;


    public GameObject prefabPlatform;
    public GameObject prefabGenerator;

    public UnityEngine.UI.Button addGeneratorButton;
    public UnityEngine.UI.Text moneyLabel;

    public int totalRows = 1;
    public int totalColumns = 1;
    public float distanceBetwenPlatforms = 5;
    public int availableMoney = 500;

    private GameObject[] grid;
    private int selectedPlatformIndex;

    private GameObject GetCurrentPlatform() {
        return grid[selectedPlatformIndex];
    }

    private void SetSelectedPlatform(int newPlatformIndex) {
        this.selectedPlatformIndex = newPlatformIndex;
        GameObject selectedPlatform = this.GetCurrentPlatform();

        Vector3 platformPosition = selectedPlatform.transform.position;

        Camera.main.GetComponent<GOTranslator>().moveTo(10.1f, new Vector3(
            platformPosition.x,
            Camera.main.transform.position.y,
            platformPosition.z - 1
        ));
    }

    private void SetAvailableMoney(int newValue) {
        this.availableMoney = newValue;
        this.moneyLabel.text = "Money: " + this.availableMoney;
    }

    private void AddGeneratorToCurrentPlatform() {
        this.GetCurrentPlatform()
            .GetComponent<BehaviourPlatform>()
            .setItem(this.prefabGenerator);
    }

    private GameObject InstantiatePlatform(
        int platformIndex,
        Vector3 position
    ) {
        GameObject platform = Instantiate(
            prefabPlatform,
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

        this.SetAvailableMoney(this.availableMoney);
        this.SetSelectedPlatform(0);
        this.addGeneratorButton.onClick.AddListener(() => {
            this.AddGeneratorToCurrentPlatform();
        });
    }

    void Update() {
        EXECUTE_UPDATE = FRAMES_COUNTER == FRAMES_BETWEEN_UPDATE;
        if (EXECUTE_UPDATE) {
            FRAMES_COUNTER = 0;
        }
        FRAMES_COUNTER += 1;
    }
}
