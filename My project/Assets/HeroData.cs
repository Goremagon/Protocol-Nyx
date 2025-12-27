using UnityEngine;
using System.Collections.Generic; // <--- This is the key fix!

[System.Serializable]
public class HeroData 
{
    // --- Identity & Loyalty ---
    public string HeroName;
    public string Species; 
    public int Level;
    public float Loyalty; 
    public float SalaryWeekly; 

    // --- Roles & Skills ---
    public string CurrentAssignment; 
    public List<string> Skills = new List<string>(); 

    // --- Cybernetics & Cloning ---
    public List<string> CyberneticImplants = new List<string>(); 
    public bool IsCloned; 

    // --- Negative Traits ---
    public List<string> TraumaTraits = new List<string>(); 
}