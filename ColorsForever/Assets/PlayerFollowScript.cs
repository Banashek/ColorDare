using UnityEngine;
using System.Collections;

public class PlayerFollowScript : MonoBehaviour {

	Vector3[] playerLocations;
	GameObject[] players;
	

	// Use this for initialization
	void Start () {
		playerLocations = new Vector3[3];
		players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		for(int i=0;i<players.Length;i++){
			playerLocations[i] = players[i].transform.position;
		}



		/*
			//Get positions of players on team and Lerp halfway to center camera between players, set that as main
			if(scene.CurrentGameState==(int)GameState.States.P1 || scene.CurrentGameState==(int)GameState.States.P2){
				if(scene.ReturnNumberOfLiveCharactersOnCurrentTeam()>1){
					playerPositions = scene.ReturnTeamLocations();
					Vector2 inBetweenPosition = Vector2.Lerp ((Vector2)playerPositions[0],(Vector2)playerPositions[1],.5f);
					main = new Vector3(inBetweenPosition.x*Tile.spacing,inBetweenPosition.y*Tile.spacing,main.z);
				}else if(scene.ReturnNumberOfLiveCharactersOnCurrentTeam()==1){
					playerPositions = scene.ReturnTeamLocations();
					main = new Vector3(playerPositions[0].x*Tile.spacing,playerPositions[0].y*Tile.spacing,main.z);
				}

				if(!unhinged && currentCamera==(int)CameraPositions.main){
					focus = main;
					//zoomGoal = normal;
				}


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
}
