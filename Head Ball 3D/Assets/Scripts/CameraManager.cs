using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    public static CameraManager Instance;
    public bool dynamicCam = false;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject platform;

    [SerializeField] private GameObject playerFarCamera;
    [SerializeField] private GameObject playerFollowCameraMiddle;
    [SerializeField] private GameObject playerFollowCameraNear1;
    [SerializeField] private GameObject playerFollowCameraNear2;
    [SerializeField] private GameObject playerDeadCamera;
    [SerializeField] private GameObject deadCameraPath;

    private void Awake()
    {
        SingletonPattern();
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.OnGameStarted += GameStarted;
        EventManager.Instance.OnPlayerWin += NextRound;
        EventManager.Instance.OnOpponentWin += NextRound;
        EventManager.Instance.OnNextRound += NextRoundPass;
        EventManager.Instance.OnPlayerWinMatch += PlayerWinCam;
        EventManager.Instance.OnOpponentWinMatch += PlayerWinCam;

        if (playerFollowCameraMiddle.activeSelf)
        {
            playerFollowCameraMiddle.SetActive(false);
        }
        playerFarCamera.SetActive(true);
        platform = GameObject.Find("Platform");
        playerDeadCamera.GetComponent<CinemachineVirtualCamera>().LookAt = platform.transform;

    }

    private void Update()
    {
        if (dynamicCam == true)
        {
            if (player.transform.localPosition.z > -1.5f)
            {
                playerFollowCameraNear1.SetActive(false);
                playerFollowCameraMiddle.SetActive(true);
            }
            else if (player.transform.localPosition.z < -1.5f && player.transform.localPosition.z > -3)
            {
                playerFollowCameraMiddle.SetActive(false);
                playerFollowCameraNear1.SetActive(true);
            }
            else if (player.transform.localPosition.z < -3)
            {
                playerFollowCameraNear1.SetActive(false);
                playerFollowCameraNear2.SetActive(true);
            }
        }
    }
    
    #region Singleton

    
    private void SingletonPattern()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


    #endregion

    public void GameStarted()
    {
        playerFarCamera.SetActive(false);
        playerFollowCameraMiddle.SetActive(true);
    }

    public void NextRound()
    {
        dynamicCam = false;
        playerFollowCameraMiddle.SetActive(false);
        playerFollowCameraNear1.SetActive(false);
        playerFollowCameraNear2.SetActive(false);
        playerFarCamera.SetActive(true);
      
        /*deadCameraPath.SetActive(true);
        playerDeadCamera.SetActive(true);*/
    }

    public void NextRoundPass()
    {
        dynamicCam = true;
        /*deadCameraPath.SetActive(false);
        playerDeadCamera.SetActive(false);*/
        playerFollowCameraMiddle.SetActive(true);
        playerFarCamera.SetActive(false);
    }

    public void PlayerWinCam()
    {
        deadCameraPath.SetActive(true);
        playerDeadCamera.SetActive(true);
        playerDeadCamera.GetComponent<CinemachineVirtualCamera>().Priority = 11;
    }
    
}
