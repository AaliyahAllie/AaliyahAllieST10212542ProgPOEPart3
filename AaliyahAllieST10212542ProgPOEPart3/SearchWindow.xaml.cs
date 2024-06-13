using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

//This code will search for a recipe based on if it has a certain ingredient, food group and max calorie
//This is a new feature i have added to my program
namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();

            // Populate the food group combobox when the window is initialized
            PopulateFoodGroupComboBox();
        }

        // Method to populate the food group combobox
        private void PopulateFoodGroupComboBox()
        {
            var foodGroups = Recipe.GetAvailableFoodGroups();

            // Add each food group as an item to the combobox
            foreach (var foodGroup in foodGroups)
            {
                SearchFoodGroupComboBox.Items.Add(new ComboBoxItem { Content = foodGroup.Value });
            }
        }

        // Event handler for the Search button click
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve search criteria from text boxes and combobox
            string searchIngredient = SearchIngredientTextBox.Text.ToLower();
            string searchFoodGroup = ((ComboBoxItem)SearchFoodGroupComboBox.SelectedItem)?.Content.ToString();

            // Parse and validate maximum calories input
            if (!double.TryParse(MaxCaloriesTextBox.Text, out double maxCalories))
            {
                MessageBox.Show("Please enter a valid number for max calories.");
                return;
            }

            // Filter recipes based on search criteria
            var filteredRecipes = MainWindow.Recipes.Where(recipe =>
                recipe.Ingredients.Any(ingredient =>
                    ingredient.Name.ToLower().Contains(searchIngredient) &&
                    (string.IsNullOrEmpty(searchFoodGroup) || ingredient.FoodGroup == searchFoodGroup) &&
                    recipe.CalculateTotalCalories() <= maxCalories)).ToList();

            // Clear previous search results
            SearchResultsListBox.Items.Clear();

            // Display filtered recipes or a message if none found
            foreach (var recipe in filteredRecipes)
            {
                SearchResultsListBox.Items.Add(FormatRecipeDetails(recipe));
            }

            if (filteredRecipes.Count == 0)
            {
                SearchResultsListBox.Items.Add("No recipes found matching the search criteria.");
            }
        }

        // Format recipe details for display
        private string FormatRecipeDetails(Recipe recipe)
        {
            var recipeDetails = new System.Text.StringBuilder();

            // Append recipe name
            recipeDetails.AppendLine($"Recipe Name: {recipe.RecipeName}");
            recipeDetails.AppendLine("Ingredients:");

            // Append each ingredient with details
            foreach (var ingredient in recipe.Ingredients)
            {
                recipeDetails.AppendLine($"- {ingredient.Name}: {ingredient.Quantity} {ingredient.UnitOfMeasurement} (Food Group: {ingredient.FoodGroup}, Calories: {ingredient.Calories})");
            }

            // Append recipe steps
            recipeDetails.AppendLine("Steps:");
            int stepNumber = 1;
            foreach (var step in recipe.Steps)
            {
                recipeDetails.AppendLine($"Step {stepNumber}: {step}");
                stepNumber++;
            }

            // Append total calories of the recipe
            recipeDetails.AppendLine($"Total Calories: {recipe.CalculateTotalCalories()}");

            return recipeDetails.ToString();
        }
    }
}
