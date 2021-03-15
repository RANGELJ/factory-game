using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryGame {
    public class MainGameLogic : MonoBehaviour {
        public GameObject emptyCellPrefab;

        public int initialCellRows = 5;
        public int initialCellColumns = 5;

        void Start() {
            for (
                int column = 0;
                column < initialCellColumns;
                column += 1
            ) {
                float xPosition = column * 0.64f;

                for (
                    int row = 0;
                    row < initialCellRows;
                    row += 1
                ) {
                    float yPosition = row * 0.64f;

                    Instantiate(
                        this.emptyCellPrefab,
                        new Vector2(xPosition, yPosition),
                        Quaternion.identity
                    );
                }
            }
        }
    }
}
