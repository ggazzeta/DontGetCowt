using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class getPhp : MonoBehaviour {

	public Text txt;
	
	public void Botao(int top)
	{
		txt.text = "carregando...";
		StartCoroutine (verPlayers(top));
	}
	
	public void myBotao()
	{
		txt.text = "carregando...";
		StartCoroutine (myScore());
	}
	
	IEnumerator verPlayers(int top)
	{
		WWWForm wwwf = new WWWForm();
		wwwf.AddField("SQL", "SELECT * FROM player ORDER BY pontos DESC LIMIT " + top, System.Text.Encoding.UTF8);
		
		using (var w = UnityWebRequest.Post("https://spigo.net/sql_to_json.php", wwwf))
		{
			yield return w.SendWebRequest();
			if(w.isNetworkError || w.isHttpError)
			{
				Debug.Log (w.error);
			}
			
			else
			{
				Players playerContainer = JsonUtility.FromJson<Players>(w.downloadHandler.text);
				if(playerContainer.objetos.Length > 0)
				{	
					txt.text = "";
					foreach(Players.Player cadaPlayer in playerContainer.objetos)
					{
						txt.text = "\n" + cadaPlayer.login + "......" + cadaPlayer.pontos + "\n";
					}
				}
			}
		}
	}
	
		IEnumerator myScore()
	{
		WWWForm wwwf = new WWWForm();
		wwwf.AddField("SQL", "SELECT * FROM player WHERE login = 'gustavo' ", System.Text.Encoding.UTF8);
		
		using (var w = UnityWebRequest.Post("https://spigo.net/sql_to_json.php", wwwf))
		{
			yield return w.SendWebRequest();
			if(w.isNetworkError || w.isHttpError)
			{
				Debug.Log (w.error);
			}
			
			else
			{
				Players playerContainer = JsonUtility.FromJson<Players>(w.downloadHandler.text);
				if(playerContainer.objetos.Length > 0)
				{	
					txt.text = "";
					foreach(Players.Player cadaPlayer in playerContainer.objetos)
					{
						txt.text += cadaPlayer.login + "......" + cadaPlayer.pontos + "\n";
					}
				}
			}
		}
	}
	

}
