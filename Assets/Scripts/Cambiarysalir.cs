using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiarysalir : MonoBehaviour {
    
   public void Cambiarscena() {
        SceneManager.LoadScene("1", LoadSceneMode.Single);
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public void Salir() {
        Application.Quit();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
