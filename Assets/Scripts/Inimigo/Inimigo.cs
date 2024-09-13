using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private int vidas;

    public void ReceberDano() {
        this.vidas--;
        Debug.Log(this.name + "recebeu dano. Vida:" + this.vidas);
        if (this.vidas == 0 ) {
            GameObject.Destroy(this.gameObject);
        }
    }

}
