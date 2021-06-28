using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameController : MonoBehaviour
{
    public GameObject miniGameHowToMenu;

    public GameObject gameOverMenu;

    public Transform puzzleField;
    public GameObject btn;
    public int nubmerOfButtons;

    public GameObject wall;

    public List<Button> buttonList = new List<Button>();

    public List<int> correctAnswer = new List<int>();

    private int countdownTime = 3;
    public Text countdownText;

    private bool isPlaying = false;

    private int gemCount;

    public PlayerMovement playerMovement;

    private int incorrectGuess = 0;

    private void Awake()
    {
        for (int i = 0; i < Mathf.Pow(nubmerOfButtons, 2); i++)
        {
            GameObject button = Instantiate(btn);
            button.name = $"{i}";
            button.transform.SetParent(puzzleField, false);
        }

        GetButtons();
        AddListeners();


    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        //Debug.Log(InventoryOfPlayer.gems);
        ChangeToYellow();
        countdownText.gameObject.SetActive(true);
        StartCoroutine(Countdown());
    }


    private void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("pPiece");

        Debug.Log(objects.Length);

        for (int i = 0; i < objects.Length; i++)
        {
            buttonList.Add(objects[i].GetComponent<Button>());
        }
    }

    private void ChangeToYellow()
    {
        for (int i = 0; i < (nubmerOfButtons * 2) - 2; i++)
        {
            int temp = Random.Range(0, buttonList.Count);
            while (correctAnswer.Contains(temp))
            {
                temp = Random.Range(0, buttonList.Count);
            }
            correctAnswer.Add(temp);
            buttonList[temp].GetComponent<Image>().color = Color.yellow;
        }
    }

    IEnumerator Countdown()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();

            yield return new WaitForSeconds(1.0f);

            countdownTime--;
        }

        countdownText.text = "GO!";

        BeginGame();

        yield return new WaitForSeconds(0.5f);

        countdownText.gameObject.SetActive(false);
    }

    private void BeginGame()
    {
        foreach (int i in correctAnswer)
        {
            buttonList[i].image.color = new Color32(40, 40, 40, 255);
        }
        isPlaying = true;
    }


    private void AddListeners()
    {
        foreach(Button btn in buttonList)
        {
            btn.onClick.AddListener( () => PickAPuzzle() );
        }
    }
    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        int index = int.Parse(name);

        if (isPlaying)
        {
            if (correctAnswer.Contains(index))
            {
                buttonList[index].image.color = Color.yellow;
                correctAnswer.Remove(index);
                CheckIfFinish();
            }
            else
            {
                incorrectGuess += 1;
                buttonList[index].image.color = Color.red;
            }

            if (incorrectGuess == 3)
            {
                isPlaying = false;
                playerMovement.canMove = true;
                gameObject.SetActive(false);
                gameOverMenu.SetActive(true);
            }
        }
       
    }

    private void CheckIfFinish()
    {
        if(correctAnswer.Count <= 0)
        {
            foreach (Button btn in buttonList)
            {
                btn.image.color = new Color32(40, 40, 40, 255);
            }

            countdownTime = 3;
            isPlaying = false;

            Destroy(wall);

            playerMovement.canMove = true;

            gameObject.SetActive(false);
        }
    }

    public void GotItMenu()
    {
        miniGameHowToMenu.SetActive(false);
        gameObject.SetActive(true);
    }
}


