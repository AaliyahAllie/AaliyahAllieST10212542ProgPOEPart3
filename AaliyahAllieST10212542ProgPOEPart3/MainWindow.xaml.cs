using System.Collections.Generic;
using System.Windows;
using AaliyahAllieST10212542ProgPOEPart3;

namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class MainWindow : Window
    {
        // Use the same variable name for consistency
        public static List<Recipe> Recipes = new List<Recipe>();
        private List<Recipe> listOfRecipes;

        public MainWindow()
        {
            InitializeComponent();
            // Use the same variable name for consistency
            Recipes = new List<Recipe>();
            listOfRecipes = new List<Recipe>();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Add_Recipe_Click(object sender, RoutedEventArgs e)
        {
            RecipeWindow recipeWindow = new RecipeWindow();
            recipeWindow.Show();
        }

        private void DisplayAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Invoke the RecipeDisplayer class to display recipes
            RecipeDisplayer.DisplayRecipes(Recipes, RecipeOutputTextBox);
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            // Clear the Recipes list
            Recipes.Clear();

            // Clear the RecipeOutputTextBox
            RecipeOutputTextBox.Text = "";

            // Optionally, you can display a message to indicate that the list has been cleared
            MessageBox.Show("All recipes have been cleared.", "Clear Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            // Check if there are recipes available
            if (Recipes.Count == 0)
            {
                MessageBox.Show("No recipes available. Please add recipes first.");
                return;
            }

            // Open the ScaleWindow passing the list of recipe names
            ScaleWindow scaleWindow = new ScaleWindow(Recipes);
            scaleWindow.ShowDialog();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            // Check if there are recipes available
            if (Recipes.Count == 0)
            {
                MessageBox.Show("No recipes available. Please add recipes first.");
                return;
            }

            // Open the ResetWindow passing the list of recipe names
            ResetWindow resetWindow = new ResetWindow(Recipes);
            resetWindow.ShowDialog();
        }

        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Check if there are recipes available
            if (Recipes.Count == 0)
            {
                MessageBox.Show("No recipes available. Please add recipes first.");
                return;
            }

            // Open the ClearRecipeWindow passing the list of recipe names
            ClearRecipeWindow clearRecipeWindow = new ClearRecipeWindow(Recipes);
            clearRecipeWindow.ShowDialog();

            // Update the RecipeOutputTextBox after clearing the recipe
            RecipeDisplayer.DisplayRecipes(Recipes, RecipeOutputTextBox);
        }

        private void DisplaySpecificRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the SelectRecipeWindow
            SelectRecipeWindow selectRecipeWindow = new SelectRecipeWindow(Recipes);

            // Display the window
            if (selectRecipeWindow.ShowDialog() == true)
            {
                // Get the selected recipe name
                string selectedRecipeName = selectRecipeWindow.SelectedRecipeName;

                // Find the recipe with the selected name
                Recipe selectedRecipe = Recipes.Find(recipe => recipe.RecipeName == selectedRecipeName);

                // Open the DisplayRecipeWindow and display the details of the selected recipe
                if (selectedRecipe != null)
                {
                    DisplayRecipeWindow displayRecipeWindow = new DisplayRecipeWindow();
                    displayRecipeWindow.DisplayRecipeDetails(selectedRecipe); // Pass the Recipe object directly
                    displayRecipeWindow.Show();
                }
                else
                {
                    MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            // Pass the list of recipes to the FilterWindow constructor
            FilterWindow filterWindow = new FilterWindow(listOfRecipes);

            // Show the filter window
            filterWindow.Show();
        }



    }
}
