using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float[] correctRotations; // Set these in the Inspector (e.g., 0, 90)
    [HideInInspector] public bool isCorrect = false;

    void Start()
    {
        // Randomize rotation at start so it's a puzzle
        int[] possibleRots = { 0, 90, 180, 270 };
        transform.eulerAngles = new Vector3(0, 0, possibleRots[Random.Range(0, 4)]);
        CheckRotation();
    }

    void OnMouseDown()
    {
        transform.Rotate(0, 0, 90);
        CheckRotation();
        // Find the Manager and tell it to check the whole board
        FindObjectOfType<LevelManager>().CheckVictory();
    }

    void CheckRotation()
    {
        isCorrect = false;
        // Check current Z rotation against our "winning" angles
        float currentRot = Mathf.Round(transform.eulerAngles.z);
        if (currentRot >= 360) currentRot -= 360;

        foreach (float angle in correctRotations)
        {
            if (Mathf.Abs(currentRot - angle) < 2)
            { // Small margin for float errors
                isCorrect = true;
            }
        }
    }
}