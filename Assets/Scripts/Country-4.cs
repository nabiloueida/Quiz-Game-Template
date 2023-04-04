using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public delegate void CountryDataUpdated();

public enum RelationshipType { Economic, Strategic, Domestic }

[System.Serializable]
public class CountryRelationship
{
    public Country RelatedCountry;
    public RelationshipType RelationshipType;
    public int RelationshipValue;
}

[CreateAssetMenu]
public class Country : ScriptableObject
{
    public CountryDataUpdated DataUpdated;
    public string Name;
    public float GDPInMillions;
    public Sprite Flag;
    public List<CountryRelationship> Relationships;

    public int GetRelationshipValue(string countryName, RelationshipType type)
    {
        List<CountryRelationship> countryFilter =
            Relationships.Where(x => x.RelatedCountry.Name == countryName).ToList();
        List<CountryRelationship> typeFilter =
            countryFilter.Where(x => x.RelationshipType == type).ToList();
        return typeFilter[0].RelationshipValue;
    }

    public void SetRelationshipValue(string countryName, RelationshipType type, 
        int newValue)
    {
        List<CountryRelationship> countryFilter =
            Relationships.Where(x => x.RelatedCountry.Name == countryName).ToList();
        List<CountryRelationship> typeFilter =
            countryFilter.Where(x => x.RelationshipType == type).ToList();
        typeFilter[0].RelationshipValue = newValue;
        DataUpdated?.Invoke();
    }

    // public Country usaCountry
    // ...
    // usaCountry.GetRelationshipValue("Canada", RelationshipType.Economic);
}

