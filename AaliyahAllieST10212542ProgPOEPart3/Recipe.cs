//PROG PART 2
//AALIYAH ALLIE PROG PART 2
//RECIPE.CS PAGE
//THIS PAGE OF CODE CONTAINS MY RECIPE.CS FOR VARIABLES THAT ARE CALLED BY THE RECIPE.CS CLASS
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;
using AaliyahAllieST10212542ProgPOEPart3;

//Namespace defined
namespace AaliyahAllieST10212542ProgPOEPart3
{
    //declaring class as Recipe
    public class Recipe
    {
        // Defining a delegate for notifying about recipe calorie content
        public delegate void RecipeCalorieNotification(string message);

        //property to store recipe name
        public string RecipeName { get; set; }
        //property to store the steps of the recipeI(generic collection)(stores ingredients)
        public ICollection<Ingredient> Ingredients { get; set; }
        //property to store the steps of the recipeI(generic collection)(stores steps)
        public ICollection<string> Steps { get; set; }
        //  a property for calorie notification delegate
        public RecipeCalorieNotification CalorieNotifer { get; set; }
        // Constructor to initialize a Recipe object 
        public Recipe(string recipeName)
        {
            // Assigning the provided recipe name
            RecipeName = recipeName;
            // Initializing the Ingredients collection
            Ingredients = new List<Ingredient>();
            // Initializing the Steps collection
            Steps = new List<string>();
        }

        //method to add ingredients 
        public void AddIngredients(string name, int quantity, string unitOfMeasurement, double calories)
        {
            //interface header for availabe food groups
            Console.WriteLine("Available Food Groups:");
            //displays availabe foodgroups
            DisplayFoodGroupOptions();
            //Interface message to ask user to select a foodgroup from a numeric option
            Console.WriteLine("Enter the number corresponding to the food group this ingredient belongs to:");
            //captures option
            int FoodGroupChoice;
            // Validating user input for food group choice

            if (!int.TryParse(Console.ReadLine(), out FoodGroupChoice) || !AvailableFoodGroups.ContainsKey(FoodGroupChoice))
            {
                //error message for if food group choice is incorrect
                Console.WriteLine("Invalid food group choice. Please select a valid number from the options.");
                return;
            }
            //retrival of food group based on user input
            string foodGroup = AvailableFoodGroups[FoodGroupChoice];
            Ingredients.Add(new Ingredient// Adding a new Ingredient object to the Ingredients collection
            {
                Name = name,// Assigning the name of the ingredient
                Quantity = quantity,// Assigning the quantity of the ingredient
                OriginalQuantity = quantity,// Storing the original quantity for scaling purposes/reset purposes
                UnitOfMeasurement = unitOfMeasurement,// Assigning the unit of measurement for the ingredient
                Calories = calories, // Assigning the calorie content of the ingredient
                OriginalCalories = calories,// Storing the original calorie content for scaling purposes/reset purposes
                FoodGroup = foodGroup,// Assigning the food group of the ingredient
                FoodGroupNumber = FoodGroupChoice// Storing the food group number for reference
            });


        }
        //method to add ste[ps
        public void AddStep(string step)
        {
            //adds steps to step collection
            Steps.Add(step);
        }

        //Method for displaying all the recipes details
        public void DisplayRecipe(bool showAllDetails)
        {
            //setting display colour of recipes details to dark blue
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            //interface header and calling recipes name to display
            Console.WriteLine($"Recipe Name: {RecipeName}");

            //Checking if all details should be displayed
            if (showAllDetails)
            {
                //interface header for display purposes(displays ingredients)
                Console.WriteLine("Ingredients:");
                //for each loop. Iterating through each ingredient
                foreach (var ingredient in Ingredients)
                {
                    //calling recipes details(name,quantity,unit of measurement,food group,calories)
                    Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.UnitOfMeasurement} (Food Group: {ingredient.FoodGroup}, Calories: {ingredient.Calories})");
                }
                //interface header for display purposes(displays steps)
                Console.WriteLine("Steps:");
                //Output the list of steps for the recipe
                int stepNumber = 1;
                foreach (var step in Steps)
                {
                    // Output each step with its corresponding step number
                    Console.WriteLine($"Step {stepNumber}: {step}");
                    stepNumber++;
                }
            }
            else
            {
                // If no steps are recorded, output the count of ingredients and steps
                Console.WriteLine($"Ingredients: {Ingredients.Count} ingredient(s) recorded.");
                Console.WriteLine($"Steps: {Steps.Count} step(s) recorded.");
            }
            // Calculate the total calories of the recipe
            double totalCalories = CalculateTotalCalories();
            //display header and calls total calories from calculation
            Console.Write($"Total Calories: {totalCalories} ");

            // Check if the total calories fall within a healthy range and provide appropriate feedback
            if (totalCalories >= 0 && totalCalories <= 300)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"(Total calories of {RecipeName} are between 0 and 300. This is still in a healthy calorie range.)");
            }
            //If not displays a delegate message
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"(ALERT!!! Calories above 300 may be unhealthy.)");
                // Invoke the calorie notifier delegate if calories exceed 300
                CalorieNotifer?.Invoke($"ALERT!!! The recipe '{RecipeName}' exceeds 300 calories.");
            }
            //reset colour back to default
            Console.ResetColor();
            Console.WriteLine("***********************************************");
        }

        // Method to calculate the total calories of the recipe based on ingredients
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            // Add up the calories of each ingredient
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }
        // Dictionary to store available food groups and their corresponding codes
        public static readonly Dictionary<int, string> AvailableFoodGroups = new Dictionary<int, string>
            {
                { 1, "Starchy foods" },
                { 2, "Vegetables and fruits" },
                { 3, "Dry beans, peas, lentils and soya" },
                { 4, "Chicken, fish, meat and eggs" },
                { 5, "Milk and dairy products" },
                { 6, "Fats and oil" },
                { 7, "Water" }
             };
        // Method to display options for food groups
        public static void DisplayFoodGroupOptions()
        {
            foreach (var foodGroup in AvailableFoodGroups)
            {        // Output each food group with its corresponding code
                Console.WriteLine($"{foodGroup.Key}. {foodGroup.Value}");
            }
        }
        //method to scale recipe by scale factor
        //scales quantity and calories
        public void ScaleRecipe(double factor)
        {
            // Iterate over each ingredient in the recipe
            foreach (var ingredient in Ingredients)
            {
                // Calculate the new quantity based on the scaling factor
                int newQuantity = (int)(ingredient.Quantity * factor);

                // Update the quantity of the ingredient
                ingredient.Quantity = newQuantity;

                // Calculate the new calories based on the scaling factor
                double newCalories = ingredient.Calories * factor;

                // Update the calories of the ingredient
                ingredient.Calories = newCalories;
            }
        }


        // Method to reset recipe back to its original input values
        public void ResetRecipe()
        {
            // Iterate over each ingredient in the recipe
            foreach (var ingredient in Ingredients)
            {
                // Reset the quantity to its original input value
                ingredient.Quantity = ingredient.OriginalQuantity;

                // Reset the calories to its original input value
                ingredient.Calories = ingredient.OriginalCalories;
            }
        }
        public static Dictionary<int, string> GetAvailableFoodGroups()
        {
            return AvailableFoodGroups;
        }



        

    }

}