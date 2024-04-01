using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public abstract void UseAbility();

    public bool IsPurchased { get; set; }

}
