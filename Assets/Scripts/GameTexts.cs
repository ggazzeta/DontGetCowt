using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameTexts
{
    // 1 = INGLES 
    // 2 = PORTUGUES
    private static int _language = PlayerPrefs.GetInt("Language");

    public static string textNoAccessOutside(this string outText)
    {
        if (_language == 1)
        {
            outText = "You still don't have access to open the Level Selector";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Voce ainda nao desbloqueou a selecao de fases";
            return outText; //codigo
        }
        return "";
    }

    public static string noAccessToTheLvl(this string outText)
    {
        if (_language == 1)
        {
            outText = "You don't have access to this level just yet. Keep playing until you reach it!";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Voce ainda nao desbloqueou essa fase. Continue jogando ate chegar nela!";
            return outText; //codigo
        }

        return "";
    }

    public static string touchText(this string outText)
    {
        if (_language == 1)
        {
            outText = "Touch in the highlighted zone to use the Joystick";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Toque na zona em destaque para usar o Joystick";
            return outText; //codigo
        }

        return "";
    }

    public static string moveText(this string outText)
    {
        if (_language == 1)
        {
            outText = "Move Left & Right";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Mova-se pra esquerda & direita";
            return outText; //codigo
        }

        return "";
    }

    public static string holdText(this string outText)
    {
        if (_language == 1)
        {
            outText = "Hold the button to cast the light";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Segure o botao para usar a luz de abducao";
            return outText; //codigo
        }

        return "";
    }

    public static string abductText(this string outText)
    {
        if (_language == 1)
        {
            outText = "Abduct a cow";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Abduza uma vaca";
            return outText; //codigo
        }

        return "";
    }

    public static string tipText(this string outText)
    {
        if (_language == 1)
        {
            outText = "Did you notice that you have an energy bar? \nBe careful not to run out of energy.";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Voce notou que existe uma barra de energia? \nCuidado pra nao ficar sem energia.";
            return outText; //codigo
        }

        return "";
    }

    public static string youWonText(this string outText)
    {
        if (_language == 1)
        {
            outText = "You have collected all of the cows!";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Voce abduziu todas as vacas!";
            return outText; //codigo
        }

        return "";
    }

    public static string congratsText(this string outText)
    {
        if (_language == 1)
        {
            outText = "Congratulations!";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Parabens!";
            return outText; //codigo
        }

        return "";
    }

    public static string nextText(this string outText)
    {
        if (_language == 1)
        {
            outText = "Next";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Proximo";
            return outText; //codigo
        }

        return "";
    }

    public static string FaseTwo(this string outText)
    {
        if (_language == 1)
        {
            outText = ">Some cows are heavier than others. Well, perhaps it's because some of them are just eating all the time!<";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = ">Algumas vacas sao mais pesadas do que outras. Bom, talvez porque algumas estao apenas comendo o tempo todo!<";
            return outText; //codigo
        }

        return "";
    }

    public static string FaseTwoHead(this string outText)
    {
        if (_language == 1)
        {
            outText = "Did you know?";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Voce sabia?";
            return outText; //codigo
        }

        return "";
    }

    public static string FaseThree(this string outText)
    {
        if (_language == 1)
        {
            outText = ">Whenever is raining, the Abducting Light will not work properly. The cows will be heavier than usual!<";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = ">Sempre que estiver chovendo, a luz de abducao nao ira funcionar direito. As vacas serao mais pesadas que o normal!<";
            return outText; //codigo
        }

        return "";
    }

    public static string FaseThreeHead(this string outText)
    {
        if (_language == 1)
        {
            outText = "Oh no, it's raining!";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Ai, as vacas no varal...";
            return outText; //codigo
        }

        return "";
    }

    public static string FaseFour(this string outText)
    {
        if (_language == 1)
        {
            outText = ">It seems that my recent abductions are making people aware. I can't let the farmer see me abducting when he wakes up!<";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = ">Parece que as minhas abducoes recentes estao deixando as pessoas cautelosas. Nao posso deixar o fazendeiro me ver abduzindo quando ele acordar!<";
            return outText; //codigo
        }

        return "";
    }

    public static string FaseFourHead(this string outText)
    {
        if (_language == 1)
        {
            outText = "Uh oh, a farmer!";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "UM FAZENDEIRO!";
            return outText; //codigo
        }

        return "";
    }

    public static string ContinueButton(this string outText)
    {
        if (_language == 1)
        {
            outText = "Continue";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Continuar";
            return outText; //codigo
        }

        return "";
    }

    public static string NewGameButton(this string outText)
    {
        if (_language == 1)
        {
            outText = "New Game";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Novo Jogo";
            return outText; //codigo
        }

        return "";
    }

    public static string FreeAbductingButton(this string outText)
    {
        if (_language == 1)
        {
            outText = "Free Abducting";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Abduzir Livremente";
            return outText; //codigo
        }

        return "";
    }

    public static string MainMenuButton(this string outText)
    {
        if (_language == 1)
        {
            outText = "Main Menu";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Menu Principal";
            return outText; //codigo
        }

        return "";
    }

    public static string LevelSelectorText(this string outText)
    {
        if (_language == 1)
        {
            outText = "Level Selector";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Selecionar Level";
            return outText; //codigo
        }

        return "";
    }

    public static string QuitText(this string outText)
    {
        if (_language == 1)
        {
            outText = "Quit";
            return outText; //codigo
        }

        else if (_language == 2)
        {
            outText = "Sair";
            return outText; //codigo
        }

        return "";
    }



}
