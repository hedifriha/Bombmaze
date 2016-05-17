using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
public class FbScript : MonoBehaviour
{
    public GameObject DialogLoggedIn;
    public GameObject DialogLoggedOut;
    public GameObject DialogUsername;
    public GameObject DialogProfilePic;




	
		private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
        private const string TWEET_LANGUAGE = "en"; 
		// Your app’s unique identifier.
	public string AppID = "1116130085065053";
 
	// The link attached to this post.
	public string Link = "https://play.google.com/store/apps/developer?id=Gamestoodio";
 
	// The URL of a picture attached to this post. The picture must be at least 200px by 200px.
	public string Picture = "http://Assets/sprites/Text/lolo.png";
 
	// The name of the link attachment.
	private static float scoreff;

	
 
	// The caption of the link (appears beneath the link name).
	public string Caption = "I just got +99 score friends! Can you beat it?";
 
	// The description of the link (appears beneath the link caption).
	public string Description = "Enjoy fun, free games! Challenge yourself or share with friends. Fun and easy-to-use game.";
 
	
	
	
	void Awake()
    {
        FB.Init(SetInit, OnHideUnity);
    }
    void SetInit()
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("FB is logged in");
        }
        else {
			

            Debug.Log("FB is not logged in");
        }
        DealWithFBMenus(FB.IsLoggedIn);
    }
    void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }
    public void FBlogin()
    {
        List<string> permissions = new List<string>();
        permissions.Add("public_profile");
        FB.LogInWithReadPermissions(permissions, AuthCallBack);
    }
    void AuthCallBack(IResult result)
    {
        if (result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else {
            if (FB.IsLoggedIn)
            {
                Debug.Log("FB is logged in");
            }
            else {
                Debug.Log("FB is not logged in");
            }
            DealWithFBMenus(FB.IsLoggedIn);
        }
    }
    void DealWithFBMenus(bool isLoggedIn)
    {
        if (isLoggedIn)
        {
            DialogLoggedIn.SetActive(true);
            DialogLoggedOut.SetActive(false);
            FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
            FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET,
           DisplayProfilePic);
        }
        else {
            DialogLoggedIn.SetActive(false);
            DialogLoggedOut.SetActive(true);
        }
    }
    void DisplayUsername(IResult result)
    {
        Text UserName = DialogUsername.GetComponent<Text>();
        if (result.Error == null)
        {
            UserName.text = "Hi there, " + result.ResultDictionary["first_name"];
        }
        else {
            Debug.Log(result.Error);
        }
    }
    void DisplayProfilePic(IGraphResult result)
    {
        if (result.Texture != null)
        {
            Image ProfilePic = DialogProfilePic.GetComponent<Image>();
		
            ProfilePic.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 128,
           128), new Vector2());
        }
    }
		
    public void ShareScoreOnFB(){
		float scoreff = Score.scoref;
		 
		Application.OpenURL("https://www.facebook.com/dialog/feed?"+ "app_id="+AppID+ "&link="+
			Link+ "&picture="+""+ "&name="+(scoreff)+ "&caption="+
			"I just got"+(scoreff)+"score in BombMAZE Game! Can you beat it?"+ "&description="+(Description)+
		                    "&redirect_uri=https://facebook.com/");
	}




public void ShareToTwitter (string textToDisplay)
{
		float scoreff = Score.scoref;
Application.OpenURL(TWITTER_ADDRESS +
			"?text=" + WWW.EscapeURL("I just got "+(scoreff)+" score in BOMB MAZE ! Can you beat it? "+"  #GAMEMAZE #EspritMobile") +
            "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
}
		
	
	
}
