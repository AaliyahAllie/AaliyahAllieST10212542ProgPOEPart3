using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class FilterWindow : Window
    {
        // List to store all recipes
        private List<Recipe> Recipes;

        public FilterWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            Recipes = recipes;
            PopulateFoodGroupsComboBox();
        }

        private void PopulateFoodGroupsComboBox()
        {
            // Add a default option
            cmbFoodGroupFilter.Items.Add(new KeyValuePair<int, string>(0, "All Food Groups"));

            // Get available food groups from Recipe class
            var foodGroups = Recipe.GetAvailableFoodGroups();

            // Add food group options to the ComboBox
            foreach (var foodGroup in foodGroups)
            {
                cmbFoodGroupFilter.Items.Add(new KeyValuePair<int, string>(foodGroup.Key, foodGroup.Value));
            }

            // Set the default selected item
            cmbFoodGroupFilter.SelectedIndex = 0;
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            // Check if there are recipes available
            if (Recipes == null || Recipes.Count == 0)
            {
                MessageBox.Show("There are no recipes to search from.", "No Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Get filter values
            string ingredientFilter = txtIngredientFilter.Text.Trim();
            double maxCalories;

            // Check if max calories input is valid
            if (!double.TryParse(txtMaxCalories.Text.Trim(), out maxCalories))
            {
                MessageBox.Show("Please enter a valid number for maximum calories.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Filter recipes based on the criteria
            List<Recipe> filteredRecipes;

            // Check if all food groups are selected
            if (cmbFoodGroupFilter.SelectedIndex == 0)
            {
                // Display all recipe names
                string allRecipeNames = string.Join(Environment.NewLine, Recipes.Select(recipe => recipe.RecipeName));
                MessageBox.Show($"All Recipes:{Environment.NewLine}{allRecipeNames}", "All Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                // Get the selected food group
                int selectedFoodGroup = ((KeyValuePair<int, string>)cmbFoodGroupFilter.SelectedItem).Key;

                // Filter recipes based on selected food group and other criteria
                filteredRecipes = Recipes.Where(recipe =>
                {
                    // Check if recipe contains the ingredient (if specified)
                    bool containsIngredient = string.IsNullOrWhiteSpace(ingredientFilter) || recipe.Ingredients.Any(ingredient => ingredient.Name.Contains(ingredientFilter, StringComparison.OrdinalIgnoreCase));

                    // Check if recipe belongs to the selected food group
                    bool belongsToFoodGroup = recipe.Ingredients.Any(ingredient => ingredient.FoodGroupNumber == selectedFoodGroup);

                    // Check if recipe has calories within the specified range (if specified)
                    bool withinCaloriesRange = maxCalories <= 0 || (recipe.CalculateTotalCalories() <= maxCalories && recipe.CalculateTotalCalories() >= 0);

                    return containsIngredient && belongsToFoodGroup && withinCaloriesRange;
                }).ToList();

            }

            // Display the names of filtered recipes
            if (filteredRecipes.Count > 0)
            {
                string recipeNames = string.Join(Environment.NewLine, filteredRecipes.Select(recipe => recipe.RecipeName));
                MessageBox.Show($"Matching Recipes:{Environment.NewLine}{recipeNames}", "Filtered Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No recipes match the entered filters.", "No Matches", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


    }
}
