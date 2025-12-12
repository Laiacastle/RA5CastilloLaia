using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CinemachineMixingCamera mixingCamera;
    void Awake()
    {
        mixingCamera.ChildCameras[0].enabled = false;
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        mixingCamera = GetComponent<CinemachineMixingCamera>();
        if (_player != null)
        {
            _player.DanceEvent += DanceEvent;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        _player.DanceEvent -= DanceEvent;
    }

    public void DanceEvent(bool dancing)
    {
       if (dancing)
       {
           Debug.Log("Camera: Player started dancing");
           mixingCamera.ChildCameras[0].enabled = true; // Full View Camera
            mixingCamera.ChildCameras[1].enabled = false;
        }
       else
       {
           Debug.Log("Camera: Player stopped dancing");
           mixingCamera.ChildCameras[1].enabled = true; // 3 person View Camera
            mixingCamera.ChildCameras[0].enabled = false;
        }
    }
}
