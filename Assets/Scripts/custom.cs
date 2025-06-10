using UnityEngine;

public class Opp : MonoBehaviour
{
    void Start()
    {
        // Task 1: Print numbers 1 to 10 in one line
        string numbers = "";
        for (int i = 1; i <= 10; i++)
        {
            numbers += i + " ";
        }
        Debug.Log("Task 1: " + numbers);

        // Task 2: Increment smaller number until equal to larger
        int num1 = 3;
        int num2 = 7;
        int count = 0;

        while (num1 < num2)
        {
            num1++;
            count++;
        }

        Debug.Log("Task 2: It took " + count + " increments to make the numbers equal.");
    }

    void Update()
    {
        
    }
}