using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("MainMenu References")]
    public GameObject[] buttons;
    public GameObject[] panels;
    public Image[] ilustrations;

    //Intern Variables
    float timerCount;
    //int musicIndex = 0;
    int currentSceneIndex;
    bool winnerDoorKnocked;
    float camSize;
    bool OnCinematic;
    

    [Header("Level 1")]
    public GameObject[] lvlDoors;
    public GameObject playerObj;
    public PlayerMovement playerController;
    public DoorDetection playerCollisions;
    public Doors doorsController;
    public CameraFollow2 camController;
    public Camera mainCam;
    public BarreraTutorial barrera;
    public GameObject powerUp;
    public int instanciasHechas = 0;
    public int doorCounter;

    [Header("Controllers")]
    public MusicController music;

    public Vector2 tutorialMaxCam, tutorialMinCam;
    public Vector2 basicMaxCam, basicMinCam;

    private Vector3 pwUpPosInstance;

    private int woodCounter;

    // Start is called before the first frame update
    private void Awake() {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update() {
        music = FindObjectOfType<MusicController>();

        if (SceneManager.GetActiveScene().name == "MainMenu") {
            music.StopMusic("AdventureMusic");
            if (music.musicLength > 2f) {
                music.MusicChange("Menu");
            }
        }

        if (SceneManager.GetActiveScene().name == "WinLvl1") {
            music.StopMusic("AdventureMusic");
            if (music.musicLength > 2f) {
                music.MusicChange("Menu");
            }
        }

        if (SceneManager.GetActiveScene().name == "GamePlay_Lvl1") {
            
            playerObj = GameObject.FindGameObjectWithTag("Player");
            lvlDoors = GameObject.FindGameObjectsWithTag("Door");
            playerCollisions = FindObjectOfType<DoorDetection>();
            
            if (playerCollisions.puertaDetectada != null) {
                doorsController = playerCollisions.puertaDetectada.GetComponent<Doors>();
            }
            
            playerController = FindObjectOfType<PlayerMovement>();
            camController = FindObjectOfType<CameraFollow2>();
            mainCam = FindObjectOfType<Camera>();
            barrera = FindObjectOfType<BarreraTutorial>();
            camSize = mainCam.orthographicSize;
            StepsGameFlow();

            if (playerCollisions.lostCondition) {
                ChangeLvl("PerdisteLvl1");
            }

            doorCounter = playerCollisions.listaPuertas.ToArray().Length;

            if (Input.GetKey(KeyCode.Escape)) {
                FindObjectOfType<SceneController>().SalirDelJuego();
            }
        }

        if (SceneManager.GetActiveScene().name == "PerdisteLvl1") {
            doorCounter = 0;
            instanciasHechas = 0;
        }
        
    }

    void BaseModeGameplay() {

        //music.MusicChange(music.basicAdventure);

        if(camSize < 6.7) {
            StartCoroutine(BaseCamMode());
        }
        else {
            StopCoroutine(BaseCamMode());
            barrera.desactivar = true;
            mainCam.orthographicSize = 6.7f;
            camController.maxCamPos = basicMaxCam;
            camController.minCamPos = basicMinCam;
        }
        
    }

    IEnumerator BaseCamMode() {
        mainCam.orthographicSize += 1f * Time.deltaTime;
        yield return new WaitForSeconds(1f);
    }

    void TutorialMode() {
        mainCam.orthographicSize = 4f;
        camController.maxCamPos = tutorialMaxCam;
        camController.minCamPos = tutorialMinCam;
    }

    void UbicacionPowerUp() {
        pwUpPosInstance.x = playerObj.transform.position.x + 3f;
        pwUpPosInstance.y = playerObj.transform.position.y + 0.4f;
    }

    void SJ_OP() {
        playerController.moveSpeed = playerController.moveSpeed * 1.5f;
        playerController.jumpSpeed = playerController.jumpSpeed * 1.2f;
    }

    void ChangeLvl(string name) {
        FindObjectOfType<SceneController>().CambiarEscena(name);
    }

    void StepsGameFlow() {
        if (doorCounter >= 1) {
            BaseModeGameplay();
            /*if (doorsController.hasBeKnocked) {
                
            }*/
            if(doorCounter >= 10) {
                if (instanciasHechas == 0) {
                    UbicacionPowerUp();
                    Instantiate(powerUp, pwUpPosInstance, playerObj.transform.rotation);
                    instanciasHechas++;
                }
                if (doorCounter == lvlDoors.Length) {
                    Debug.Log("Ganaste");
                    ChangeLvl("WinLvl1");
                }
            }
        }
        else {
            TutorialMode();
        }
    }

}
