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

    Animator animator;
    Controller controller;
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = Controller.instance;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeCellColor()
    {
        if (!isPressed)
        {
           // GetComponent<Image>().color = controller.players[controller.activePlayer].color;
            animator.SetInteger("playerActive", controller.activePlayer);
            isPressed = true;
            controller.players[controller.activePlayer].table[id[0], id[1]] = true;
            if (controller.IsDone(controller.players[controller.activePlayer].table))
            {
                Debug.Log("Game Over | Player "+(controller.activePlayer+1)+" is the winner");
            }
            controller.ChangePlayer();
        }
       
    }
}

