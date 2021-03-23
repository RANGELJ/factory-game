using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryGame {
    public class BottomToolbar : MonoBehaviour {
        public UnityEngine.UI.Image buildModalPrefab;
        public UnityEngine.UI.Button buildButton;

        public delegate UnityEngine.UI.Image InstantiateCanvasChild(UnityEngine.UI.Image element);
        public InstantiateCanvasChild instantiateCanvasChild;

        private UnityEngine.UI.Image openedModal;

        private void toggleModal(UnityEngine.UI.Image modal) {
            if (this.openedModal != null) {
                Destroy(this.openedModal.gameObject);
                this.openedModal = null;
            }
            this.openedModal = this.instantiateCanvasChild(modal);
        }

        void Start() {
            this.buildButton.onClick.AddListener(() => {
                this.toggleModal(this.buildModalPrefab);
            });
        }

        void Update()
        {
            
        }
    }
}
