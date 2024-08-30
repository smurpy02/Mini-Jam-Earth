using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class  Rotations
{
    public static Quaternion GetRotation(Vector3 target, Vector3 lookAt)
    {
        target.z = 0; lookAt.z = 0;
        var dir = lookAt - target;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

[Serializable]
public class Structure
{
    public GameObject structure;
    public Transform ghost;
    public int cost;
}

public class BuildStructures : MonoBehaviour
{
    static int _resources = 50;
    GameObject selectedStructure;
    Transform structureGhost;
    Structure activeStructure;

    public static int resources { get { return _resources; } set { _resources = value; } }

    public InputActionReference place;
    public Transform core;
    public TextMeshProUGUI fragments;
    public Movement movement;

    public List<Structure> structures;

    // Update is called once per frame
    void Update()
    {
        movement.enabled = activeStructure == null;
        if(!movement.enabled) movement.body.velocity = Vector3.zero;

        fragments.text = "Fragments: " + resources;

        if (structureGhost != null)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            //Vector3 corePosition = core.position;
            //corePosition.z = 0;

            //var dir = corePosition - position;
            //var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            structureGhost.position = position;
            structureGhost.rotation = Rotations.GetRotation(position, core.position);//Quaternion.AngleAxis(angle, Vector3.forward);

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
        if (structure == null) { selectedStructure = null; structureGhost = null; activeStructure = null; return; }

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
