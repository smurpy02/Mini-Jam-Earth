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
    public TextMeshProUGUI costText;

    public int blueprintsNeeded;
    public GameObject button;
}

public class BuildStructures : MonoBehaviour
{
    static int _resources = 50;
    static int _blueprints = 0;

    GameObject selectedStructure;
    Transform structureGhost;
    int activeStructure;

    public static int resources { get { return _resources; } set { _resources = value; } }
    public static int blueprints { get { return _blueprints; } set { _blueprints = value; } }
    public bool isBuilding { get { return activeStructure >= 0; } }

    public InputActionReference place;
    public Transform core;
    public TextMeshProUGUI fragmentsText;
    public TextMeshProUGUI blueprintsText;
    public Movement movement;
    public float costMultiplier = 1.5f;

    public List<Structure> structures;

    public AudioSource selectSound;
    public AudioSource placeSound;

    // Update is called once per frame
    void Update()
    {
        movement.moveEnabled = activeStructure == -1;
        //if(!movement.enabled) movement.body.velocity = Vector3.zero;

        foreach( Structure structure in structures)
        {
            structure.costText.text = structure.cost.ToString("0");

            structure.button.SetActive(blueprints >= structure.blueprintsNeeded);
        }

        fragmentsText.text = resources.ToString("0");
        blueprintsText.text = blueprints.ToString("0");

        if (structureGhost != null)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            structureGhost.position = position;
            structureGhost.rotation = Rotations.GetRotation(position, core.position);

            PlaceStructure();
        }
    }

    public void SetStructureNone()
    {
        SetStructure(-1);
    }

    public void SetStructureFromList(int index)
    {
        Structure structure = structures[index];

        if (structure == null)
        {
            return;
        }

        SetStructure(index);
    }

    void SetStructure(int index)
    {
        if (index == -1) { structureGhost.gameObject.SetActive(false);  selectedStructure = null; structureGhost = null; activeStructure = -1; return; }

        selectSound.Play();

        Structure structure = structures[index];

        if (structureGhost !=null ) structureGhost.gameObject.SetActive(false);
        selectedStructure = structure.structure;
        structureGhost = structure.ghost;
        activeStructure = index; ;
        if (structureGhost != null) structureGhost.gameObject.SetActive(true);
    }

    void PlaceStructure()
    {
        bool placeStructure = true;
        placeStructure &= place.action.WasPressedThisFrame();
        placeStructure &= selectedStructure != null;
        placeStructure &= structureGhost.GetComponentInChildren<ValidPlacementCheck>().isValid;
        placeStructure &= structures[activeStructure].cost <= resources;

        if (!placeStructure) return;

        placeSound.Play();

        _resources -= structures[activeStructure].cost;
        structures[activeStructure].cost = (int)((float)structures[activeStructure].cost * costMultiplier);

        Instantiate(selectedStructure, structureGhost.position, structureGhost.rotation, core);
    }
}
