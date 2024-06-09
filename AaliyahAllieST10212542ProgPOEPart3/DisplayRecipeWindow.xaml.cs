using AaliyahAllieST10212542ProgPOEPart3;
using System.Windows;

namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class DisplayRecipeWindow : Window
    {
        public DisplayRecipeWindow()
        {
            InitializeComponent();
        }

        // Method to display the recipe details in the TextBox
        public void DisplayRecipeDetails(Recipe recipe)
        {
            // Construct the recipe details string
            string recipeDetails = $"Recipe Name: {recipe.RecipeName}\n\nIngredients:\n";
            foreach (var ingredient in recipe.Ingredients)
            {
                recipeDetails += $"{ingredient.Name}: {ingredient.Quantity} {ingredient.UnitOfMeasurement} (Food Group: {ingredient.FoodGroup}, Calories: {ingredient.Calories})\n";
            }
            recipeDetails += "\nSteps:\n";
            int stepNumber = 1;
            foreach (var step in recipe.Steps)
            {
                recipeDetails += $"Step {stepNumber}: {step}\n";
                stepNumber++;
            }

            // Calculate the total calories of the recipe
            double totalCalories = recipe.CalculateTotalCalories();
            recipeDetails += $"\nTotal Calories: {totalCalories} ";

            // Check if the total calories fall within a healthy range and provide appropriate feedback
            if (totalCalories >= 0 && totalCalories <= 300)
            {
                recipeDetails += $"(Total calories of {recipe.RecipeName} are between 0 and 300. This is still in a healthy calorie range.)";
            }
            else
            {
                recipeDetails += $"(ALERT!!! Calories above 300 may be unhealthy.)";
            }

            // Display the recipe details in the TextBox
            RecipeDetailsTextBox.Text = recipeDetails;
        }
    }
}
