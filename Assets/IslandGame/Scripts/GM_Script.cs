using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GM_Script : MonoBehaviour
{
    public bool gotKey, gotMap, gotSpade, isIntro, isStart, isEnd, isPaused;
    public int gemsFound;
    public bool[] buttonsPressed = new bool[5];

    public Graphic keyIcon, mapIcon, spadeIcon;
    [SerializeField] GameObject introText, endText, pauseMenu;
    public PlayerMovementScript player;
    [SerializeField] RawImage strtImg;
    [SerializeField] AudioSource titleTune;

    public TextMeshProUGUI promptText, gemsTotal;
    public TextMeshPro cliffSign;

    [SerializeField] GameObject miniMap;

    public void addItem(string item)
    {
        switch (item)
        {
            case "Map":
                gotMap = true;
                mapIcon.color = Color.green;
                miniMap.SetActive(true);
                break;
            case "Spade":
                gotSpade = true;
                spadeIcon.color = Color.green;
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gotKey = false;
        keyIcon.color = Color.red;
        gotMap = false;
        mapIcon.color = Color.red;
        gotSpade = false;
        spadeIcon.color = Color.red;

        isIntro = true;
        isStart = true;
        isEnd = false;
        promptText.text = " ";

        cliffSign.text = "I bet you wish you lowered the bridge before coming all the way up here";
        
        endText.SetActive(false);

        pauseMenu.SetActive(false);
        titleTune.Play();

        miniMap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //convert gems total to string for UI
        gemsTotal.text = gemsFound.ToString();

        // set colour for got key UI icon
        if (gotKey && keyIcon.color == Color.red)
        {
            keyIcon.color = Color.green;
        }

        // start from menu
        if (Input.GetMouseButtonDown(0) && isStart)
        {
            strtImg.enabled = false;
            isStart = false;
            titleTune.Stop();
        } 

        // skip tutorial text and start
        if (Input.GetButtonDown("Jump") && isIntro && !isStart)
        {
            introText.SetActive(false);
            player.speed = 15;
            isIntro = false;
        }

        // toggle pause menu during gameplay only
        if (!isIntro && !isStart && !isEnd)
        {
            if (Input.GetKeyDown("p") && !isPaused)
            {
                isPaused = true;
                pauseMenu.SetActive(true);
            }

            if (isPaused)
            {
                player.speed = 0;
                if (Input.GetButtonDown("Jump"))
                {
                    isPaused = false;
                    pauseMenu.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }
            }
            else
            {
                if (player.speed == 0)
                {
                    player.speed = 15;
                }
            }
        }

        // alter drawbride sign text
        if (buttonsPressed[0])
        {
            cliffSign.text = "Good work getting that bridge down, you're the best!";
        }

        // toggle end menu
        if (isEnd)
        {
            if(player.speed > 0)
            {
                titleTune.Play();
                player.speed = 0;
                endText.SetActive(true);
            }

            if (Input.GetButtonDown("Jump"))
            {
                Application.Quit();
            }
        }
    }
}
