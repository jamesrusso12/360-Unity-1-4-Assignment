using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Billboard : MonoBehaviour
{
    public Camera m_Camera;
    [SerializeField] private GameObject _player;
    private InputData _inputData;

    void Start()
    {
        _inputData = _player.GetComponent<InputData>();
    }

    void Update()
    {
        if(_inputData._leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool _xButtonPressed)){
            if(!_xButtonPressed){
                transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
                m_Camera.transform.rotation * Vector3.up);
                // The next three lines make this work only on the horizontal axis
                Vector3 eulerAngles = transform.eulerAngles;
                eulerAngles.z = 0;
                transform.eulerAngles = eulerAngles;
            }
        }
    }
}
