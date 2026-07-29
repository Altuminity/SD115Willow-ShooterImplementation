using UnityEngine;
using UnityEngine.Events;
using System;

/*4 things with Object Oriented Programming
 * Encapsulation - You can hide things that are public, and show things that are private. Private things cant be used by other scripts, whereas public things can be. Protected is a special use case for inheritance Ensuring that variables and properties are controlled using getters and setters
 * Inheritance - Protected objects can only be accessed by the CHILD of said object
 * Abstraction - The less that things are connected together in scripts (abstract functions), the easier it is to design stuff later (i can make a chair have healing properties, or have enemy properties, etc)
 * Polymorphism - 
 */

public class Health : MonoBehaviour
{
    // variables
    //private int _health;
    [SerializeField] private int _maxHealth = 100;

    // properties / getters, write them with a capital, these are used outside of this script
    public int MaxHealth => _maxHealth;

    public int CurrentHealth { get; private set; }

    public bool IsDead => CurrentHealth <= 0;

    public UnityEvent<int> OnDamaged;
    public UnityEvent OnDied;
    
    // setters
    public void TakeDamage(int amount)
    {
        if (IsDead) return;

        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0); //ensures that health is NEVER below zero as that could introduce bugs.

        OnDamaged?.Invoke(amount);

        if (IsDead)
        {
            // Handle death :3c
            OnDied?.Invoke();
        }
    }

    public void Heal(int amount)
    {
        if (IsDead) return;

        CurrentHealth = Mathf.Min(CurrentHealth + amount, MaxHealth);
    }

    public void Revive(int amount)
    {
        if (!IsDead) return;

        CurrentHealth = MaxHealth;
    }

    public void Die()
    {
        Destroy(gameObject);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
