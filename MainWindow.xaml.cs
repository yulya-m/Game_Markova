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
using Game_Markova.Classes;
using System.Windows.Threading;

namespace Game_Markova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Classes.PersonInfo Player = new Classes.PersonInfo("Student", 100, 10, 1, 0, 0, 5);
        public List<Classes.PersonInfo> Enemys = new List<Classes.PersonInfo>();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public Classes.PersonInfo Enemy;

        public MainWindow()
        {
            InitializeComponent();
            UserInfoPlayer();

            Enemys.Add(new Classes.PersonInfo("Болотный зверь", 100, 10, 1, 0, 15, 10));
            Enemys.Add(new Classes.PersonInfo("Болотный зверь 2", 120, 15, 1, 0, 30, 15));
            Enemys.Add(new Classes.PersonInfo("Болотный зверь 3", 150, 20, 1, 0, 40, 20));

            dispatcherTimer.Tick += AtackPlayer;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();

            SelectEnemy();

        }

        private void AtackPlayer(object sender, EventArgs e)
        {
            Player.Health -= Convert.ToInt32(Enemy.Damage * 100f / (100f - Player.Armor));
            UserInfoPlayer();
        }

        public void SelectEnemy()
        {
            int Id = new Random().Next(0, Enemys.Count);
            Enemy = new Classes.PersonInfo(
                Enemys[Id].Name,
                Enemys[Id].Health,
                Enemys[Id].Armor,
                Enemys[Id].Level,
                Enemys[Id].Glasses,
                Enemys[Id].Money,
                Enemys[Id].Damage
                );
        }
        public void UserInfoPlayer()
        {
            if(Player.Glasses > Player.Level * 100)
            {
                Player.Level++;
                Player.Glasses = 0;
                Player.Health += 100;
                Player.Damage++;
                Player.Armor++;
            }

            playerHealth.Content = "Жизненные показатели: " + Player.Health;
            playerArmor.Content = "Броня: " + Player.Armor;
            playerLevel.Content = "Уровень: " + Player.Level;
            playerGlasses.Content = "Опыт: " + Player.Glasses;
            playerMoney.Content = "Монеты: " + Player.Money;
        }

        private void AttackEnemy(object sender, MouseButtonEventArgs e)
        {
            Enemy.Health -= Convert.ToInt32(Player.Damage * 100f / (100f - Enemy.Armor));
            if (Enemy.Health <= 0)
            {
                Player.Glasses += Enemy.Glasses;
                Player.Money += Enemy.Money;
                UserInfoPlayer();
                SelectEnemy();
            }
            else
            {
                enemyHealth.Content = "Жизненные показатели: " + Enemy.Health;
                enemyArmor.Content = "Броня: " + Enemy.Armor;
            }
        }
    }
}
