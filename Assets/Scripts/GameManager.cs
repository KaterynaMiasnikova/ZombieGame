using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> zombies, zombieStarters;
    public GameObject floor;
    private GameObject selectedZombie;
    private int i, score, lives = 0, level = 0;
    private float force;
    public Text scoreText, livesText, levelText;
    // Start is called before the first frame update
    void Start()
    {
        ChangeScore(0);
        ChangeLives(5);
        ChangeLevel();
        force = 7f;
        i = 0;
        selectedZombie = zombies[i];
        selectedZombie.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
    }

    public void AddPoint()
    {
        ChangeScore(10);
        Debug.Log("Score: " + score);
    }

    // Decrease the Players Life
    public void DecreaseLives()
    {
        //write your code below about reducing a life
        ChangeLives(-1);
        //write your code above
        if (lives == 0)
        {
            GameOver();
        }
    }

    public int GetLives()
    {
        return lives;
    }

    // Swaps the UI during a GameOver
    public void GameOver()
    {
        //gameOverScreen.SetActive(true);
        //txt_Lives.enabled = false;
        //txt_Score.enabled = false;
        //txt_FinalScoreValue.text =score.ToString();
    }

    public void NewLevel()
    {
        ChangeLives(0);
        ChangeLives(5);
        floor.transform.Rotate(-2f, 0f, 0f);
        foreach (GameObject zombie in zombies)
        {
            foreach (GameObject pos in zombieStarters)
            {
                if (pos.CompareTag(zombie.tag))
                {
                    zombie.transform.position = pos.transform.position;
                }
            }
        }
        selectedZombie = zombies[0];
        ChangeLevel();
    }

    private void ChangeScore(int j)
    {
        if (j == 0) score = j;
        else score += j;
        scoreText.text = "Score: " + score;
    }

    private void ChangeLives(int j)
    {
        if (j == 0) lives = j;
        else lives += j;
        livesText.text = "Lives: " + lives;
    }

    private void ChangeLevel()
    {
        level++;
        levelText.text = "Level " + level;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            selectedZombie.transform.localScale = new Vector3(1f, 1f, 1f);
            i = i + 1;
            if (i == 4)
                i = 0;
            selectedZombie = zombies[i];
            selectedZombie.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        }

        if (Input.GetKeyDown("left"))
        {
            selectedZombie.transform.localScale = new Vector3(1f, 1f, 1f);
            i = i - 1;
            if (i == -1)
                i = 3;
            selectedZombie = zombies[i];
            selectedZombie.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        }

        if(Input.GetKeyDown("up"))
        {
            Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
            rb.AddForce(
                        new Vector3(0f, 0f, force),
                        ForceMode.Impulse
                       );
        }
    }
}
