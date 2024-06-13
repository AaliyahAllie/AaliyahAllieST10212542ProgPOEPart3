using AaliyahAllieST10212542ProgPOEPart3;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
//This file contains the code for part 3 of my poe
//this is the code behind the clear recipe window and helps it execute its functions
//it works in the following way
//Retrieves the selected recipe name from the ComboBox.
//Searches for the corresponding recipe object in the recipes list.
//Removes the recipe from the list if found and displays a success message.
//Displays a warning message if no recipe is selected.
//Closes the window after the operation is complete.
namespace AaliyahAllieST10212542ProgPOEPart3
{
    // Define a window for clearing recipes
    public partial class ClearRecipeWindow : Window
    {
        //calls on the recipe list where the recipes are stored
        private List<Recipe> recipes;

        // Constructor to initialize the window with a list of recipes
        public ClearRecipeWindow(List<Recipe> recipes)
        {
            // Initialize the components of the window
            InitializeComponent();
            // Assign the provided list of recipes to the local variable
            this.recipes = recipes;

            // Populate the ComboBox with recipe names
            foreach (Recipe recipe in recipes)
            {
                // Populate the ComboBox with names of available recipes from the Recipe.cs file where recipes are stored
                RecipeComboBox.Items.Add(recipe.RecipeName);
            }
        }

        // Event handler for when the Clear Recipe button is clicked
        private void ClearRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected recipe name
            string selectedRecipeName = RecipeComboBox.SelectedItem as string;

            // Find the recipe in the list
            Recipe recipeToRemove = recipes.FirstOrDefault(r => r.RecipeName == selectedRecipeName);

            // Remove the recipe if found
            if (recipeToRemove != null)
            {
                //if recipe is cleared will display a message to say that it is cleared
                recipes.Remove(recipeToRemove);
                MessageBox.Show($"Recipe '{selectedRecipeName}' has been cleared.", "Clear Recipe", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                //if there is no selected recipe it will ask them to select a recipe
                MessageBox.Show("Please select a recipe to clear.", "Clear Recipe", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // Close the window after clearing the recipe
            this.Close();
        }
    }
}
