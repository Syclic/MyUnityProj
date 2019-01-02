using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat vitalAura, potency, deflect;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage (float damage)
    {
        damage -= deflect.GetCurrentValue();
        damage = Mathf.Clamp(damage, 0, float.MaxValue);
        vitalAura.SetValue(vitalAura.GetCurrentValue() - damage);
        Debug.Log(transform.name + " takes damage. " + damage);

        if( vitalAura.GetCurrentValue() <= 0)
        {
            Debug.Log(transform.name + " died.");
            Die();
            vitalAura.SetValue(0);
        }
    }

    public virtual void Die()
    {
        //Default death.
        //gets replaced based on character that dies.
    }
}
