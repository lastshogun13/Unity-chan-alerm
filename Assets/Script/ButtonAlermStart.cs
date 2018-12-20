using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAlermStart : MonoBehaviour {
    public GameObject gameController;

    public void AlermStartButtonClick() {
        gameController.GetComponent<GameController>().isDisplayDialogue = false;
    }
}
