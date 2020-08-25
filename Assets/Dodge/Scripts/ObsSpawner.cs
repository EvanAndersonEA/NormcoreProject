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
        //sets the timer time and the first object
        currentObs = duck;
        timerTotal = 0.75f;
        timeLeft = 0.75f;
    }

    void Update()
    {
        //when the timer runs out spawn an object
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
        //spawn a random object, if its the same as the last it spawns a random object again (this means that it is possible for 2 of the same obsticle to spawn back to back)
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
        //sets the new objects speed, direction and spawn location according to the inspector
        doggie = Instantiate(currentObs, new Vector3(xpos, 0, zpos), Quaternion.identity);
        doggie.GetComponent<ObstMove>().speed = speed;
        doggie.GetComponent<ObstMove>().zlimitpositive = zlimitpositive;
    }
}
