using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    
 
    public class Player {

        bool isActive = false;
        public Color color;
     

        public bool [,]table = new bool[3,3];

  
        public Player(Color color)
        {
            this.color = color;
            InitializeTable();
        }

        public void InitializeTable()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    table[i, j] = false;
                }
            }
        }
    }

    public List<Player> players = new List<Player>(2);
     public int  activePlayer;

    #region Singlenton

    public static Controller instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        CreatePlayers();
        activePlayer = 0;

    }

    void CreatePlayers()
    {
        players.Add(new Player(Color.red));
        players.Add(new Player(Color.green));
    }

    public  void ChangePlayer()
    {
        activePlayer = (activePlayer + 1) % players.Count;
    }


     public bool IsDone(bool[,] table)
    {
        int numValidationRows, numValidationCols, numValidationDiag = 0, numValidationDiagInv = 0;

        for (int i = 0; i < 3; i++)
        {
            numValidationRows = 0;
            numValidationCols = 0;

            for (int j = 0; j < 3; j++)
            {
                if (table[i, j])
                {
                    numValidationRows += 1;

                    if (i == j) numValidationDiag += 1;
   
                    if ((i + j) == 2) numValidationDiagInv += 1;

                }

                if (table[j, i]) numValidationCols += 1;
    
            }

            if (numValidationRows == 3 || numValidationCols==3) return true;
        }
   
        if (numValidationDiag == 3 || numValidationDiagInv == 3) return true;

        return false;

    }
    

        
    

}
