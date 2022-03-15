using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    // Start is called before the first frame update

    public Snake player;
    public Text scoreText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + player.length;
    }
}
