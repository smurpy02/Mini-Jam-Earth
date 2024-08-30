using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

[Serializable]
public class Structure
{
    public GameObject structure;
    public Transform ghost;
}

public class BuildStructures : MonoBehaviour
{
    int _resources = 100;
    GameObject selectedStructure;
    Transform structureGhost;

    public int resources { get { return _resources; } }

    public InputActionReference place;
    public Transform core;

    public List<Structure> structures;

    // Update is called once per frame
    void Update()
    {
        if(structureGhost != null)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            Vector3 corePosition = core.position;
            corePosition.z = 0;

            var dir = corePosition - position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            structureGhost.position = position;
            structureGhost.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (place.action.WasPressedThisFrame() && selectedStructure != null)
            {
                Instantiate(selectedStructure, structureGhost.position, structureGhost.rotation, core);
            }
        }
    }

    public void SetStructureFromList(int index)
    {
        Structure structure = structures[index];

        if(structure == null)
        {
            return;
        }

        SetStructure(structure.structure, structure.ghost);
    }

    void SetStructure(GameObject structure, Transform ghost)
    {
        if(structure != null && ghost != null)
        {
            selectedStructure = structure;
            structureGhost = ghost;
        }
    }
}
