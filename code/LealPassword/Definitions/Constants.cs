using System;
using System.Drawing;

namespace LealPassword.Definitions
{
    internal static class Constants
    {
        private static readonly string[] NiceMessages = new string[]
        {
            "Não importa que você vá devagar, contanto que você não pare.",
            "Para cada problema existe um desafio, para cada desafio existe uma solução.",
            "Faça o melhor que puder, seja o melhor que puder. O resultado virá na mesma proporção de seu esforço.",
            "Somos o que repetidamente fazemos. Portanto, a excelência não é um feito, é um hábito.",
            "Pedras no caminho? Guarde todas. Um dia poderá construir um castelo.",
            "As pessoas costumam dizer que a motivação não dura sempre. Bem, nem o efeito do banho, por isso recomenda-se diariamente.",
            "Motivação é a arte de fazer as pessoas fazerem o que você quer que elas façam porque elas o querem fazer.",
            "Lute. Acredite. Conquiste. Perca. Deseje. Espere. Alcance. Caia. Seja tudo, mas, acima de tudo, seja sempre você.",
            "O insucesso é apenas uma oportunidade para recomeçar com mais inteligência.",
            "Só se pode alcançar um grande êxito quando nos mantemos fiéis a nós mesmos."
        };

        internal static readonly bool DEBUG = true;

        internal static readonly int SW_HIDE = 0;
        internal static readonly int SW_SHOW = 5;
        internal static readonly int WM_NCLBUTTONDOWN = 0xA1;
        internal static readonly int HT_CAPTION = 0x2;
        internal static readonly int ELIPSE_CURVE = 25;
        internal static readonly int SIZE_GRIP = 16; 
        
        internal static readonly Size LoginCreateAccountSize = new Size(1280, 780);

        internal static string RandomNiceMessage
            => NiceMessages[new Random().Next(0, NiceMessages.Length - 1)];
    }
}