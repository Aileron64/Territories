using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleScreen : MonoBehaviour 
{
    EventSystem eventSystem;
    GameObject createServer_Button;
    GameObject joinServer_Button;
    GameObject quit_Button;





    //public GameObject backButton;
    //public GameObject howToPlayText;
    //public GameObject gameLogo;

    int menuPosY = -125;
    int buttonOffsetY = 30;

    void Awake() 
    {
        eventSystem = EventSystem.current;


        createServer_Button = transform.FindChild("CreateServer_Button").gameObject;
        createServer_Button.GetComponent<Button>().onClick.AddListener(() => { CreateServer(); });

        joinServer_Button = transform.FindChild("JoinServer_Button").gameObject;
        joinServer_Button.GetComponent<Button>().onClick.AddListener(() => { JoinServer(); });

        quit_Button = transform.FindChild("Quit_Button").gameObject;
        quit_Button.GetComponent<Button>().onClick.AddListener(() => { Quit(); });


        //backButton.GetComponent<Button>().onClick.AddListener(() => { Back(); });
    }

    void Start() 
    {


        //eventSystem.SetSelectedGameObject(firstSelected, new BaseEventData(eventSystem));
    }

    void CreateServer()
    {
        Debug.Log("CREATE SERVER");
    }


    void JoinServer()
    {
        Debug.Log("JOIN SERVER");
    }


    void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }


    //void PlayGame() 
    //{
    //    Application.LoadLevel("Main");
    //}

    //void HowToPlay() 
    //{
    //    DestroyAllChildren();
    //    GameObject go = Instantiate(howToPlayText, Vector3.zero, Quaternion.identity) as GameObject;

    //    go.transform.parent = transform;
    //    go.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Screen.height / 4);
    //    go = Instantiate(backButton, new Vector3(0, menuPosY - 40, 0), Quaternion.identity) as GameObject;
    //    go.transform.parent = transform;
    //    go.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, menuPosY - buttonOffsetY * 2);
    //    go.GetComponent<Button>().onClick.AddListener(() => { Back(); });
    //    eventSystem.SetSelectedGameObject(go, new BaseEventData(eventSystem));
    //}

    //void ExitGame() 
    //{
    //    Application.Quit();
    //}

    //void Back() 
    //{
        //DestroyAllChildren();
        //GameObject go = null, firstSelected = null;

        //go = Instantiate(gameLogo, Vector3.zero, Quaternion.identity) as GameObject;
        //go.transform.parent = transform;
        //go.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        //go = Instantiate(playButton, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        //firstSelected = go;
        //go.transform.parent = transform;
        //go.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, menuPosY);
        //go.GetComponent<Button>().onClick.AddListener(() => { PlayGame(); });

        //go = Instantiate(howToPlayButton, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        //go.transform.parent = transform;
        //go.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, menuPosY - buttonOffsetY);
        //go.GetComponent<Button>().onClick.AddListener(() => { HowToPlay(); });

        //go = Instantiate(exitButton, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        //go.transform.parent = transform;
        //go.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, menuPosY - buttonOffsetY * 2);
        //go.GetComponent<Button>().onClick.AddListener(() => { ExitGame(); });
    //}

    //void DestroyAllChildren() 
    //{
    //    foreach (Transform child in transform) 
    //    {
    //        Destroy(child.gameObject);
    //    }
    //}
}
