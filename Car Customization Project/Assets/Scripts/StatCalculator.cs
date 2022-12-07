using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatCalculator : MonoBehaviour
{
    //variables for text game objects
    //price display objects
    [SerializeField] private Text priceDisplayText;
    [SerializeField] private Text carPriceText;
    [SerializeField] private Text wheelPriceText;
    [SerializeField] private Text barPriceText;
    //stats display objects
    [SerializeField] private Text speedDisplayText;
    [SerializeField] private Text weightDisplayText;
    [SerializeField] private Text handlingDisplayText;
    //model display objects
    [SerializeField] private Text carModelText;
    [SerializeField] private Text wheelModelText;
    [SerializeField] private Text barModelText;

    //variables for slider game objects
    [SerializeField] private Slider speedSlider;
    [SerializeField] private Slider weightSlider;
    [SerializeField] private Slider handlingSlider;

    //variables for price calculation
    private int totalPrice;
    [HideInInspector] public int currentCarPrice;
    [HideInInspector] public int currentWheelPrice;
    [HideInInspector] public int currentBarPrice;

    //variables for speed calculation
    private int totalSpeed;
    [HideInInspector] public int currentCarSpeed;
    [HideInInspector] public int currentWheelSpeed;
    [HideInInspector] public int currentBarSpeed;

    //variables for weight calculation
    private int totalWeight;
    [HideInInspector] public int currentCarWeight;
    [HideInInspector] public int currentWheelWeight;
    [HideInInspector] public int currentBarWeight;

    //variables for handling calculation
    private int totalHandling;
    [HideInInspector] public int currentCarHandling;
    [HideInInspector] public int currentWheelHandling;
    [HideInInspector] public int currentBarHandling;

    //variables for displaying current model
    [HideInInspector] public string carModel;
    [HideInInspector] public string wheelModel;
    [HideInInspector] public string barModel;

    //function to update all stats
    public void UpdateAllStats()
    {
        //calls all other update functions
        UpdateTotalPrice();
        UpdateTotalSpeed();
        UpdateTotalWeight();
        UpdateTotalHandling();
        UpdateModelNames();
    }

    //function to calculate and update the total price of all currently viewed objects
    private void UpdateTotalPrice()
    {
        //calculates price based on currently selected customizations
        totalPrice = currentCarPrice + currentWheelPrice + currentBarPrice;
        //updates the UI text elements to display new prices
        priceDisplayText.text = "£" + totalPrice;
        carPriceText.text = "Car cost: £" + currentCarPrice;
        wheelPriceText.text = "Tire cost: £" + currentWheelPrice;
        barPriceText.text = "Bar cost: £" + currentBarPrice;
    }

    //function to calculate and update the total speed of all currently viewed objects
    private void UpdateTotalSpeed()
    {
        //calculates price based on currently selected customizations
        totalSpeed = currentCarSpeed + currentWheelSpeed + currentBarSpeed;
        //updates the UI text element to display new speed
        speedDisplayText.text = "Speed: " + totalSpeed;
        //updates the UI slider element to display the speed
        speedSlider.value = totalSpeed;
    }

    //function to calculate and update the total weight of all currently viewed objects
    private void UpdateTotalWeight()
    {
        //calculates price based on currently selected customizations
        totalWeight = currentCarWeight + currentWheelWeight + currentBarWeight;
        //updates the UI text element to display new speed
        weightDisplayText.text = "Weight: " + totalWeight;
        //updates the UI slider element to display the speed
        weightSlider.value = totalWeight;
    }

    //function to calculate and update the total handling of all currently viewed objects
    private void UpdateTotalHandling()
    {
        //calculates price based on currently selected customizations
        totalHandling = currentCarHandling + currentWheelHandling + currentBarHandling;
        //updates the UI text element to display new speed
        handlingDisplayText.text = "Handling: " + totalHandling;
        //updates the UI slider element to display the speed
        handlingSlider.value = totalHandling;
    }

    //function to update the display to show which models are currently being viewed
    private void UpdateModelNames()
    {
        carModelText.text = "Car Model: " + carModel;
        wheelModelText.text = "Tire Model: " + wheelModel;
        barModelText.text = "Bar Model: " + barModel;
    }
}
