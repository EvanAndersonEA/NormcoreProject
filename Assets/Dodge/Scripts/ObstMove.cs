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
        player = GameObject.FindGameObjectWithTag("Player");
        scenePlayer = GameObject.FindGameObjectWithTag("EditorOnly");
    }

    void Update()
    {

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
        player = GameObject.FindGameObjectWithTag("Player");
        if (other.gameObject.name == "HeadMesh")
        {
            //Debug.Log("Hit Camera trigger");
            player.GetComponent<Transform>().position = losePos;
            scenePlayer.GetComponent<Transform>().position = losePos;
            if (transform.position.x <= -4.5f)
            {
                currentText = Instantiate(textobj, new Vector3(-4.61f, 6.53f, 7.17f), Quaternion.Euler(0, 180, 0));
                currentText.GetComponentInChildren<TextMeshPro>().text = ("Blue Wins");
            }
            else
            {
                currentText = Instantiate(textobj, new Vector3(-4.61f, 6.53f, 7.17f), Quaternion.Euler(0, 180, 0));
                currentText.GetComponentInChildren<TextMeshPro>().text = ("Red Wins");
                //Debug.Log(currentText.GetComponentInChildren<Transform>().position);
            }
        }
    }
}
