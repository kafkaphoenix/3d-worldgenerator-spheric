using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor {

    Planet planet;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DrawSettingsEditor(planet.shapeSettings, planet.OnShapeSettingsUpdated);
        DrawSettingsEditor(planet.colourSettings, planet.OnColourSettingsUpdated);
    }

    void DrawSettingsEditor(Object settings, System.Action OnSettingUpdated)
    {
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            Editor editor = CreateEditor(settings);
            editor.OnInspectorGUI();

            if (check.changed)
            {
                if (OnSettingUpdated != null)
                {
                    OnSettingUpdated();
                }
            }
        }
    }

    private void OnEnable()
    {
        planet = (Planet)target;
    }
}