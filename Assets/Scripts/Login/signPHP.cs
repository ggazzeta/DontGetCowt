using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class signPHP : MonoBehaviour {
	
	public Text txt;
	public InputField newLogin;
	public InputField newPassword;
	public InputField newPassCheck;

	public InputField oldLogin;
	public InputField oldPassword;
	
	
	public void signUP()
	{
		txt.text = "carregando...";
		StartCoroutine(verificaLogin(newLogin.text));		
	} //Botao de SignIN
	
	public void signIN()
	{
		txt.text = "carregando...";
		StartCoroutine(loginPlayer(oldLogin.text, oldPassword.text));	
	} //Botao de SignUP
	
	IEnumerator insertPlayer(string log, string pass)
	{
		WWWForm wwwf = new WWWForm();
		wwwf.AddField("SQL", "INSERT INTO player (login, password, pontos) VALUES ('" + log + "', '" + pass + "', 0)", System.Text.Encoding.UTF8);
		
		using (var w = UnityWebRequest.Post("https://spigo.net/sql_to_json.php", wwwf))
		{
			yield return w.SendWebRequest();
			if(w.isNetworkError || w.isHttpError)
			{
				Debug.Log (w.error);
			}
			
			else
			{
				txt.text = "Usuario criado!";
			}
		}	
	} //Essa funcao vai INSERT INTO player (login, password, pontos) VALUES ('" + log + "', '" + pass + "', x)
	
	IEnumerator verificaLogin(string log)
	{
		if(newPassword.text == newPassCheck.text){
		
			WWWForm wwwf = new WWWForm();
			wwwf.AddField("SQL", "SELECT * FROM player WHERE login = '" + log + "' ", System.Text.Encoding.UTF8);
		
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
					if(playerContainer.objetos.Length == 0)
					{
						StartCoroutine(insertPlayer(newLogin.text, newPassCheck.text));
					}
					else
					{
						txt.text = "Usuario já existe!";
					}
				}
			}
		}

		else{
			txt.text = "Senha nao confere nos dois campos";
			//Avisa o Usuario que ele nao acertou as senhas
		}	
	}
	
	
	IEnumerator loginPlayer(string log, string pass)
	{
				WWWForm wwwf = new WWWForm();
		wwwf.AddField("SQL", "SELECT * FROM player WHERE login = '" + log + "' ", System.Text.Encoding.UTF8);
		
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
					if(playerContainer.objetos[0].password == pass)
					{
						txt.text = "Login com sucesso!";
                        PlayerPrefs.SetString("login", log);
                        PlayerPrefs.Save();
                        SceneManager.LoadScene("_Abduction");
					}
					
					else
					{
						txt.text = "Senha invalida!";
					}
					
				}
				
				else
				{
					txt.text = "Login nao existe!";
				}
			}
		}	
	} //Essa funcao vai SELECT * FROM player WHERE login = '"log"'


}
