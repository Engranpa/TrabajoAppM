using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class buff_spawn : NetworkBehaviour{
    public GameObject m_MyGameObject;
    GameObject m_MyInstantiated;
    // Use this for initialization
    void Start()
    {
        m_MyInstantiated = Instantiate(m_MyGameObject);
        NetworkServer.Spawn(m_MyInstantiated);
    }
}

