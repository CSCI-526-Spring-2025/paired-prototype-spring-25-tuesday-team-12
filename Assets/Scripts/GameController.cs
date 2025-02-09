using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isRotateState = true;
    GameObject ball;        // in "rotate state", the fakeball without physics would be activated (to prevent falling), 
    GameObject fakeBall;    // in "play state" the real ball with physics would be activated

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        ball = GameObject.Find("Ball");
        fakeBall = GameObject.Find("FakeBall"); 

        ball.SetActive(!isRotateState);
        fakeBall.SetActive(isRotateState);
    }

    // Update is called once per frame
    void Update()
    {
        // the state is toggled with Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRotateState = !isRotateState;
            Debug.Log("isRotateState: " + isRotateState);

            ball.SetActive(!isRotateState);
            ball.transform.position = fakeBall.transform.position;
            ball.GetComponent<Ball>().SetStartPosition(ball.transform.position);
            ball.GetComponent<Ball>().ResetPosition();
            fakeBall.SetActive(isRotateState);
        }

        // R key resets the ball
        if(Input.GetKeyDown(KeyCode.R))
        {
            ball.GetComponent<Ball>().ResetPosition();
        }
    }

    public void Sucess()
    {
        // would be called by Goal as the ball got to the goal
        ball.GetComponent<Ball>().Freeze();
    }
}
