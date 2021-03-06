﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace SteamGameCompanion
{
    public partial class Form1 : Form
    {
        // The ApiKey to Steam
        private const string ApiKey = "664ADD673683CA973C09A043C939CA53";

        /**
         * The contructor of the WinForm app
         */
        public Form1()
        {
            WebRequest.DefaultWebProxy = null;
            InitializeComponent();
        }

        /**
         * This method override the onLoad and call the place app method
         */
        protected override void OnLoad(EventArgs e)
        {
            PlaceLowerRight();
            base.OnLoad(e);
        }

        /**
         * This method loads the widget to the lower right corner
         */
        private void PlaceLowerRight()
        {
            //Determine = "rightmost" screen
            var rightmost = Screen.AllScreens[0];
            foreach (var screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            Left = rightmost.WorkingArea.Right - Width;
            Top = rightmost.WorkingArea.Bottom - Height;
        }

        /**
         * This method is called when the Search button is pressed
         */
        private void button1_Click(object sender, EventArgs e)
        {
            GameListBox.Items.Clear();
            Search();
        }

        /**
         * This method return the id64 key from the custom username from steam
         */
        private long GetId64(string customUserName)
        {
            long id64;
            var isNumber = Regex.IsMatch(customUserName, @"^\d+$");
            if (isNumber)
            {
                id64 = long.Parse(customUserName);
            }
            else
            {
                string url =
                    $"http://api.steampowered.com/ISteamUser/ResolveVanityURL/v0001/?key={ApiKey}&VanityURL={customUserName}";
                using (var webClient = new WebClient())
                {
                    var json = webClient.DownloadString(url);
                    // Now parse with JSON.Net
                    dynamic data = JObject.Parse(json);
                    string str = data.response.steamid;
                    if (str == null)
                        throw new ArgumentException(@"Parameter cannot be null", nameof(customUserName));
                    id64 = long.Parse(str);
                }
            }
            return id64;
        }

        /**
         * This method return the gamelist representing the id64 key
         */
        private IEnumerable<Game> GetGameList(long id64)
        {
            const string baseUrl = "http://api.steampowered.com";
            const string ressourceUrl = "IPlayerService/GetOwnedGames/v0001";
            var restClient = new RestClient(baseUrl);
            restClient.AddDefaultParameter("key", ApiKey);
            var restRequest = new RestRequest(ressourceUrl);
            restRequest.AddQueryParameter("steamid", "" + id64);
            restRequest.AddQueryParameter("format", "json");
            restRequest.AddQueryParameter("include_appinfo", "1");
            var response = restClient.Execute<RootObject>(restRequest);
            return response.Data.response.games;
        }

        /**
         * This function is called the Run Game button is pressed
         * It will load the selected game on the listBox in Steam
         */
        private void button2_Click(object sender, EventArgs e)
        {
            var game = (Game)GameListBox.SelectedItem;
            string str = $"Steam://run/{game.appid}";
            Process.Start(str);
        }

        /**
         * This method is runned when the search button is pressed
         * It will get the two textfields and load a gamelist representing the two user mutual game list
         */
        private void Search()
        {
            // Get the id from the textbox
            var id1 = Id1TextBox.Text;
            var id2 = Id1TextBox.Text;

            // Get the id64 key
            var id164 = GetId64(id1);
            var id264 = GetId64(id2);

            // Get the game list
            var games1 = (List<Game>)GetGameList(id164);
            var games2 = (List<Game>)GetGameList(id264);

            // Compare the two game list
            var diffids = new HashSet<int>(games2.Select(s => s.appid));
            var games = games1.Where(m => diffids.Contains(m.appid)).ToList();

            // Run for each game in the list and load to a listBox
            foreach (var game in games)
            {
                // Show the name of the game symbolise the game
                GameListBox.DisplayMember = game.name;

                // Add the game to the list
                GameListBox.Items.Add(game);
            }
        }

        /*
                private Image GetGameIcon(Game game)
                {
                    if (game.img_icon_url.Equals(""))
                        return null;
                    string url =
                        $"http://cdn.edgecast.steamstatic.com/steamcommunity/public/images/apps/{game.appid}/{game.img_icon_url}.jpg";

                    var filename = game.appid + ".jpg";
                    return DownloadRemoteImageFile(url, filename);
                }
        */

        /*
                private Image DownloadRemoteImageFile(string uri, string fileName)
                {
                    var request = (HttpWebRequest) WebRequest.Create(uri);
                    var response = (HttpWebResponse) request.GetResponse();

                    // Check that the remote file was found. The ContentType
                    // check is performed since a request for a non-existent
                    // image file might be redirected to a 404-page, which would
                    // yield the StatusCode "OK", even though the image was not
                    // found.
                    if ((response.StatusCode == HttpStatusCode.OK ||
                         response.StatusCode == HttpStatusCode.Moved ||
                         response.StatusCode == HttpStatusCode.Redirect) &&
                        response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
                    {

                        // if the remote file was found, download oit
                        using (var inputStream = response.GetResponseStream())
                        using (Stream outputStream = File.OpenWrite(fileName))
                        {
                            var buffer = new byte[4096];
                            var bytesRead = 0;
                            do
                            {
                                if (inputStream == null) continue;
                                bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                                outputStream.Write(buffer, 0, bytesRead);
                            } while (bytesRead != 0);
                        }
                    }
                    var stream = File.OpenRead(fileName);
                    return Image.FromStream(stream);
                }
        */
    }
}
