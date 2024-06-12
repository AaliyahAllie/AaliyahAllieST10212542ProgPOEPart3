using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
            PopulateFoodGroupComboBox();
        }

        private void PopulateFoodGroupComboBox()
        {
            var foodGroups = Recipe.GetAvailableFoodGroups();
            foreach (var foodGroup in foodGroups)
            {
                SearchFoodGroupComboBox.Items.Add(new ComboBoxItem { Content = foodGroup.Value });
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchIngredient = SearchIngredientTextBox.Text.ToLower();
            string searchFoodGroup = ((ComboBoxItem)SearchFoodGroupComboBox.SelectedItem)?.Content.ToString();
            if (!double.TryParse(MaxCaloriesTextBox.Text, out double maxCalories))
            {
                MessageBox.Show("Please enter a valid number for max calories.");
                return;
            }

            var filteredRecipes = MainWindow.Recipes.Where(recipe =>
                recipe.Ingredients.Any(ingredient =>
                    ingredient.Name.ToLower().Contains(searchIngredient) &&
                    (string.IsNullOrEmpty(searchFoodGroup) || ingredient.FoodGroup == searchFoodGroup) &&
                    recipe.CalculateTotalCalories() <= maxCalories)).ToList();

            SearchResultsListBox.Items.Clear();
            foreach (var recipe in filteredRecipes)
            {
                SearchResultsListBox.Items.Add(FormatRecipeDetails(recipe));
            }

            if (filteredRecipes.Count == 0)
            {
                SearchResultsListBox.Items.Add("No recipes found matching the search criteria.");
            }
        }

        private string FormatRecipeDetails(Recipe recipe)
        {
            var recipeDetails = new System.Text.StringBuilder();
            recipeDetails.AppendLine($"Recipe Name: {recipe.RecipeName}");
            recipeDetails.AppendLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                recipeDetails.AppendLine($"- {ingredient.Name}: {ingredient.Quantity} {ingredient.UnitOfMeasurement} (Food Group: {ingredient.FoodGroup}, Calories: {ingredient.Calories})");
            }
            recipeDetails.AppendLine("Steps:");
            int stepNumber = 1;
            foreach (var step in recipe.Steps)
            {
                recipeDetails.AppendLine($"Step {stepNumber}: {step}");
                stepNumber++;
            }
            recipeDetails.AppendLine($"Total Calories: {recipe.CalculateTotalCalories()}");

            return recipeDetails.ToString();
        }
    }
}
