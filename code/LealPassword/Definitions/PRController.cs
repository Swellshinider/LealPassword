using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace LealPassword.Definitions
{
    internal static class PRController
    {
        internal static class Images
        {
            internal static Image Eye_50px => Properties.Resources.eye_50px;
            internal static Image Close16px => Properties.Resources.close_16px;
            internal static Image Cards127px => Properties.Resources.cards_127px;
            internal static Image Minimize16px => Properties.Resources.minimize_16px;
            internal static Image Registers127px => Properties.Resources.register_127px;
            internal static Image ClosedEye_50px => Properties.Resources.closed_eye_50px;
            internal static Image General127px => Properties.Resources.four_squares_127px;
            internal static Image ScriptKey_127px => Properties.Resources.script_key_127px;
            internal static Image CardsBlack256px => Properties.Resources.cards_black_256px;
            internal static Image Config127px_Black => Properties.Resources.gear_black_127px;
            internal static Image RegisterBlack256px => Properties.Resources.register_black_256px;
            internal static Image DataBaseBackup_127px => Properties.Resources.database_backup_127px;

            internal static Image LealPasswordLogo128px => Properties.Resources.LealPassword_128px;
            internal static Image LealPasswordLogo500px => Properties.Resources.LealPassword_500px;

            internal static Image LealPasswordLogoBlack128px => Properties.Resources.LealPassword_black_128px;
            internal static Image LealPasswordLogoBlack500px => Properties.Resources.LealPassword_black_500px;
        }

        internal static Icon LealPassword_Icon => Properties.Resources.LealPassword_Icon;
        internal static Icon LealPassword_Black_Icon => Properties.Resources.LealPassword_black_Icon;

        internal static Dictionary<string, Image> dictIdImages = new Dictionary<string, Image>()
        {
            { "", new Bitmap(64, 64) },
            { "alta_temperatura", Properties.Resources.alta_temperatura },
            { "android", Properties.Resources.android },
            { "apple", Properties.Resources.apple },
            { "apple_pay", Properties.Resources.apple_pay },
            { "aviao_alt", Properties.Resources.aviao_alt },
            { "banco", Properties.Resources.banco },
            { "bitcoin", Properties.Resources.bitcoin },
            { "bluetooth", Properties.Resources.bluetooth },
            { "cabeca_de_crianca", Properties.Resources.cabeca_de_crianca },
            { "cadeira_de_rodas", Properties.Resources.cadeira_de_rodas },
            { "cafe", Properties.Resources.cafe },
            { "carrinho_de_compras", Properties.Resources.carrinho_de_compras },
            { "cartao_de_credito", Properties.Resources.cartao_de_credito },
            { "carteira", Properties.Resources.carteira },
            { "chess_knight_alt", Properties.Resources.chess_knight_alt },
            { "ciclismo_montanha", Properties.Resources.ciclismo_montanha },
            { "citacao_a_direita", Properties.Resources.citacao_a_direita },
            { "computador", Properties.Resources.computador },
            { "controle", Properties.Resources.controle },
            { "cubo", Properties.Resources.cubo },
            { "dados_alt", Properties.Resources.dados_alt },
            { "definicoes", Properties.Resources.definicoes },
            { "despertador", Properties.Resources.despertador },
            { "dev", Properties.Resources.dev },
            { "dinheiro", Properties.Resources.dinheiro },
            { "disco", Properties.Resources.disco },
            { "discord", Properties.Resources.discord },
            { "dolar", Properties.Resources.dolar },
            { "do_utilizador", Properties.Resources.do_utilizador },
            { "dropbox", Properties.Resources.dropbox },
            { "estetoscopio", Properties.Resources.estetoscopio },
            { "ethereum", Properties.Resources.ethereum },
            { "facebook", Properties.Resources.facebook },
            { "facebook_messenger", Properties.Resources.facebook_messenger },
            { "fisica", Properties.Resources.fisica },
            { "fone_de_ouvido", Properties.Resources.fone_de_ouvido },
            { "foto", Properties.Resources.foto },
            { "ginasio", Properties.Resources.ginasio },
            { "github", Properties.Resources.github },
            { "google", Properties.Resources.google },
            { "grafico_de_pizza", Properties.Resources.grafico_de_pizza },
            { "grafico_histograma", Properties.Resources.grafico_histograma },
            { "hamburger", Properties.Resources.hamburger },
            { "hbo", Properties.Resources.hbo },
            { "impressao_digital", Properties.Resources.impressao_digital },
            { "informacoes", Properties.Resources.informacoes },
            { "instagram", Properties.Resources.instagram },
            { "intel", Properties.Resources.intel },
            { "line", Properties.Resources.line },
            { "linkedin", Properties.Resources.linkedin },
            { "lixo", Properties.Resources.lixo },
            { "marcador_de_livro", Properties.Resources.marcador_de_livro },
            { "mcdonalds", Properties.Resources.mcdonalds },
            { "moedas", Properties.Resources.moedas },
            { "mundo", Properties.Resources.mundo },
            { "musica_alt", Properties.Resources.musica_alt },
            { "nadador", Properties.Resources.nadador },
            { "netflix", Properties.Resources.netflix },
            { "oracle", Properties.Resources.oracle },
            { "paleta", Properties.Resources.paleta },
            { "photoshop", Properties.Resources.photoshop },
            { "pinterest", Properties.Resources.pinterest },
            { "ponta_de_ampulheta", Properties.Resources.ponta_de_ampulheta },
            { "recursos", Properties.Resources.recursos },
            { "reddit", Properties.Resources.reddit },
            { "rede_social", Properties.Resources.rede_social },
            { "relogio", Properties.Resources.relogio },
            { "restaurante", Properties.Resources.restaurante },
            { "skype", Properties.Resources.skype },
            { "snapchat", Properties.Resources.snapchat },
            { "sony", Properties.Resources.sony },
            { "spotify", Properties.Resources.spotify },
            { "tag", Properties.Resources.tag },
            { "telegram", Properties.Resources.telegram },
            { "tik_tok", Properties.Resources.tik_tok },
            { "twitch", Properties.Resources.twitch },
            { "twitter", Properties.Resources.twitter },
            { "uber", Properties.Resources.uber },
            { "visa", Properties.Resources.visa },
            { "visual_basic", Properties.Resources.visual_basic },
            { "vk", Properties.Resources.vk },
            { "voleibol", Properties.Resources.voleibol },
            { "whatsapp", Properties.Resources.whatsapp },
            { "windows", Properties.Resources.windows },
            { "wix", Properties.Resources.wix },
            { "wordpress", Properties.Resources.wordpress },
            { "youtube", Properties.Resources.youtube }
        };
        
        internal static List<Image> GetIconsList()
        {
            var list = new List<Image>();

            foreach(var kv in dictIdImages)
                list.Add(kv.Value);

            return list;
        }

        internal static string GetImageKeyByValue(Image image) => dictIdImages.FirstOrDefault(x => x.Value == image).Key;

        internal static string LastUser 
        { 
            get
            {
                return Properties.Settings.Default.LastUser;
            }
            
            set
            {
                Properties.Settings.Default.LastUser = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}