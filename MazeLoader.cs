using UnityEngine;
using System.Collections;

public class MazeLoader : MonoBehaviour {
	public int mazeRows=7, mazeColumns=7;
	public GameObject wall;
	public float size = 5.5f;
	public GameObject gameScoreObj;
	public KeepTrackOfLevel levelS;
	public GameObject camera;

	private MazeCell[,] mazeCells;

	public bool isInitialized;

	// Use this for initialization
	void Start ()
	{
		camera = GameObject.FindGameObjectWithTag("Camera");
		
		gameScoreObj = GameObject.FindWithTag("levelCount");
		levelS = gameScoreObj.GetComponent<KeepTrackOfLevel>();

		wall.transform.localScale=new Vector3(6,6,0.6f);
		
		
		
		InitializeMaze ();

		MazeAlgorithm ma = new HuntAndKillMazeAlgorithm (mazeCells);
		ma.CreateMaze ();

		isInitialized = true;
		
		moveCamera();
		
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	void growWithGame()
	{
		/*if (levelS.level / 5 >= 1)*/
		{
			mazeRows += levelS.level / 5;
			mazeColumns += levelS.level / 5;
			size += levelS.level/5/10 ;
			wall.transform.localScale += new Vector3(levelS.level/5/10,0,0);
		}
		
		/*if(levelS.level % 5 == 0)
			camera.transform.position += new Vector3(levelS.level/5,levelS.level/5+1,levelS.level/5+3);*/

	}

	void moveCamera()
	{
		camera.transform.position = GameObject.Find("Floor " + (mazeRows-1)/2 + "," +(mazeColumns-1)/2).transform.position;
		camera.transform.position += new Vector3(0,50+levelS.level/5*5+levelS.level/50*5+levelS.level/2+levelS.level/200*35,0);
		
		if(levelS.level/5%2==1)
			camera.transform.position += new Vector3(2,0,3);
	}
	

	private void InitializeMaze() {
		
		growWithGame();

		mazeCells = new MazeCell[mazeRows,mazeColumns];

		for (int r = 0; r < mazeRows; r++) {
			for (int c = 0; c < mazeColumns; c++) {
				mazeCells [r, c] = new MazeCell ();

				// For now, use the same wall object for the floor!
				mazeCells [r, c] .floor = Instantiate (wall, new Vector3 (r*size, -(size/2f), c*size), Quaternion.identity) as GameObject;
				mazeCells [r, c] .floor.name = "Floor " + r + "," + c;
				mazeCells [r, c] .floor.transform.Rotate (Vector3.right, 90f);

				if (c == 0) {
					mazeCells[r,c].westWall = Instantiate (wall, new Vector3 (r*size, 0, (c*size) - (size/2f)), Quaternion.identity) as GameObject;
					mazeCells [r, c].westWall.name = "West Wall " + r + "," + c;
				}

				mazeCells [r, c].eastWall = Instantiate (wall, new Vector3 (r*size, 0, (c*size) + (size/2f)), Quaternion.identity) as GameObject;
				mazeCells [r, c].eastWall.name = "East Wall " + r + "," + c;

				if (r == 0) {
					mazeCells [r, c].northWall = Instantiate (wall, new Vector3 ((r*size) - (size/2f), 0, c*size), Quaternion.identity) as GameObject;
					mazeCells [r, c].northWall.name = "North Wall " + r + "," + c;
					mazeCells [r, c].northWall.transform.Rotate (Vector3.up * 90f);
				}

				mazeCells[r,c].southWall = Instantiate (wall, new Vector3 ((r*size) + (size/2f), 0, c*size), Quaternion.identity) as GameObject;
				mazeCells [r, c].southWall.name = "South Wall " + r + "," + c;
				mazeCells [r, c].southWall.transform.Rotate (Vector3.up * 90f);
			}
		}
	}
}
