using UnityEngine;
public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float attackPower = 25f;
    private void Update()
    {
        // Left-click triggers a Raycast attack from the camera
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f))
            {
                // We search exclusively for the parent type 'Actor'
                Actor targetActor = hitInfo.collider.GetComponent<Actor>();
                if (targetActor != null)
                {
                    Debug.Log($"<color=cyan>[PlayerAttacker]</color> Successfully struck an Actor: {targetActor.name}");
                    // POLYMORPHISM IN ACTION: Unity automatically calls the correct child override!
                    targetActor.TakeDamage(attackPower);
                    targetActor.PerformAttack();
                }
            }
        }
    }
}