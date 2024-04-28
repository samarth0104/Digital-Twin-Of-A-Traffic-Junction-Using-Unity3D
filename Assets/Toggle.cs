using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ToggleNavMeshObstacle : MonoBehaviour
{
    public NavMeshObstacle navMeshObstacle;
    public Button button;
    public Color defaultColor = Color.white;
    public Color clickedColor = Color.green;
    private bool isClicked = false;

    private void Start()
    {
        // Ensure the NavMeshObstacle component is assigned
        if (navMeshObstacle == null)
        {
            navMeshObstacle = GetComponentInParent<NavMeshObstacle>();
        }

        // Set initial button color to default color
        SetButtonColor(defaultColor);
    }

    public void ToggleObstacle()
    {
        // Toggle the NavMeshObstacle component on/off
        navMeshObstacle.enabled = !navMeshObstacle.enabled;

        // Toggle button color
        if (isClicked)
        {
            // Set button color to default color
            SetButtonColor(defaultColor);
        }
        else
        {
            // Set button color to clicked color
            SetButtonColor(clickedColor);
        }

        // Toggle the clicked state
        isClicked = !isClicked;
    }

    private void SetButtonColor(Color color)
    {
        // Get the image component of the button
        Image buttonImage = button.GetComponent<Image>();

        // Change the color of the button image
        buttonImage.color = color;
    }
}