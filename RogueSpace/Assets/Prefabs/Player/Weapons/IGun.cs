using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun {

    void Shoot(Vector3 aim);

    int GetDamage();
    string GetDescription();
    string GetName();
    string GetProperties();

}
