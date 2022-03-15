using UnityEngine;
using UnityEngine.UI;
public class Best : MonoBehaviour
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
        scoreText.text =  "Best: " + player.lengthBest;
    }
}
