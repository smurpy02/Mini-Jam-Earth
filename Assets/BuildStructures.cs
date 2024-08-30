using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

[Serializable]
public class Structure
{
    public GameObject structure;
    public Transform ghost;
    public int cost;
}

public class BuildStructures : MonoBehaviour
{
    int _resources = 100;
    GameObject selectedStructure;
    Transform structureGhost;
    Structure activeStructure;

    public int resources { get { return _resources; } }

    public InputActionReference place;
    public Transform core;
    public TextMeshProUGUI fragments;

    public List<Structure> structures;

    // Update is called once per frame
    void Update()
    {
        fragments.text = "Fragments: " + resources;

        if (structureGhost != null)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            Vector3 corePosition = core.position;
            corePosition.z = 0;

            var dir = corePosition - position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            structureGhost.position = position;
            structureGhost.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            PlaceStructure();
        }
    }

    public void SetStructureNone()
    {
        SetStructure(null);
    }

    public void SetStructureFromList(int index)
    {
        Structure structure = structures[index];

        if (structure == null)
        {
            return;
        }

        SetStructure(structure);
    }

    void SetStructure(Structure structure)
    {
        if (structureGhost !=null ) structureGhost.gameObject.SetActive(false);
        selectedStructure = structure.structure;
        structureGhost = structure.ghost;
        activeStructure = structure;
        if (structureGhost != null) structureGhost.gameObject.SetActive(true);
    }

    void PlaceStructure()
    {
        bool placeStructure = true;
        placeStructure &= place.action.WasPressedThisFrame();
        placeStructure &= selectedStructure != null;
        placeStructure &= structureGhost.GetComponentInChildren<ValidPlacementCheck>().isValid;
        placeStructure &= activeStructure.cost <= resources;

        if (!placeStructure) return;

        _resources -= activeStructure.cost;

        Instantiate(selectedStructure, structureGhost.position, structureGhost.rotation, core);
    }
}
