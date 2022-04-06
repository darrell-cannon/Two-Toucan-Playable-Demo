using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
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
using System.IO;
using System.Diagnostics;
using Color = System.Drawing.Color;

namespace TwoToucanGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {
        private System.Windows.Threading.DispatcherTimer remainTimer = new System.Windows.Threading.DispatcherTimer();
        public static bool cardsRevealing = false;
        public static string[] fileList;
        public static List<Player> players = new List<Player>();

        //current card in list to display
        public static int currentCard = 0;
        public static int firstCard = 0;

        //used to alter scoring if player is incorrect
        public static bool playerIncorrect = false;
        public static bool gameOver = false;
        public MainWindow()
        {
            InitializeComponent();

            remainTimer.Tick += new EventHandler(ChangeImage);
            remainTimer.Interval = TimeSpan.FromSeconds(1);
            remainTimer.Start();

            fileList = randomiseList();
        }

        public static string[] randomiseList()
        {
            //get list of images and randomise them.

            string fileName = String.Format(@"{0}\Cards", System.Windows.Forms.Application.StartupPath);

            string[] fileList = Directory.GetFiles(fileName);
            Random random = new Random();
            fileList = fileList.OrderBy(c => random.Next()).ToArray();

            return fileList;
        }

        public async static void ChangeImage(object sender, EventArgs e)
        {
            MainWindow ExistingInstanceOfMainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
            ImageBrush cardObject = ExistingInstanceOfMainWindow.CardImage;
            int cardStart = 0;

            if (cardsRevealing && currentCard < fileList.Count())
            {
                cardObject.ImageSource = new BitmapImage(new Uri(fileList[currentCard]));
                currentCard++;
            }

            if(cardsRevealing && currentCard == fileList.Count())
            {
                cardsRevealing = false;
                gameOver = true;
                GameOver();
            }


        }

        private void ShowPlayedCards(object sender, RoutedEventArgs e)
        {
            //hide button
            MainWindow ExistingInstanceOfMainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
            Border ShowPlayedCardsButton = ExistingInstanceOfMainWindow.ShowPlayedCardsButton;
            ShowPlayedCardsButton.Visibility = Visibility.Collapsed;

            ImageBrush cardObject = ExistingInstanceOfMainWindow.CardImage;
            cardObject.ImageSource = null;

            ExistingInstanceOfMainWindow.PlayersScoreButtons.Children.Clear();

            PlayersScoreButtons.Visibility = Visibility.Visible;

            //show player score buttons
            for (int i = 0; i < players.Count() + 1; i++)
            {
                Border roundedCorner = new Border
                {
                    Height = 100,
                    Width = 200,
                    BorderThickness = new Thickness(10),
                    Margin = new Thickness(10),
                    CornerRadius = new CornerRadius(20),
                    Padding = new Thickness(0),                    
                };

                roundedCorner.BorderBrush = System.Windows.Media.Brushes.Black;
                roundedCorner.Background = System.Windows.Media.Brushes.White;

                Button button = new Button();
                //if i less than player count then it's one of the players buttons
                if (i < players.Count)
                {
                    
                    {
                        button.Content = players[i].Name;
                    };

                    button.Click += (sender, e) =>
                    {
                        AddPointsToPlayer(sender, e, currentCard - firstCard);
                    };
                }
                else if(i == players.Count)
                {
                    {
                        button.Content = "Incorrect?!";
                    };

                    button.Click += (sender, e) =>
                    {
                        PlayerIncorrect(sender, e, currentCard - firstCard);
                    };
                }
                

                Style style = this.FindResource("MyButtonStyle") as Style;
                button.Style = style;
                button.FontSize = 30;
                button.FontWeight = FontWeights.Bold;
                button.Margin = new Thickness(10);

                roundedCorner.Child = button;

                ExistingInstanceOfMainWindow.PlayersScoreButtons.Children.Add(roundedCorner);
                ExistingInstanceOfMainWindow.PlayersScoreButtons.HorizontalAlignment = HorizontalAlignment.Center;
            }

            //fill wrappanel with previous cards
            for (int j = firstCard; j < currentCard; j++)
            {
                Border roundedCorner = new Border
                {
                    Height = 150,
                    Width = 115,
                    BorderThickness = new Thickness(0),
                    Margin = new Thickness(10),
                    CornerRadius = new CornerRadius(20),
                    Padding = new Thickness(0),
                    Background = new ImageBrush
                    {

                        ImageSource = new BitmapImage(new Uri(fileList[j]))
                    }
                };


                ExistingInstanceOfMainWindow.CardsPlayedDisplayPanel.Children.Add(roundedCorner);
            }
        }

        private static void AddPointsToPlayer(object sender, EventArgs e, int score)
        {
            //get the content of the button to see which plyer it is
            Button button = sender as Button;
            
            if (!gameOver)
            {
                string text = (string)button.Content;

                if (playerIncorrect)
                {
                    int sharedScore;
                    if (players.Count > 1)
                    {
                        sharedScore = score / (players.Count - 1);
                    }
                    else { sharedScore = score; };

                    foreach (Player player in players)
                    {
                        if (player.Name != text)
                        {
                            player.Score += sharedScore;
                        }
                    }

                    playerIncorrect = false;
                }
                else
                {

                    foreach (Player player in players)
                    {
                        if (player.Name == text)
                        {
                            player.Score += score;
                        }
                    }
                }


                ShowScores();
            }
            
            
          
        }

        private void PlayerIncorrect(object sender, EventArgs e, int score)
        {
            playerIncorrect = !playerIncorrect;

            Button button = sender as Button;

            if (playerIncorrect)
            {
                
                button.Background = System.Windows.Media.Brushes.Red;
            }
            else if (!playerIncorrect)
            {
                button.Background = System.Windows.Media.Brushes.White;
            }
        }

