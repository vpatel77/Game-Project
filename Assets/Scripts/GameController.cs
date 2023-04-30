using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject ball;

    public Text scoreTextLeft;
    public Text scoreTextRight;

    public Starter starter; 

    private bool started = false;

    private int scoreLeft = 0;
    private int scoreRight = 0;

    private BallControl ballController;

    private Vector3 startingPosition;


    // Start is called before the first frame update
    void Start()
    {
        this.ballController = this.ball.GetComponent<BallControl>();
        this.startingPosition = this.ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.started){
            return;
        }

        if (Input.GetKey(KeyCode.Space)){
            this.started = true;
            this.starter.StartCountdown();
        }
    }

    public void StartGame(){
        this.ballController.Go();
    }

    public void ScoreGoalLeft(){
        Debug.Log("ScoreGoalLeft");
        this.scoreRight += 1;
        UpdateUI();
        ResetBall();
    }

    public void ScoreGoalRight(){
        Debug.Log("ScoreGoalRight");
        this.scoreLeft += 1;
        UpdateUI();
        ResetBall();
    }

    private void UpdateUI(){
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
    }

    private void ResetBall(){
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.starter.StartCountdown();
    }
}
