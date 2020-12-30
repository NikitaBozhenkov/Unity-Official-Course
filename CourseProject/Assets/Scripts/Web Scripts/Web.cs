using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Net;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

[Serializable]
public class File {
    public string filename;
    public string raw_url;
}

[Serializable]
public class JSONData {
    public string url;
    public Dictionary<string, File> files;
}

[Serializable]
public class Leaders {
    public Dictionary<string, int> leaders;
}

[Serializable]
public class Content {
    public string content;
}

public class Web : MonoBehaviour {
    private const string Token = "9a6d3f1cc629c9908fa33a19dfb77561b91c4552";
    private const string GistId = "430e763ecc4a0956463ddaf40418b51b";
    private const string FileName = "Leaderboard.json";
    private const string URL = "https://api.github.com/gists";
    private List<KeyValuePair<string, int>> _leaders;
    private bool _noConnection = false;

    [SerializeField] private Image slotPrefab;
    [SerializeField] private GameObject content;

    private void Start() {
        var www = UnityWebRequest.Get(URL + '/' + GistId);
        StartCoroutine(GetLeaders(www));
    }


    public void PatchAndQuit() {
        if (!_noConnection) {
            var request = FormPatchRequest();
            StartCoroutine(Patch(request));
        } else {
            SceneManager.LoadScene("Main Menu");
        }
    }

    private UnityWebRequest FormPatchRequest() {
        var localContent = new Content {content = MakeFileContent()};
        var requestBody = new Dictionary<object, object> {
            {"files", new Dictionary<string, Content> {{FileName, localContent}}}
        };
        var requestBodyString = JsonConvert.SerializeObject(requestBody);
        var requestBodyData = System.Text.Encoding.UTF8.GetBytes(requestBodyString);
        return UnityWebRequest.Put(URL + '/' + GistId, requestBodyData);
    }

    private string MakeFileContent() {
        var ret = "{\n" + "\t \"leaders\": {\n";
        for (var i = 0; i < _leaders.Count; ++i) {
            if (i != _leaders.Count - 1) {
                ret += "\t\t \"" + _leaders[i].Key + "\": " + _leaders[i].Value.ToString() + ",\n";
            } else {
                ret += "\t\t \"" + _leaders[i].Key + "\": " + _leaders[i].Value.ToString() + "\n\t}\n}";
            }
        }

        return ret;
    }

    private IEnumerator Patch(UnityWebRequest www) {
        www.method = "PATCH";
        www.SetRequestHeader("Authorization", $"Token {Token}");
        www.SetRequestHeader("accept", "application/vnd.github.v3+json");
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        SceneManager.LoadScene("Main Menu");
    }

    private IEnumerator GetLeaders(UnityWebRequest www) {
        www.SetRequestHeader("platrorm", "android");
        www.SetRequestHeader("Authorization", $"Token {Token}");
        www.SetRequestHeader("accept", "application/vnd.github.v3+json");
        yield return www.SendWebRequest();
        if (!www.isNetworkError) {
            var data = JsonConvert.DeserializeObject<JSONData>(www.downloadHandler.text);
            var rawURL = data.files[FileName].raw_url;
            using (var webClient = new WebClient()) {
                var responce = webClient.DownloadString(rawURL);
                var dictLeaders = JsonConvert.DeserializeObject<Leaders>(responce).leaders;
                dictLeaders[GameManager.Instance.GetUsername()] = GameManager.Instance.GetHighscore();
                var unsortedLeaders = dictLeaders.Select(elem => new KeyValuePair<string, int>(elem.Key, elem.Value))
                    .ToList();

                unsortedLeaders.Sort((firstPair, nextPair) => firstPair.Value.CompareTo(nextPair.Value));


                unsortedLeaders.Reverse();
                _leaders = unsortedLeaders;

                foreach (var pair in _leaders) {
                    var instance = Instantiate(slotPrefab, content.transform, true);
                    var texts = instance.GetComponentsInChildren<TextMeshProUGUI>();
                    texts[0].text = pair.Key;
                    if (pair.Key == GameManager.Instance.GetUsername()) {
                        instance.color = Color.green;
                    }

                    texts[1].text = pair.Value.ToString();
                }
            }
        } else {
            Debug.Log("WWW error: " + www.error);
            _noConnection = true;

            var instance = Instantiate(slotPrefab, content.transform, true);
            var texts = instance.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = GameManager.Instance.GetUsername();
            instance.color = Color.green;
            texts[1].text = GameManager.Instance.GetHighscore().ToString();
        }
    }
}