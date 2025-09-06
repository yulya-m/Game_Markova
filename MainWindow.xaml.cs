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

namespace Game_Markova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PersonInfo Player = new PersonInfo("Student", 100, 10, 1, 0, 0, 5);

        public MainWindow()
        {
            InitializeComponent();
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

            playerHealth.Content = "Жизненные показатели: " + playerHealth;
            playerArmor.Content = "Броня: " + playerArmor;
            playerLevel.Content = "Уровень: " + playerLevel;
            playerGlasses.Content = "Опыт: " + playerGlasses;
            playerMoney.Content = "Монеты: " + playerMoney;
        }

        private void AttackEnemy(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
