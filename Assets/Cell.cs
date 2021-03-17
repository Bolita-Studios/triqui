using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cell : MonoBehaviour
{
    // Start is called before the first frame update
    //public Sprite sprite;
    public int[] id = new int[2];
    bool isPressed = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeCellColor()
    {
        if (!isPressed)
        {
            GetComponent<Image>().color = Controller.players[Controller.activePlayer].color;
            isPressed = true;
            Controller.players[Controller.activePlayer].table[id[0], id[1]] = true;
            if (Controller.IsDone(Controller.players[Controller.activePlayer].table))
            {
                Debug.Log("Game Over | Player "+(Controller.activePlayer+1)+" is the winner");
            }
            Controller.ChangePlayer();
        }
       
    }
}

