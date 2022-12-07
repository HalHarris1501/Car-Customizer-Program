using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    //variables for other game objects
    [SerializeField] private StatCalculator statCalculator;

    //arrays to store different game objects
    [SerializeField] private GameObject[] cars = new GameObject[5];
    [SerializeField] private GameObject[] leftTires = new GameObject[6];
    [SerializeField] private GameObject[] rightTires = new GameObject[6];
    [SerializeField] private GameObject[] frontBars = new GameObject[5];

    //variables to store current game objects being displayed
    private GameObject currentCar;
    private GameObject[] currentTires = new GameObject[4];
    private GameObject currentFrontBar;

    //variables to store spawnpoints for objects
    [SerializeField] private GameObject carSpawnPoint;
    private GameObject[] tiresSpawnPoints = new GameObject[4];
    private GameObject frontBarSpawnPoint;

    //variables to store the index for the current tire and bar types
    private int currentTiresIndex;
    private int currentFrontBarIndex;

    // Start is called before the first frame update
    void Start()
    {
        //sets all car parts to defualt
        SetCurrentCar(0);
        SetCurrentTires(0);
        SetCurrentFrontBar(-1);
    }

    //function to set the current car model
    private void SetCurrentCar(int carModelSelected)
    {
        //destroys the current car object, if there is one
        if (currentCar != null)
        {
            Destroy(currentCar);
        }

        //instantiates the selected car model
        currentCar = Instantiate(cars[carModelSelected], carSpawnPoint.transform);

        //sets the spawnpoint for the tires and bar to be the spawnpoints for the current car
        frontBarSpawnPoint = currentCar.transform.GetChild(0).gameObject;
        for(int i = 1; i < 5; i++)
        {
            tiresSpawnPoints[i - 1] = currentCar.transform.GetChild(i).gameObject;
        }

        //replaces the current tires and bar, if they have been selected yet
        if(currentTiresIndex != null)
        {
            SetCurrentTires(currentTiresIndex);
        }

        if(currentFrontBarIndex != null)
        {
            SetCurrentFrontBar(currentFrontBarIndex);
        }

        //changes the stats to the stats of the current car and calls the UpdateAllStatsfunction
        statCalculator.currentCarPrice = cars[carModelSelected].GetComponent<CustomizationItem>().price;
        statCalculator.currentCarSpeed = cars[carModelSelected].GetComponent<CustomizationItem>().speed;
        statCalculator.currentCarWeight = cars[carModelSelected].GetComponent<CustomizationItem>().weight;
        statCalculator.currentCarHandling = cars[carModelSelected].GetComponent<CustomizationItem>().handling;
        statCalculator.carModel = cars[carModelSelected].name;
        statCalculator.UpdateAllStats();
    }

    //function to set the current tires on the car
    private void SetCurrentTires(int tireModelSelected)
    {
        //sets the current tires index to the same as the model just selected
        currentTiresIndex = tireModelSelected;

        //changes the game object of the tires to the newly selected ones
        for (int i = 0; i < 4; i++)
        {
            //destroys the current tire object, if there is one
            if (currentTires[i] != null)
            {
                Destroy(currentTires[i]);
            }

            //checks if the tire to replace is a left tire or a right tire
            if (i < 2)
            {
                //changes the left tire objects to the newly selected ones
                currentTires[i] = Instantiate(leftTires[tireModelSelected], tiresSpawnPoints[i].transform);
            }
            else
            {
                //changes the right tire objects to the newly selected ones
                currentTires[i] = Instantiate(rightTires[tireModelSelected], tiresSpawnPoints[i].transform);
            }
        }

        //changes the stats to the stats of the current tires and calls the UpdateAllStatsfunction
        statCalculator.currentWheelPrice = leftTires[tireModelSelected].GetComponent<CustomizationItem>().price;
        statCalculator.currentWheelSpeed = leftTires[tireModelSelected].GetComponent<CustomizationItem>().speed;
        statCalculator.currentWheelWeight = leftTires[tireModelSelected].GetComponent<CustomizationItem>().weight;
        statCalculator.currentWheelHandling = leftTires[tireModelSelected].GetComponent<CustomizationItem>().handling;
        statCalculator.wheelModel = leftTires[tireModelSelected].name;
        statCalculator.UpdateAllStats();
    }

    //function to set the current front bar on the car
    private void SetCurrentFrontBar(int barModelSelected)
    {
        //destroys the current bar object, if there is one
        if (currentFrontBar != null)
        {
            Destroy(currentFrontBar);
        }
        //sets the current front bar index to the same as the model just selected
        currentFrontBarIndex = barModelSelected;
        if (barModelSelected == -1)
        {
            statCalculator.currentBarPrice = 0;
            statCalculator.currentBarSpeed = 0;
            statCalculator.currentBarWeight = 0;
            statCalculator.currentBarHandling = 0;
            statCalculator.barModel = "None";
        }
        else
        {
            //changes the game object of the front bar to the newly selected one
            currentFrontBar = Instantiate(frontBars[barModelSelected], frontBarSpawnPoint.transform);

            //changes the stats to the stats of the current bar and calls the UpdateAllStatsfunction
            statCalculator.currentBarPrice = frontBars[barModelSelected].GetComponent<CustomizationItem>().price;
            statCalculator.currentBarSpeed = frontBars[barModelSelected].GetComponent<CustomizationItem>().speed;
            statCalculator.currentBarWeight = frontBars[barModelSelected].GetComponent<CustomizationItem>().weight;
            statCalculator.currentBarHandling = frontBars[barModelSelected].GetComponent<CustomizationItem>().handling;
            statCalculator.barModel = frontBars[barModelSelected].name;
        }
        statCalculator.UpdateAllStats();
    }
}
