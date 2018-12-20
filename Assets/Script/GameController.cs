using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
//    public Text TimeText;
    public TextMeshProUGUI timeText;
    public Text timeoverText;
    public GameObject player;
    public GameObject timeoverTimeline;
    public GameObject canvasDialogue;
    public GameObject timeoverGroup;
    public GameObject restartButton;
    public InputField inputFieldYear;
    public InputField inputFieldMonth;
    public InputField inputFieldDay;
    public InputField inputFieldHour;
    public InputField inputFieldMinute;

    public bool isDisplayDialogue = true;
    public int goalYear;
    public int goalMonth;
    public int goalDay;
    public int goalHour;
    public int goalMinute;
    public String timeoverMessage = "TimeOver";
    public int motionIntervalSec = 30;

    private long goalTimeT;
    private Animator playerAnimator;
    private PlayableDirector timeline;

    // Use this for initialization
    void Start() {
        timeline = timeoverTimeline.GetComponent<PlayableDirector>();

        playerAnimator = player.GetComponent<Animator>();

        timeoverText.text = timeoverMessage;

        DateTime now = DateTime.Now;
        inputFieldYear.text   = now.Year.ToString();
        inputFieldMonth.text  = now.Month.ToString();
        inputFieldDay.text    = now.Day.ToString();
        inputFieldHour.text   = now.Hour.ToString();
        inputFieldMinute.text = now.Minute.ToString();
    }

    // Update is called once per frame
    void Update() {
        DisplayAlerm();
        if (isDisplayDialogue == true) {
            ShowDialogue();
        } else {
            stepAlerm();
        }
    }

    void stepAlerm() {
        canvasDialogue.SetActive(false);
        //timeoverText.gameObject.SetActive(true);
    }

    void ShowDialogue() {
        canvasDialogue.SetActive(true);
        timeoverGroup.SetActive(false);
        timeoverText.gameObject.SetActive(false);
        restartButton.SetActive(false);

        goalYear = int.Parse(inputFieldYear.text);
        goalMonth = int.Parse(inputFieldMonth.text);
        goalDay = int.Parse(inputFieldDay.text);
        goalHour = int.Parse(inputFieldHour.text);
        goalMinute = int.Parse(inputFieldMinute.text);
    }

    void DisplayAlerm() {
        //Debug.Log(goalYear + " " + goalMonth + " " + goalDay + " " + goalHour + " " + goalMinute);
        DateTime goalTime;
        try {
            goalTime = new DateTime(goalYear, goalMonth, goalDay, goalHour, goalMinute, 0, DateTimeKind.Local);

        } catch {
            goalTime = DateTime.Now;
        }

        //Debug.Log(goalTime);
        goalTimeT = goalTime.Ticks;
        //Debug.Log(goalTimeT);

        //636691762800000000
        long nowT = DateTime.Now.Ticks;
        long ts = (goalTimeT - nowT) / (10000000);

        if (ts <= 0) {
            // Time Over
            timeText.text = "0:00";
            playerAnimator.SetInteger("mode", 99);

            timeoverGroup.SetActive(true);

            if (isDisplayDialogue == false) {
                timeline.Play();
            }
        } else {
            // No Time Over
            long h = ts / 3600;
            ts = ts - h * 3600;
            long m = ts / 60;
            ts = ts - m * 60;
            long s = ts;
            if (h > 0) {
                timeText.text = string.Format("{0}:{1:D2}:{2:D2}", h, m, s);
            } else {
                timeText.text = string.Format("{0:D}:{1:D2}", m, s);
            }

            // character animation
            if (s % motionIntervalSec == 0) {
                if (playerAnimator.GetInteger("mode") == 0) {
                    int mode = UnityEngine.Random.Range(1, 4);
                    playerAnimator.SetInteger("mode", mode);
                }
            } else {
                playerAnimator.SetInteger("mode", 0);
            }
            Debug.Log("mode=" + playerAnimator.GetInteger("mode") + " s=" + s);
        }
    }

    void NoTimeOver() {
        timeText.text = "0:00";
        playerAnimator.SetInteger("mode", 99);

        timeoverGroup.SetActive(true);

        if (isDisplayDialogue == false) {
            timeline.Play();
        }
    }

    public void AlermStartButtonClick() {
        Debug.Log("AlermStartButtonClick()");
        //gameController.GetComponent<GameController>().isDisplayDialogue = false;
        isDisplayDialogue = false;
    }

    public void ExitButtonClick() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
		Application.OpenURL("http://www.yahoo.co.jp/");
#else
		Application.Quit();
#endif
    }
}