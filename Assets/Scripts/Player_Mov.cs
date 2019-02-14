using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player_Mov :  NetworkBehaviour{
    public GameObject babapref;
    public Transform balaspawn;


    void Start(){
        if (isLocalPlayer){
            //Camera.main.transform.position = this.transform.position - this.transform.forward * 10 + this.transform.up * 3;
           
            Camera.main.transform.LookAt(this.transform.position);
            Camera.main.transform.parent = this.transform;
            
        }     
    }

    void Update(){
        if (!isLocalPlayer){
            return;
        }
        GetComponentInChildren<Camera>().transform.LookAt(this.transform.position);
        // GetComponentInChildren<Camera>().transform.Translate(Vector3.right * Time.deltaTime);
        var vec = CrossPlatformInputManager.GetAxis("Horizontalm");
        if (vec <= -0.1f)
        {
            //   GetComponentInChildren<Camera>().transform.Translate(Vector3.left * Time.deltaTime * 3);  //rotación de la camara con el joystick del medio
            this.transform.Rotate(Vector3.down * Time.deltaTime * 60f);
        }
        else if (vec >= 0.1f)
        {

            // GetComponentInChildren<Camera>().transform.Translate(Vector3.right * Time.deltaTime * 3);
            this.transform.Rotate(Vector3.up * Time.deltaTime * 60f);
        }
        else {
            return;
        }
        var x = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var z = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);


        if (CrossPlatformInputManager.GetButtonDown("Fire")){
            CmdFire();
          //Shoot();
        }
    
       
    }
    

    [Command]
    void CmdFire(){
        var bullet = (GameObject)Instantiate( babapref, balaspawn.position, GetComponentInChildren<Camera>().transform.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 3.0f);
    }


    public override void OnStartLocalPlayer(){
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
    private void Shoot()
    {
      //this.transform.rotation = GetComponentInChildren<Camera>().transform.rotation);
    //  GetComponentInChildren<Camera>().transform.rotation = this.transform.rotation;
    }
}
