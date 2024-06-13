using System.Collections.Generic;  // Importing the namespace for List<>
using System.Windows;               // Importing the namespace for Window and MessageBox
using System.Windows.Controls;      // Importing the namespace for ComboBox
using AaliyahAllieST10212542ProgPOEPart3;  // Importing the custom namespace for Recipe class


//This code resets the values back to its original within a recipe
namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class ResetWindow : Window
    {
        private List<Recipe> _recipes;  // Private field to store the list of recipes

        public ResetWindow(List<Recipe> recipes)
        {
            InitializeComponent();   // Initializing the window components
            _recipes = recipes;       // Assigning the provided list of recipes to the private field
            PopulateRecipeNames();    // Calling a method to populate recipe names in the ComboBox
        }

        private void PopulateRecipeNames()
        {
            // Clear existing items in the ComboBox
            RecipeComboBox.Items.Clear();

            // Populate the ComboBox with recipe names from the list
            foreach (var recipe in _recipes)
            {
                RecipeComboBox.Items.Add(recipe.RecipeName);  // Adding each recipe's name to the ComboBox
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeComboBox.SelectedItem is string selectedRecipeName)
            {
                // Find the recipe object based on the selected recipe name
                Recipe selectedRecipe = _recipes.Find(recipe => recipe.RecipeName == selectedRecipeName);
                if (selectedRecipe != null)
                {
                    // Reset the selected recipe
                    selectedRecipe.ResetRecipe();  // Calling a method to reset the recipe
                    MessageBox.Show($"Recipe '{selectedRecipeName}' has been reset.");  // Showing a message box with the reset confirmation
                    this.Close();  // Closing the window after the reset operation
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to reset.");  // Showing an error message if no recipe is selected
            }
        }
    }
}
