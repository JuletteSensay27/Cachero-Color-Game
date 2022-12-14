using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cachero_Color_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Label[] gameColorDice = new Label[] { }; 
        private Grid gameDiceGrid = new Grid();
        private Color[] listOfColors = new Color[6];
        private int[] selectedColors = new int[] { };

        public MainWindow()
        {
            InitializeComponent();
            initDices();
        }

        private void initDices() 
        {
            initDiceGrid();
            int h = 5;

            gameColorDice = new Label[3];

            for (int i = 0; i < gameColorDice.Length; i++) 
            {
                Label dice = new Label();
                dice.VerticalAlignment = VerticalAlignment.Top;
                dice.HorizontalAlignment = HorizontalAlignment.Left;
                dice.VerticalContentAlignment= VerticalAlignment.Center;
                dice.HorizontalContentAlignment= HorizontalAlignment.Center;
                dice.Width = 80;
                dice.Height = 80;
                dice.Margin = new Thickness(h,10,0,0);
                dice.BorderBrush = new SolidColorBrush(Colors.Black);
                dice.BorderThickness = new Thickness(1,1,1,1);
                switch (i) 
                {
                    case 0:
                        dice.Content = "Dice 1";
                        break;
                    case 1:
                        dice.Content = "Dice 2";
                        break;
                    case 2:
                        dice.Content = "Dice 3";
                        break;
                }
                gameColorDice[i] = dice;
                gameDiceGrid.Children.Add(gameColorDice[i]);

                h += 10 + (int)dice.Width;
            }

        }

        private void initDiceGrid() 
        {
            gameDiceGrid = new Grid();
            gameDiceGrid.HorizontalAlignment = HorizontalAlignment.Left;
            gameDiceGrid.VerticalAlignment = VerticalAlignment.Top;
            gameDiceGrid.Width = 300;
            gameDiceGrid.Height = 90;
            gameDiceGrid.Margin = new Thickness(350,200,0,0);
            mainGrid.Children.Add(gameDiceGrid);
        }

        private  async void generateColor() 
        {
            
            selectedColors = new int[3];
            Random random= new Random();
            int colorIndex = 0;
            int diceCounter = 0;
            int rollCounter = 0;

            while (diceCounter < 3) 
            {
                while (rollCounter < 20) 
                {
                    await Task.Delay(50);
                    colorIndex = random.Next(1000000);
                    colorIndex %= 100000;
                    colorIndex %= 10000;
                    colorIndex %= 100;
                    colorIndex %= 6;

                    gameColorDice[diceCounter].Background = new SolidColorBrush(listOfColors[colorIndex]);              
                    rollCounter++;              
                }
                selectedColors[diceCounter] = colorIndex; 
                colorIndex = 0;
                rollCounter = 0;
                diceCounter++;
            }

            getColorArrValues(selectedColors);

        }

        private void addElColorList() 
        {
            listOfColors = new Color[6];
            listOfColors[0] = Color.FromRgb(0, 0, 255); //Color of Blue
            listOfColors[1] = Color.FromRgb(0, 255, 0); //Color of Green
            listOfColors[2] = Color.FromRgb(255, 255, 0); //Color of Yellow
            listOfColors[3] = Color.FromRgb(255, 0, 0); //Color of Red
            listOfColors[4] = Color.FromRgb(255, 140, 0); //Color of Orange
            listOfColors[5] = Color.FromRgb(255, 0, 255); // Color of Purple
        }

        private void confirmWagerBtn_Click(object sender, RoutedEventArgs e)
        {
            var confirm = MessageBox.Show("Do you want to proceed with this action?", "Confirmation", MessageBoxButton.YesNo);

            if (confirm == MessageBoxResult.Yes)
            {
                for (int i = 0; i < gameColorDice.Length; i++)
                    gameColorDice[i].Background = new SolidColorBrush(Colors.Transparent);
                addElColorList();
                generateColor();
            }
            else
            {
                MessageBox.Show("Cancelled");
            }   
        }

        private void getColorArrValues(int[] colorArr) 
        {
            for (int i = 0; i < colorArr.Length; i++) 
            {
                switch (colorArr[i]) 
                {
                    case 0:
                        MessageBox.Show($"Color {i + 1}: Blue");
                        break;
                    case 1:
                        MessageBox.Show($"Color {i + 1}: Green");
                        break;
                    case 2:
                        MessageBox.Show($"Color {i + 1}: Yellow");
                        break;
                    case 3:
                        MessageBox.Show($"Color {i + 1}: Red");
                        break;
                    case 4:
                        MessageBox.Show($"Color {i + 1}: Orange");
                        break;
                    case 5:
                        MessageBox.Show($"Color {i + 1}: Purple");
                        break;

                }
            }
        }
       
    }
}
