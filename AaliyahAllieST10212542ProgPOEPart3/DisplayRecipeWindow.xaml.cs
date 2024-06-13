// Import necessary libraries for WPF application
using AaliyahAllieST10212542ProgPOEPart3;
using System.Windows;

namespace AaliyahAllieST10212542ProgPOEPart3
{
    // Class for displaying recipe details in a WPF window
    public partial class DisplayRecipeWindow : Window
    {
        // Constructor to initialize the window components
        public DisplayRecipeWindow()
        {
            InitializeComponent();
        }

        // Method to display detailed information about a recipe in a TextBox
        public void DisplayRecipeDetails(Recipe recipe)
        {
            // Construct a string containing the recipe name and its ingredients
            string recipeDetails = $"Recipe Name: {recipe.RecipeName}\n\nIngredients:\n";

            // Iterate through each ingredient in the recipe and append its details to the recipeDetails string
            foreach (var ingredient in recipe.Ingredients)
            {
                recipeDetails += $"{ingredient.Name}: {ingredient.Quantity} {ingredient.UnitOfMeasurement} (Food Group: {ingredient.FoodGroup}, Calories: {ingredient.Calories})\n";
            }

            // Append the recipe steps to the recipeDetails string
            recipeDetails += "\nSteps:\n";
            int stepNumber = 1;
            foreach (var step in recipe.Steps)
            {
                recipeDetails += $"Step {stepNumber}: {step}\n";
                stepNumber++;
            }

            // Calculate the total calories of the recipe
            double totalCalories = recipe.CalculateTotalCalories();

            // Append the total calories to the recipeDetails string
            recipeDetails += $"\nTotal Calories: {totalCalories} ";

            // Provide feedback based on the total calorie count
            if (totalCalories >= 0 && totalCalories <= 300)
            {
                recipeDetails += $"(Total calories of {recipe.RecipeName} are between 0 and 300. This is still in a healthy calorie range.)";
            }
            else
            {
                recipeDetails += $"(ALERT!!! Calories above 300 may be unhealthy.)";
            }

            // Display the constructed recipe details in the TextBox named RecipeDetailsTextBox
            RecipeDetailsTextBox.Text = recipeDetails;
        }
    }
}
