using System.Collections.Generic;
using System.Windows;
//This is the main window for my POE and displays all the buttons that are needed for navigation between the different windows.
namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class MainWindow : Window
    {
        // Static list of recipes accessible throughout the application
        public static List<Recipe> Recipes = new List<Recipe>();

        // Instance list of recipes specific to this MainWindow instance
        private List<Recipe> listOfRecipes;

        // Constructor for MainWindow
        public MainWindow()
        {
            InitializeComponent();
            Recipes = new List<Recipe>();  // Initialize static recipe list
            listOfRecipes = new List<Recipe>();  // Initialize instance-specific recipe list
        }

        // Event handler for Exit button click
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            // Prompt user for exit confirmation
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // Shutdown the application
                Application.Current.Shutdown();
            }
        }

        // Event handler for Add Recipe button click
        private void Add_Recipe_Click(object sender, RoutedEventArgs e)
        {
            // Open a new RecipeWindow for adding a recipe
            RecipeWindow recipeWindow = new RecipeWindow();
            recipeWindow.Show();
        }

        // Event handler for Display All Recipes button click
        private void DisplayAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Display all recipes in the RecipeOutputTextBox
            RecipeDisplayer.DisplayRecipes(Recipes, RecipeOutputTextBox);
        }

        // Event handler for Clear All Recipes button click
        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            // Clear all recipes from the Recipes list and clear RecipeOutputTextBox
            Recipes.Clear();
            RecipeOutputTextBox.Text = "";
            // Inform user that recipes have been cleared
            MessageBox.Show("All recipes have been cleared.", "Clear Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler for Scale Recipes button click
        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            // Open ScaleWindow to scale recipes if recipes exist
            if (Recipes.Count == 0)
            {
                MessageBox.Show("No recipes available. Please add recipes first.");
                return;
            }
            ScaleWindow scaleWindow = new ScaleWindow(Recipes);
            scaleWindow.ShowDialog();
        }

        // Event handler for Reset Recipes button click
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            // Open ResetWindow to reset recipes if recipes exist
            if (Recipes.Count == 0)
            {
                MessageBox.Show("No recipes available. Please add recipes first.");
                return;
            }
            ResetWindow resetWindow = new ResetWindow(Recipes);
            resetWindow.ShowDialog();
        }

        // Event handler for Clear Single Recipe button click
        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Open ClearRecipeWindow to clear a specific recipe if recipes exist
            if (Recipes.Count == 0)
            {
                MessageBox.Show("No recipes available. Please add recipes first.");
                return;
            }
            ClearRecipeWindow clearRecipeWindow = new ClearRecipeWindow(Recipes);
            clearRecipeWindow.ShowDialog();
            // Display remaining recipes in RecipeOutputTextBox after clearing
            RecipeDisplayer.DisplayRecipes(Recipes, RecipeOutputTextBox);
        }

        // Event handler for Display Specific Recipe button click
        private void DisplaySpecificRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Open SelectRecipeWindow to choose and display a specific recipe
            SelectRecipeWindow selectRecipeWindow = new SelectRecipeWindow(Recipes);
            if (selectRecipeWindow.ShowDialog() == true)
            {
                // Retrieve selected recipe and display its details
                string selectedRecipeName = selectRecipeWindow.SelectedRecipeName;
                Recipe selectedRecipe = Recipes.Find(recipe => recipe.RecipeName == selectedRecipeName);
                if (selectedRecipe != null)
                {
                    DisplayRecipeWindow displayRecipeWindow = new DisplayRecipeWindow();
                    displayRecipeWindow.DisplayRecipeDetails(selectedRecipe);
                    displayRecipeWindow.Show();
                }
                else
                {
                    // Inform user if selected recipe was not found
                    MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Event handler for Open Search Window button click
        private void OpenSearchWindow_Click(object sender, RoutedEventArgs e)
        {
            // Open SearchWindow to perform recipe search
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.Show();
        }

        // Event handler for Open View Recipe Window button click
        private void OpenViewRecipeWindow_Click(object sender, RoutedEventArgs e)
        {
            // Open ViewRecipeWindow to view recipes
            ViewRecipeWindow viewRecipeWindow = new ViewRecipeWindow();
            viewRecipeWindow.Show();
        }
    }
}
