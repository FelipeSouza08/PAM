using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace DiceApp
{
    public partial class MainPage : ContentPage
    {
        int totalFO = 0;

        int sorteado, itemIndex = -1;

        Game jogo = new Game();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void FlipButton_Clicked(object sender, EventArgs e)
        {
            if (totalFO >= 25)
            {
                FlipButton.IsEnabled = false;
                await DisplayAlert("FIM DE JOGO!!", "Tentativas máximas utilizadas", "OK");
                return;
            }

            itemIndex = FacePicker.SelectedIndex;

            if (itemIndex == -1)
            {
                await DisplayAlert("Dado", "Escolha um lado do dado!", "OK");
            }
            else
            {
                Dice dado = new Dice();
                int face = dado.Roll();

                sorteado = face;
                int escolhido = itemIndex + 1;

                await Animate(face);

                int faceOposta = 7 - sorteado;
                totalFO += faceOposta; 

                if (jogo.CheckWinner(escolhido, sorteado))
                {
                    await DisplayAlert("Sorteio", $"PARABÉNS!!!\nDeu {face}!\nVocê GANHOU!" +
                        $"\nVocê ganhou {jogo.PlayerPoint} vezes!" +
                        $"\nSua sequência é de: {jogo.Streak}" +
                        $"\nSua tentativas totais são de: {totalFO}", "OK" );
                }
                else
                {
                    await DisplayAlert("Sorteio", $"Que pena!\nDeu {face}.\nVocê PERDEU!" +
                        $"\nSua tentativas totais são de: {totalFO}", "OK");
                }
            }
        }
        private async Task Animate(int face)
        {
            Random giros = new Random();
            int lados = 6;

            for (int i = 0; i < giros.Next(5, 10); i++)
            {
                int numeroAleatorio = giros.Next(1, lados + 1);
                FaceImage.Source = $"dado_{numeroAleatorio}.png";
                await Task.Delay(100);
            }

            FaceImage.Source = $"dado_{face}.png";
        }

        private void RestartButton_Clicked(object sender, EventArgs e)
        {
                totalFO = 0;
                jogo.PlayerPoint = 0;
                jogo.Streak = 0;
            FlipButton.IsEnabled = true;
        }
    }
}
