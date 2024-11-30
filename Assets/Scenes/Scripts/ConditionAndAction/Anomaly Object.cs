using UnityEngine;

public class AnomalyObject : MonoBehaviour
{
    // Is there an anomaly? True if yes, false if no.
    public bool isAnomalyPresent;

    // Function to set anomaly state
    public void SetAnomalyState(bool state)
    {
        isAnomalyPresent = state;
    }

    // Function to check anomaly state
    public bool CheckAnomaly()
    {
        return isAnomalyPresent;
    }
}

