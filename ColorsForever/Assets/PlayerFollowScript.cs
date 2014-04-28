using UnityEngine;
using System.Collections;

public class PlayerFollowScript : MonoBehaviour {

	Vector3[] playerLocations;
	float[] playerXPositions;
	GameObject[] players;
	float cameraZ;
	bool newMiddlePlayerFlag;
	int currentMiddlePlayer;
	public float yLift=0;
	public float cameraSwitchSpeed=5;
	public float cameraLockDistance=.2f;
	

	// Use this for initialization
	void Start () {
		playerLocations = new Vector3[3];
		playerXPositions = new float[3];
		players = GameObject.FindGameObjectsWithTag("Player");
		cameraZ = transform.position.z;
	}

	int ReturnMiddlePlayerIndex(){
		float maxPosition = Mathf.Max(Mathf.Max(playerXPositions[0],playerXPositions[1]),playerXPositions[2]);
		int middleIndex;
		if(maxPosition == playerXPositions[0]){ //0 is max
			if(playerXPositions[1]>playerXPositions[2]){
				middleIndex = 1;
			}else 
				middleIndex = 2;
		}else if(maxPosition == playerXPositions[1]){ //1 is max
			if(playerXPositions[0]>playerXPositions[2]){
				middleIndex = 0;
			}else 
				middleIndex = 2;
		}else{ //2 is max
			if(playerXPositions[1]>playerXPositions[0]){
				middleIndex = 1;
			}else 
				middleIndex = 0;
		}

		return middleIndex;
	}

	Vector3 ReturnMiddlePosition(){
		float maxPosition = Mathf.Max(Mathf.Max(playerXPositions[0],playerXPositions[1]),playerXPositions[2]);
		if(maxPosition == playerXPositions[0]){ //0 is max
			if(playerXPositions[1]>playerXPositions[2]){
				return Vector3.Lerp(playerLocations[0],playerLocations[2],.5f);
			}else 
				return Vector3.Lerp(playerLocations[0],playerLocations[1],.5f);
		}else if(maxPosition == playerXPositions[1]){ //1 is max
			if(playerXPositions[0]>playerXPositions[2]){
				return Vector3.Lerp(playerLocations[1],playerLocations[2],.5f);
			}else 
				return Vector3.Lerp(playerLocations[1],playerLocations[0],.5f);
		}else{ //2 is max
			if(playerXPositions[1]>playerXPositions[0]){
				return Vector3.Lerp(playerLocations[2],playerLocations[0],.5f);
			}else 
				return Vector3.Lerp(playerLocations[2],playerLocations[1],.5f);
		}

	}

	// Update is called once per frame
	void Update () {

		for(int i=0;i<players.Length;i++){
			playerLocations[i] = players[i].transform.position;
			playerXPositions[i] = playerLocations[i].x;
		}

		Vector3 middlePosition = ReturnMiddlePosition();
		int middleIndex = ReturnMiddlePlayerIndex();
		if(middleIndex!=currentMiddlePlayer) newMiddlePlayerFlag=true;

		if(newMiddlePlayerFlag){
			/*Vector3 directionTowardsNewMiddlePlayer = new Vector3(playerLocations[currentMiddlePlayer].x-playerLocations[middleIndex].x, 
			                                                      playerLocations[currentMiddlePlayer].y-playerLocations[middleIndex].y,0f);*/
			Vector3 directionTowardsNewMiddlePlayer = new Vector3(middlePosition.x - camera.transform.position.x, 
			                                                      middlePosition.y - camera.transform.position.y,0f);
			directionTowardsNewMiddlePlayer.Normalize();
			camera.transform.Translate(directionTowardsNewMiddlePlayer*Time.deltaTime*cameraSwitchSpeed);

			Vector2 cameraLocation2D = new Vector2(camera.transform.position.x,camera.transform.position.y);
			Vector2 goalLocation2D = new Vector2(middlePosition.x,middlePosition.y);
			float distanceBetweenCameraAndGoal = Vector2.Distance(cameraLocation2D,goalLocation2D);
			if(distanceBetweenCameraAndGoal < cameraLockDistance){
				currentMiddlePlayer = middleIndex;
				newMiddlePlayerFlag=false;
				Debug.Log ("new middlePlayerFlag set to false");
			}
		}else{
			camera.transform.position = new Vector3(middlePosition.x,middlePosition.y+yLift,cameraZ);
		}







	}

		/*

				//checks to see if players are off screen and adjusts FoV accordingly
				if(focus==main && !unhinged /*&& camera.fieldOfView==zoomGoal){
				//Debug.Log ("Ok, what?");
			/*
				int multiplier = 0;
				playerPositions = scene.ReturnTeamLocations();
				foreach(Vector2 posit in playerPositions){
					Vector3 viewportPoint = camera.WorldToViewportPoint(new Vector3(posit.x*Tile.spacing,posit.y*Tile.spacing,0.0f));
					//Debug.Log ("viewportPoint = "+viewportPoint);
					if(!(viewportPoint.z>0 && (viewportPoint.x<1 && viewportPoint.x>0) && (viewportPoint.y<1 && viewportPoint.y>0))){ //not on screen
						multiplier++;
					}
				}
				zoomGoal += .5f*(multiplier);
			}
		}
		*/
}
