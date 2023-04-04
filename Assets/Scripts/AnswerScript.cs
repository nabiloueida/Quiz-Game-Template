using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
   
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer()
    {
        //Debug.Log(isCorrect);
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Incorrect Answer");
            quizManager.wrong();
        }

    }
}
