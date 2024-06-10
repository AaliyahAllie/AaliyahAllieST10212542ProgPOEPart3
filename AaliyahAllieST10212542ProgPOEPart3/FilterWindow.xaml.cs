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
            // Get filter values
            string ingredientFilter = txtIngredientFilter.Text.Trim();
            int selectedFoodGroup = cmbFoodGroupFilter.SelectedIndex + 1; // Index is 0-based, so adding 1 to match food group number
            double maxCalories = double.Parse(txtMaxCalories.Text.Trim());

            // Check if any filter is applied
            bool filtersApplied = !string.IsNullOrWhiteSpace(ingredientFilter) ||
                                  selectedFoodGroup != 0 ||
                                  maxCalories > 0;

            // Display notification based on whether filters are applied
            if (filtersApplied)
            {
                MessageBox.Show("Filters have been applied.", "Filter Applied", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No filters have been applied.", "No Filter Applied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // Filter recipes based on the criteria and display them
            DisplayFilteredRecipes();
        }

        private void DisplayFilteredRecipes()
        {
            // Filter recipes based on the applied filters
            List<Recipe> filteredRecipes = allRecipes.Where(recipe =>
            {
                // Check if recipe contains the ingredient filter
                bool containsIngredient = string.IsNullOrWhiteSpace(txtIngredientFilter.Text) ||
                                          recipe.Ingredients.Any(ingredient => ingredient.Name.Contains(txtIngredientFilter.Text, StringComparison.OrdinalIgnoreCase));

                // Check if recipe belongs to the selected food group
                bool belongsToFoodGroup = cmbFoodGroupFilter.SelectedIndex == -1 ||
                                          recipe.Ingredients.Any(ingredient => ingredient.FoodGroupNumber == (int)((KeyValuePair<int, string>)cmbFoodGroupFilter.SelectedItem).Key);

                // Check if recipe has calories within the specified range
                bool withinCaloriesRange = string.IsNullOrWhiteSpace(txtMaxCalories.Text) ||
                                           recipe.CalculateTotalCalories() <= double.Parse(txtMaxCalories.Text);

                return containsIngredient || belongsToFoodGroup || withinCaloriesRange;
            }).ToList();

            // Display filtered recipes
            foreach (var recipe in filteredRecipes)
            {
                // Instead of directly displaying, you can store them or use as needed.
                // Here, I'm just showing the name of each recipe.
                MessageBox.Show(recipe.RecipeName, "Filtered Recipe", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Display_Click(object sender, RoutedEventArgs e)
        {
            // Display filtered recipes
            DisplayFilteredRecipes();
        }
    }
}
