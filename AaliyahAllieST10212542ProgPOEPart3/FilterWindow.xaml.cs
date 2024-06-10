using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class FilterWindow : Window
    {
        // List to store all recipes
        private List<Recipe> allRecipes;

        public FilterWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            allRecipes = recipes;
            PopulateFoodGroupsComboBox();
        }

        private void PopulateFoodGroupsComboBox()
        {
            // Get available food groups from Recipe class
            var foodGroups = Recipe.GetAvailableFoodGroups();

            // Add food group options to the ComboBox
            foreach (var foodGroup in foodGroups)
            {
                cmbFoodGroupFilter.Items.Add(new KeyValuePair<int, string>(foodGroup.Key, foodGroup.Value));
            }
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            // Check if there are recipes available
            if (allRecipes == null || allRecipes.Count == 0)
            {
                MessageBox.Show("There are no recipes to search from.", "No Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Get filter values
            string ingredientFilter = txtIngredientFilter.Text.Trim();
            int selectedFoodGroup = cmbFoodGroupFilter.SelectedIndex + 1; // Index is 0-based, so adding 1 to match food group number
            double maxCalories;

            // Check if max calories input is valid
            if (!double.TryParse(txtMaxCalories.Text.Trim(), out maxCalories))
            {
                MessageBox.Show("Please enter a valid number for maximum calories.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Filter recipes based on the criteria
            List<Recipe> filteredRecipes = allRecipes.Where(recipe =>
            {
                // Check if recipe contains the ingredient (if specified)
                bool containsIngredient = string.IsNullOrWhiteSpace(ingredientFilter) || recipe.Ingredients.Any(ingredient => ingredient.Name.Contains(ingredientFilter, StringComparison.OrdinalIgnoreCase));

                // Check if recipe belongs to the selected food group (if specified)
                bool belongsToFoodGroup = selectedFoodGroup == 0 || recipe.Ingredients.Any(ingredient => ingredient.FoodGroupNumber == selectedFoodGroup);

                // Check if recipe has calories within the specified range (if specified)
                bool withinCaloriesRange = maxCalories <= 0 || recipe.CalculateTotalCalories() <= maxCalories;

                return containsIngredient && belongsToFoodGroup && withinCaloriesRange;
            }).ToList();

            // Display filtered recipes
            DisplayFilteredRecipes(filteredRecipes);
        }


        private void DisplayFilteredRecipes(List<Recipe> recipes)
        {
            // Clear previous items from the list box
            listBoxRecipes.Items.Clear();

            // Add filtered recipe names to the list box
            foreach (var recipe in recipes)
            {
                listBoxRecipes.Items.Add(recipe.RecipeName);
            }
        }
    }
}
