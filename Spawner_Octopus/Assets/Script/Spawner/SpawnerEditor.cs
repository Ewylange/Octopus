using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor{

  private bool probaEditionUnfold = false;

  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();

    Spawner s = target as Spawner;
        
    s.entity = EditorGUILayout.ObjectField("Entity", s.entity, typeof (GameObject), true) as GameObject;

    EditorGUILayout.BeginHorizontal();
      s.maxInstances = EditorGUILayout.IntField("Max Entities Nb", s.maxInstances);
      EditorGUILayout.Space();
      if (EditorGUILayout.Toggle("no limit", s.maxInstances == -1)) s.maxInstances = -1;
    EditorGUILayout.EndHorizontal();
    s.maxInstancesAtOnce = EditorGUILayout.IntField("Nb Entities allowed at same time", s.maxInstancesAtOnce);
    s.frequency = EditorGUILayout.FloatField("Frequency", s.frequency);

    s.type = (Spawner.SpawnerType)EditorGUILayout.EnumPopup("Spawn Type", s.type);
    if (s.type == Spawner.SpawnerType.TIMED)
    {
      s.timesRelativeTo = (Spawner.TimeRelativeTo)EditorGUILayout.EnumPopup("Start Time Reference", s.timesRelativeTo);
      s.startTime = EditorGUILayout.FloatField("Start Time", s.startTime);
      s.hasTimeLimit = EditorGUILayout.Toggle("Has Time Limit", s.hasTimeLimit);
      if(s.hasTimeLimit) s.endTime = EditorGUILayout.FloatField("End Time", s.endTime);
    }else if (s.type == Spawner.SpawnerType.PROBABILISTIC)
    {
      s.probaStepTrigger = (Spawner.ProbaTriggerType)EditorGUILayout.EnumPopup("Difficulty Trigger Type", s.probaStepTrigger);
      probaEditionUnfold = EditorGUILayout.Foldout(probaEditionUnfold, "Edit Difficulty Steps");
      if (probaEditionUnfold)
      {
        foreach (Spawner.ProbaStep probaStep in s.spawnProbability.ToArray())
        {
          EditorGUILayout.BeginHorizontal();
          EditorGUILayout.LabelField(s.probaStepTrigger.ToString() + "STAMP TRIGGER", GUILayout.MaxWidth(150));
          probaStep.step = EditorGUILayout.FloatField(probaStep.step, GUILayout.MaxWidth(100));
          GUILayout.FlexibleSpace();
          EditorGUILayout.LabelField("Proba", GUILayout.MaxWidth(50));
          probaStep.proba = EditorGUILayout.FloatField(probaStep.proba, GUILayout.MaxWidth(100));
          if (GUILayout.Button("del",GUILayout.ExpandWidth(true)))
          {
            s.spawnProbability.Remove(probaStep);
          }
          GUILayout.FlexibleSpace();
          EditorGUILayout.EndHorizontal();
        }
        if (GUILayout.Button("Add Step"))
        {
          s.spawnProbability.Add(new Spawner.ProbaStep());
        }  
      }
    }



    // show indicator of selection in action chain window
    Action a = target as Action;
    if (a.selected)
    {
      GUIStyle st = GUI.skin.label;
      st.normal.textColor = Color.green;
      EditorGUILayout.LabelField("CURRENT SELECTION", st);
    }

    if(GUI.changed){
      EditorUtility.SetDirty(target);
    }
  }
}
