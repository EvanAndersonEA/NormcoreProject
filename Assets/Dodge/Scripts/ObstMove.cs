using UnityEngine;
using TMPro;

public class ObstMove : MonoBehaviour
{
    public float speed;
    public bool zlimitpositive;
    [SerializeField]
    GameObject textobj;
    GameObject player, scenePlayer, currentText;
    Vector3 losePos = new Vector3(-4.563f, 5.021f, 9.536f);

    private void Awake()
    {
        //get all the gameobjects
        player = GameObject.FindGameObjectWithTag("Player");
        scenePlayer = GameObject.FindGameObjectWithTag("EditorOnly");
    }

    void Update()
    {
        //moves the blocks according to what they are assigned to in the inspector
        if(zlimitpositive == false)
        {
            if (transform.position.z >= -200)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (transform.position.z <= 200)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //when an obsticle hits the player
        player = GameObject.FindGameObjectWithTag("Player");
        if (other.gameObject.name == "HeadMesh")
        {
            //teleports the player to the lose position
            player.GetComponent<Transform>().position = losePos;
            scenePlayer.GetComponent<Transform>().position = losePos;
            //sees which side the player got hit on
            if (transform.position.x <= -4.5f)
            {
                //Spawn the text saying the other person won
                currentText = Instantiate(textobj, new Vector3(-4.61f, 6.53f, 7.17f), Quaternion.Euler(0, 180, 0));
                currentText.GetComponentInChildren<TextMeshProUGUI>().text = ("Blue Wins");
            }
            else
            {
                //Spawn the text saying the other person won
                currentText = Instantiate(textobj, new Vector3(-4.61f, 6.53f, 7.17f), Quaternion.Euler(0, 180, 0));
                currentText.GetComponentInChildren<TextMeshProUGUI>().text = ("Red Wins");
            }
        }
    }
}