        private static void GameOver()
        {
            MainWindow ExistingInstanceOfMainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
            ExistingInstanceOfMainWindow.CardImageObject.Visibility = Visibility.Collapsed; 
            WrapPanel PlayerScoreButtons = ExistingInstanceOfMainWindow.PlayersScoreButtons;
            PlayerScoreButtons.Visibility = Visibility.Visible;

            foreach (Button button in FindVisualChildren<Button>(PlayerScoreButtons))
            {
                button.Click -= (sender, e) =>
                {
                    AddPointsToPlayer(sender, e, currentCard - firstCard);
                };
            }

            ExistingInstanceOfMainWindow.StartButton.Visibility = Visibility.Visible;
            ExistingInstanceOfMainWindow.StartButton.Margin = new Thickness(200, 150, 200, 0);
            Button startButton = (Button)ExistingInstanceOfMainWindow.StartButton.Child;
            startButton.Content = "Game Over! Replay?";

            Restart();

        }

        private static void Restart()
        {
            randomiseList();
            currentCard = 0;
            gameOver = false;

            foreach(Player player in players)
            {
                player.Score = 0;
            }
            
            
        }

        private static void ShowScores()
        {
            MainWindow ExistingInstanceOfMainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
            WrapPanel PlayerScoreButtons = ExistingInstanceOfMainWindow.PlayersScoreButtons;
            PlayerScoreButtons.Visibility = Visibility.Visible;

            foreach (Button button in FindVisualChildren<Button>(PlayerScoreButtons))
            {
                foreach (Player player in players)
                {
                    if(player.Name == button.Content)
                    {
                        button.Content = player.Score;
                    }
                }                   
            }

            ExistingInstanceOfMainWindow.StartButton.Visibility = Visibility.Visible;
            ExistingInstanceOfMainWindow.StartButton.Margin = new Thickness(200, 150, 200, 0);
            Button startButton = (Button)ExistingInstanceOfMainWindow.StartButton.Child;
            startButton.Content = "Resume";
        }

        //use to find children elements on wrappanel
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += HandSlapped;
        }


        //detect if player pressed space key during card revleaing,stops cards revealing and shows button to to reveal all current cards
        private void HandSlapped(object sender, KeyEventArgs e)
        {
            if (cardsRevealing)
            {
                cardsRevealing = false;
                MainWindow ExistingInstanceOfMainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
                Border ShowPlayedCardsButton = ExistingInstanceOfMainWindow.ShowPlayedCardsButton;
                ShowPlayedCardsButton.Visibility = Visibility.Visible; ;
            }

        }

        
        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            Border buttonParent = (Border)button.Parent;
            buttonParent.Visibility = Visibility.Collapsed;
            //empty the wrap panel
            MainWindow ExistingInstanceOfMainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
            ExistingInstanceOfMainWindow.CardsPlayedDisplayPanel.Children.Clear();
            ExistingInstanceOfMainWindow.titleScreen.Visibility = Visibility.Collapsed;
            ExistingInstanceOfMainWindow.GetPlayerDetails.Visibility = Visibility.Collapsed;
            ExistingInstanceOfMainWindow.PlayersScoreButtons.Visibility = Visibility.Collapsed; 

            if (players.Count == 0)
            {
                DisplayNumberOfPlayerForm();
            }
            else
            {
                StartCardRevealing();           
            }            

        }

        private void StartCardRevealing()
        {
            cardsRevealing = true;
            MainWindow ExistingInstanceOfMainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
            ExistingInstanceOfMainWindow.CardImageObject.Visibility = Visibility.Visible;
            //sets firstcard so we know how many cards ahve been played
            firstCard = currentCard;
        }

       private void DisplayNumberOfPlayerForm()
        {
            MainWindow MainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
            MainWindow.NumberOfPlayersPage.Visibility = Visibility.Visible;
            MainWindow.titleScreen.Visibility = Visibility.Collapsed;
        }

       private void DisplayPlayerDetailForm(int nOfPlayers)
        {
            MainWindow MainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
            MainWindow.GetPlayerDetails.Visibility = Visibility.Visible;

            for (int i = 0; i < nOfPlayers; i++)
            {
                TextBox textBox = new TextBox
                {
                    FontSize = 30,
                    Height = 60,
                    Text = $"Player {i +1}"                    
                };

                textBox.GotFocus += (sender, args) =>
                {
                    textBox.Text = "";

                };

                MainWindow.PlayerDetailsStackPanel.Children.Add(textBox);
            };                
            
        }

       private void NoOfPlayers_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ExistingInstanceOfMainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
            Grid NumberOfPlayersPage = ExistingInstanceOfMainWindow.NumberOfPlayersPage;
            NumberOfPlayersPage.Visibility = Visibility.Collapsed;

            Button? button = sender as Button;

            switch ((string)button.Content)
            {
                case "1 Player":
                    DisplayPlayerDetailForm(1);
                    break;
                case "2 Player":
                    DisplayPlayerDetailForm(2);
                    break;
                case "3 Player":
                    DisplayPlayerDetailForm(3);
                    break;
                case "4 Player":
                    DisplayPlayerDetailForm(4);
                    break;
            }
        }

       private void PlayerDetailsFormClick(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
            StackPanel stackPanel =  MainWindow.PlayerDetailsStackPanel;

            foreach(TextBox text in stackPanel.Children)
            {
                players.Add(new Player(text.Text));
            }

            Start_Button_Click( sender,  e);
        }
    }
}
