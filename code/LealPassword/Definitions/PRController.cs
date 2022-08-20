using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace LealPassword.Definitions
{
    internal static class PRController
    {
        internal static class Images
        {
            internal static Image Close16px => Properties.Resources.close_16px;
            internal static Image Cards127px => Properties.Resources.cards_127px;
            internal static Image CardsBlack256px => Properties.Resources.cards_black_256px;
            internal static Image RegisterBlack256px => Properties.Resources.register_black_256px;
            internal static Image Minimize16px => Properties.Resources.minimize_16px;
            internal static Image Registers127px => Properties.Resources.register_127px;
            internal static Image General127px => Properties.Resources.four_squares_127px;
            internal static Image Config127px_Black => Properties.Resources.gear_black_127px;
        }

        internal static List<Image> IconsList = new List<Image>()
        {
            Properties.Resources.alta_temperatura,
            Properties.Resources.android,
            Properties.Resources.apple,
            Properties.Resources.apple_pay,
            Properties.Resources.aviao_alt,
            Properties.Resources.banco,
            Properties.Resources.bitcoin,
            Properties.Resources.bluetooth,
            Properties.Resources.cabeca_de_crianca,
            Properties.Resources.cadeira_de_rodas,
            Properties.Resources.cafe,
            Properties.Resources.carrinho_de_compras,
            Properties.Resources.cartao_de_credito,
            Properties.Resources.carteira,
            Properties.Resources.chess_knight_alt,
            Properties.Resources.ciclismo_montanha,
            Properties.Resources.citacao_a_direita,
            Properties.Resources.computador,
            Properties.Resources.controle,
            Properties.Resources.cubo,
            Properties.Resources.dados_alt,
            Properties.Resources.definicoes,
            Properties.Resources.despertador,
            Properties.Resources.dev,
            Properties.Resources.dinheiro,
            Properties.Resources.disco,
            Properties.Resources.discord,
            Properties.Resources.dolar,
            Properties.Resources.do_utilizador,
            Properties.Resources.dropbox,
            Properties.Resources.estetoscopio,
            Properties.Resources.ethereum,
            Properties.Resources.facebook,
            Properties.Resources.facebook_messenger,
            Properties.Resources.fisica,
            Properties.Resources.fone_de_ouvido,
            Properties.Resources.foto,
            Properties.Resources.ginasio,
            Properties.Resources.github,
            Properties.Resources.google,
            Properties.Resources.grafico_de_pizza,
            Properties.Resources.grafico_histograma,
            Properties.Resources.hamburger,
            Properties.Resources.hbo,
            Properties.Resources.impressao_digital,
            Properties.Resources.informacoes,
            Properties.Resources.instagram,
            Properties.Resources.intel,
            Properties.Resources.line,
            Properties.Resources.linkedin,
            Properties.Resources.lixo,
            Properties.Resources.marcador_de_livro,
            Properties.Resources.mcdonalds,
            Properties.Resources.moedas,
            Properties.Resources.mundo,
            Properties.Resources.musica_alt,
            Properties.Resources.nadador,
            Properties.Resources.netflix,
            Properties.Resources.oracle,
            Properties.Resources.paleta,
            Properties.Resources.photoshop,
            Properties.Resources.pinterest,
            Properties.Resources.ponta_de_ampulheta,
            Properties.Resources.recursos,
            Properties.Resources.reddit,
            Properties.Resources.rede_social,
            Properties.Resources.relogio,
            Properties.Resources.restaurante,
            Properties.Resources.skype,
            Properties.Resources.snapchat,
            Properties.Resources.sony,
            Properties.Resources.spotify,
            Properties.Resources.tag,
            Properties.Resources.telegram,
            Properties.Resources.tik_tok,
            Properties.Resources.twitch,
            Properties.Resources.twitter,
            Properties.Resources.uber,
            Properties.Resources.visa,
            Properties.Resources.visual_basic,
            Properties.Resources.vk,
            Properties.Resources.voleibol,
            Properties.Resources.whatsapp,
            Properties.Resources.windows,
            Properties.Resources.wix,
            Properties.Resources.wordpress,
            Properties.Resources.youtube
        };

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