using UnityEngine;

public class ObsSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject left = null, right = null, duck = null, bottom = null;
    float timeLeft, newzPos, timerTotal;
    public float zpos, xpos, speed;
    public int randomNumber, lastRandomNumber;
    private int difficulty = 1;
    public bool zlimitpositive;
    GameObject currentObs = null, doggie;

    private void Awake()
    {
        //difficulty = FindObjectOfType<DifficultyManager>().currentDifficulty;
        currentObs = duck;
        timerTotal = 0.75f;
        timeLeft = 0.75f;
    }

    void Update()
    {
        if (timeLeft <= 0)
        {
            SpawnObject(zpos);
            timeLeft = timerTotal;
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }

    void SpawnObject(float zpos)
    {
        lastRandomNumber = randomNumber;
        randomNumber = Random.Range(0, 4);

        if (randomNumber == 1 && 1 != lastRandomNumber)
        {
            currentObs = duck;
        }
        else if (randomNumber == 2 && 2 != lastRandomNumber)
        {
            currentObs = right;
        }
        else if (randomNumber == 3 && 3 != lastRandomNumber)
        {
            currentObs = left;
        }
        else if (randomNumber == 0 && 0 != lastRandomNumber)
        {
            currentObs = bottom;
        }
        else
        {
            lastRandomNumber = randomNumber;
            randomNumber = Random.Range(0, 4);

            if (randomNumber == 1 && 1 != lastRandomNumber)
            {
                currentObs = duck;
            }
            else if (randomNumber == 2 && 2 != lastRandomNumber)
            {
                currentObs = right;
            }
            else if (randomNumber == 3 && 3 != lastRandomNumber)
            {
                currentObs = left;
            }
            else if (randomNumber == 0 && 0 != lastRandomNumber)
            {
                currentObs = bottom;
            }
        }
        doggie = Instantiate(currentObs, new Vector3(xpos, 0, zpos), Quaternion.identity);
        doggie.GetComponent<ObstMove>().speed = speed;
        doggie.GetComponent<ObstMove>().zlimitpositive = zlimitpositive;
    }
}
