using UnityEngine;

public class DefenderPlayerMovement : MonoBehaviour
{

    Vector3[] positions;
    void Start()
    {
        float posX = 4.32f;
        float posY = 3.3f;
        Vector3 initialPos = new Vector3(posX, posY, 0.0f);
        positions = new[] {
            new Vector3(initialPos.x, initialPos.y - 0*posY, initialPos.z),
            new Vector3(initialPos.x, initialPos.y - 1*posY, initialPos.z),
            new Vector3(initialPos.x, initialPos.y - 2*posY, initialPos.z)
        };
    }

    void Update()
    {
        float inputY = Input.GetAxis("Vertical");

        if (inputY < 0)
            transform.position = positions[2];
        else if (inputY > 0)
            transform.position = positions[0];
        else
            transform.position = positions[1];
    }
}
