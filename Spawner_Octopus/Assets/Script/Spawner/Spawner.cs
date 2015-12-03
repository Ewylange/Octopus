using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : Action {

  public enum SpawnerType{ PROBABILISTIC, TIMED }
  [HideInInspector] public SpawnerType type = SpawnerType.TIMED;

  [HideInInspector] public GameObject entity;
  [HideInInspector] public int maxInstances = -1;
  [HideInInspector] public int maxInstancesAtOnce = -1;
  private int nbInstancesSpawned = 0;
  [HideInInspector] public float frequency = 1f;

  public enum TimeRelativeTo{ LEVEL_START, SPAWNER_CREATION, SPAWNER_ACTIVATION };
  [HideInInspector] public TimeRelativeTo timesRelativeTo = TimeRelativeTo.LEVEL_START;
  float timeReference = 0;
  [HideInInspector] public float startTime = 0;
  [HideInInspector] public bool hasTimeLimit = false;
  [HideInInspector] public float endTime = 100;

  [System.Serializable]
  public class ProbaStep{
    public float proba = 1;
    public float step = 0;
  }

  public enum ProbaTriggerType{ TIME, SCORE }
  [HideInInspector] public ProbaTriggerType probaStepTrigger;
  [HideInInspector] public List<ProbaStep> spawnProbability = new List<ProbaStep>();

  float timer = 0;
  GameObject entityContainer;
  Score score;
  
  // Use this for initialization
  override protected void Awake () {
    base.Awake();
    entityContainer = new GameObject(name+"-container");
    score = FindObjectOfType<Score>();

    if(timesRelativeTo == TimeRelativeTo.SPAWNER_CREATION)
    {
      timeReference = Time.timeSinceLevelLoad;
    }
  }

  void Start() {
    launch();
  }

  public override void launch ()
  {
    base.launch ();
    timer = frequency; // make sure an entity is spawned when the behaviour is enabled
    nbInstancesSpawned = 0;
    if(timesRelativeTo == TimeRelativeTo.SPAWNER_ACTIVATION)
    {
      timeReference = Time.timeSinceLevelLoad;
    }
  }
  
  // spawn in late Update to wait for position calculations
  void LateUpdate () {

    timer += Time.deltaTime;

    if(type == SpawnerType.TIMED){

      float timeSinceStart = Time.timeSinceLevelLoad - timeReference;
      if(timeSinceStart > startTime && timer > frequency){
        if(hasTimeLimit && timeSinceStart > endTime){
          stop ();
          return;
        }
        timer = 0;
        spawn();
      }
    }else{
      if(timer > frequency){
        int currentProbaIndex = 0;

        switch(probaStepTrigger){
        case ProbaTriggerType.SCORE: currentProbaIndex = getProbaIndexScore(); break;
        case ProbaTriggerType.TIME: currentProbaIndex = getProbaIndexTime() ; break;
        }

        float currentProba = spawnProbability[currentProbaIndex].proba;
        float dice = Random.value;
        if(dice <= currentProba){
          spawn();
        }
        timer = 0;
      }
    }
  }

  int getProbaIndexScore(){
    int step = spawnProbability.Count - 1;
    for (int i = 0; i < spawnProbability.Count; i++)
    {
      if (spawnProbability[i].step > score.score)
      {
        step = i - 1;
        break;
      }
    }
    step = Mathf.Max(step, 0);
    return step;
  }

  int getProbaIndexTime(){
    int step = spawnProbability.Count-1;
    for (int i = 0; i < spawnProbability.Count; i++) {
      if(spawnProbability[i].step > Time.timeSinceLevelLoad){
        step = i-1;
        break;
      }
    }
    step = Mathf.Max(step, 0);
    return step;
  }
  
  void spawn(){

    if(maxInstancesAtOnce > 0 && entityContainer.transform.childCount >= maxInstancesAtOnce)
    {
      return;
    }

    if(nbInstancesSpawned >= maxInstances && maxInstances != -1){
      stop ();
      return;
    }

    GameObject clone = (GameObject)Instantiate(entity);
    clone.transform.position  = transform.position;
    clone.transform.rotation  = transform.rotation;
    clone.transform.parent    = entityContainer.transform;

    nbInstancesSpawned++;
  }

  public override void stop ()
  {
    base.stop ();
    if(entityContainer.GetComponent<DestroyWhenNoChild>() == null) entityContainer.AddComponent<DestroyWhenNoChild>();
    next();
  }

  void OnDestroy() {
    if (entityContainer != null)
    {
      if (entityContainer.GetComponent<DestroyWhenNoChild>() == null) entityContainer.AddComponent<DestroyWhenNoChild>();
    }
  }
}
