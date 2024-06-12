using System.Collections.Generic;
using System.Windows;

namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class MainWindow : Window
    {
        public static List<Recipe> Recipes = new List<Recipe>();
        private List<Recipe> listOfRecipes;

        public MainWindow()
        {
            InitializeComponent();
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
            RecipeDisplayer.DisplayRecipes(Recipes, RecipeOutputTextBox);
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            Recipes.Clear();
            RecipeOutputTextBox.Text = "";
            MessageBox.Show("All recipes have been cleared.", "Clear Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            if (Recipes.Count == 0)
            {
                MessageBox.Show("No recipes available. Please add recipes first.");
                return;
            }
            ScaleWindow scaleWindow = new ScaleWindow(Recipes);
            scaleWindow.ShowDialog();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (Recipes.Count == 0)
            {
                MessageBox.Show("No recipes available. Please add recipes first.");
                return;
            }
            ResetWindow resetWindow = new ResetWindow(Recipes);
            resetWindow.ShowDialog();
        }

        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (Recipes.Count == 0)
            {
                MessageBox.Show("No recipes available. Please add recipes first.");
                return;
            }
            ClearRecipeWindow clearRecipeWindow = new ClearRecipeWindow(Recipes);
            clearRecipeWindow.ShowDialog();
            RecipeDisplayer.DisplayRecipes(Recipes, RecipeOutputTextBox);
        }

        private void DisplaySpecificRecipe_Click(object sender, RoutedEventArgs e)
        {
            SelectRecipeWindow selectRecipeWindow = new SelectRecipeWindow(Recipes);
            if (selectRecipeWindow.ShowDialog() == true)
            {
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
                    MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void OpenSearchWindow_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.Show();
        }
    }
}
