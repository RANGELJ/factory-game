using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryGame {
    public class MainGameLogic : MonoBehaviour {
        public GameObject emptyCellPrefab;
        public UnityEngine.UI.Text moneyLabelPrefab;
        public UnityEngine.UI.Text energyLabelPrefab;

        public UnityEngine.UI.Image bottomToolbar;

        public int initialCellRows = 5;
        public int initialCellColumns = 5;

        public int money = 100;
        public int energy = 200;

        private void updateMoneyLabel() {
            this.moneyLabelPrefab.text = "MONEY: " + this.money;
        }

        private void updateEnergyLabel() {
            this.energyLabelPrefab.text = "ENERGY: " + this.energy;
        }

        private void setupGrid() {
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

            this.updateMoneyLabel();
            this.updateEnergyLabel();
        }

        void Start() {
            this.setupGrid();
            this.bottomToolbar
                .GetComponent<FactoryGame.BottomToolbar>()
                .instantiateCanvasChild = (UnityEngine.UI.Image element) => {
                    return Instantiate(element, this.transform);
                };
        }
    }
}
