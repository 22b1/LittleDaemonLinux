/*
MIT License

Copyright (c) 2023 Likon aka b1cc

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS," WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES, OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT, OR OTHERWISE, ARISING FROM, OUT OF, OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

/*
Project: Little Daemon
Description: 
License: MIT License (See LICENSE file for details)
Version: 1.0.0.0
Author: B1cc
GitHub: https://github.com/XENNI-tech/LittleDaemonLinux
©2023 - Likon aka b1cc
*/


using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

class Program
{

    static async Task Main(string[] args)
    {
        await RunApplication();
    }

    private static string GetApiKey()
    {
        string apiKeyFilePath = "apikey.txt";
        if (File.Exists(apiKeyFilePath))
        {
            return File.ReadAllText(apiKeyFilePath).Trim();
        }
        else
        {
            return string.Empty;
        }
    }

    private static void SaveApiKey(string apiKey)
    {
        string apiKeyFilePath = "apikey.txt";
        File.WriteAllText(apiKeyFilePath, apiKey);
    }

    private static async Task RunApplication()
    {
        while (true)
        {
            Console.Clear();
            while (true)
            {
                Console.Title = "Little Daemon | v1.0.0.0 | Made by Likon | Linux | macOS | Windows";
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(" /$$       /$$   /$$     /$$     /$$");
                Console.WriteLine("| $$      |__/  | $$    | $$    | $$");
                Console.WriteLine("| $$       /$$ /$$$$$$ /$$$$$$  | $$  /$$$$$$");
                Console.WriteLine("| $$      | $$|_  $$_/|_  $$_/  | $$ /$$__  $$");
                Console.WriteLine("| $$      | $$  | $$    | $$    | $$| $$$$$$$$");
                Console.WriteLine("| $$      | $$  | $$ /$$| $$ /$$| $$| $$_____/");
                Console.WriteLine("| $$$$$$$$| $$  |  $$$$/|  $$$$/| $$|  $$$$$$$");
                Console.WriteLine("|________/|__/   \\___/   \\___/  |__/ \\_______/");
                Console.WriteLine("");
                Console.WriteLine(" /$$$$$$$");
                Console.WriteLine("| $$__  $$");
                Console.WriteLine("| $$  \\ $$  /$$$$$$   /$$$$$$  /$$$$$$/$$$$   /$$$$$$  /$$$$$$$");
                Console.WriteLine("| $$  | $$ |____  $$ /$$__  $$| $$_  $$_  $$ /$$__  $$| $$__  $$");
                Console.WriteLine("| $$  | $$  /$$$$$$$| $$$$$$$$| $$ \\ $$ \\ $$| $$  \\ $$| $$  \\ $$");
                Console.WriteLine("| $$  | $$ /$$__  $$| $$_____/| $$ | $$ | $$| $$  | $$| $$  | $$");
                Console.WriteLine("| $$$$$$$/|  $$$$$$$|  $$$$$$$| $$ | $$ | $$|  $$$$$$/| $$  | $$");
                Console.WriteLine("|_______/  \\_______/ \\_______/|__/ |__/ |__/ \\______/ |__/  |__/");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Welcome to Little Daemon Menu:");
                Console.WriteLine("[01] Show information about an IP Address");
                Console.WriteLine("[02] WHOIS and other information about a domain");
                Console.WriteLine("[03] DNS Lookup");
                Console.WriteLine("[04] Subdomain Enumeration ( API Key Required )");
                Console.WriteLine("[05] Check Popular Sites for that username");
                Console.WriteLine("[06] Scan for open ports on a host");
                Console.WriteLine("[07] Clear Little Daemon Console");
                Console.WriteLine("[08] Show credits and other information about Little Daemon");
                Console.WriteLine("[09] Safely Exit Little Daemon");
                Console.WriteLine("[10] API Key Documentation");
                Console.WriteLine("[11] Delete API Key");

                Console.Write("Please enter your choice (1-11): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the target IP address: ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        string ipAddress = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        string ipInfo = await GetIPInfo(ipAddress);
                        Console.WriteLine(ipInfo);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Write("Enter the target domain: ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        string domain = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        string whoisInfo = GetWhoisInfo(domain);
                        Console.WriteLine(whoisInfo);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Write("Enter the target DNS address: ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        string dnsAddress = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        string dnsInfo = GetDnsLookupInfo(dnsAddress);
                        Console.WriteLine("IP Address: " + dnsInfo);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Write("Enter the target domain: ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        string subdomainDomain = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        string subdomainInfo = await EnumerateSubdomains(subdomainDomain);
                        Console.WriteLine(subdomainInfo);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;

                    case "5":
                        Console.Write("Enter the username to check: ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        string username = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        string userExistenceInfo = await SearchUserAsync(username);
                        Console.WriteLine(userExistenceInfo);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;

                    case "6":
                        Console.Write("Enter the host to scan: ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        string hostToScan = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Enter the start port: ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        if (int.TryParse(Console.ReadLine(), out int startPort))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("Enter the end port: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            if (int.TryParse(Console.ReadLine(), out int endPort))
                            {
                                await ScanPorts(hostToScan, startPort, endPort);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Port scanning completed.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Invalid end port.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Invalid start port.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;


                    case "7":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Console cleared.");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;

                    case "8":
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You selected 'credits'.");
                        Console.ResetColor();
                        Console.Write("[+] Creator ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Likon");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.Write("[+] Tools and methods by ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Molotov");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.Write("[+] Secured by ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("rXXDw4");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.Write("[+] Uploaded on ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("cheater.fun | github.com | And Other by third party");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("[+] This Program is FREE TO USE!");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;

                    case "9":
                        Console.WriteLine("Goodbye!");
                        return;

                    case "10":
                        Console.ResetColor();
                        Console.WriteLine("\nWhy do you need a API Key?\n\nWe use SecurityTrails to improve our Subdomain Enumeration. You can use Little Daemon even if you don't have a API Key, but without Subdomain Enumeration, because it is required.\nHow to get a API Key:\n[1] Go to https://securitytrails.com and make an account with TempMail.org.\n[2] At 'Company' tou type 'None'.\n[3] You will recive a Activation email adress at your Temp-Mail, use that link, and then the first thing that you shoud see is your API Key, copy it.\n[+] A API Key is avalibe forever, but with a limited of 50 uses/per mounth. You can make unlimited accounts using Temp-Mail.org\n\n");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;

                    case "11":
                        if (!string.IsNullOrEmpty(GetApiKey()))
                        {
                            Console.WriteLine("Are you sure you want to delete your API key? (Y/N)");
                            string confirmation = Console.ReadLine();
                            if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                DeleteApiKey();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("API key deleted.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("API key not deleted.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("You do not have an API key to delete.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid choice. Please select a valid option (1-11).");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }

     static void CenterText(string text)
        {
            int screenWidth = Console.WindowWidth;
            int stringWidth = text.Length;
            int leftPadding = (screenWidth - stringWidth) / 2;
            string centeredText = text.PadLeft(leftPadding + stringWidth);

            Console.WriteLine(centeredText);
        }

        static async Task<string> GetIPInfo(string ipAddress)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"http://ip-api.com/json/{ipAddress}";
                try
                {
                    string result = await client.GetStringAsync(url);
                    return FormatIPInfo(result);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    return "Error: " + ex.Message;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

    private static void DeleteApiKey()
    {
        string apiKeyFilePath = "apikey.txt";
        if (File.Exists(apiKeyFilePath))
        {
            File.Delete(apiKeyFilePath);
        }
    }

    static async Task ScanPorts(string host, int startPort, int endPort)
        {
            var tasks = new List<Task>();
            var openPorts = new List<int>();
            var closedPorts = new List<int>();

            for (int port = startPort; port <= endPort; port++)
            {
                tasks.Add(ScanPortAsync(host, port, openPorts, closedPorts));
            }

            await Task.WhenAll(tasks);

            Console.WriteLine("Open Ports:");
            foreach (var port in openPorts)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Port {port} is open.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("Closed Ports:");
            foreach (var port in closedPorts)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Port {port} is closed.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    static async Task ScanPortAsync(string host, int port, List<int> openPorts, List<int> closedPorts)
        {
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    await client.ConnectAsync(host, port);
                    openPorts.Add(port);
                }
                catch (SocketException)
                {
                    closedPorts.Add(port);
                }
            }
        }


    static string GetDnsLookupInfo(string dnsAddress)
        {
            try
            {
                IPHostEntry host = Dns.GetHostEntry(dnsAddress);
                return host.AddressList[0].ToString();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                return "Error: " + ex.Message;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    static string FormatIPInfo(string json)
        {
            JObject data = JObject.Parse(json);

            string formattedInfo = "[+] Country: " + data["country"] + "\n";
            formattedInfo += "[+] Country Code: " + data["countryCode"] + "\n";
            formattedInfo += "[+] Region: " + data["region"] + "\n";
            formattedInfo += "[+] Region Name: " + data["regionName"] + "\n";
            formattedInfo += "[+] City: " + data["city"] + "\n";
            formattedInfo += "[+] ZIP Code: " + data["zip"] + "\n";
            formattedInfo += "[+] Location: lat:" + data["lat"] + " lon:" + data["lon"] + "\n";
            formattedInfo += "[+] ISP: " + data["isp"] + "\n";
            formattedInfo += "[+] ORG: " + data["org"] + "\n";

            return formattedInfo;
        }

    static string GetWhoisInfo(string domain)
        {
            try
            {
                using (TcpClient whoisClient = new TcpClient("whois.internic.net", 43))
                {
                    using (NetworkStream stream = whoisClient.GetStream())
                    {
                        byte[] query = Encoding.ASCII.GetBytes(domain + "\r\n");
                        stream.Write(query, 0, query.Length);

                        byte[] responseBytes = new byte[whoisClient.ReceiveBufferSize];
                        int bytesRead = stream.Read(responseBytes, 0, whoisClient.ReceiveBufferSize);

                        return Encoding.ASCII.GetString(responseBytes, 0, bytesRead);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                return "Error: " + ex.Message;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    static  async Task<string> SearchUserAsync(string username)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string[] platformUrls = {
            $"https://www.facebook.com/{username}",
            $"https://twitter.com/{username}",
            $"https://www.instagram.com/{username}",
            $"https://www.linkedin.com/in/{username}",
            $"https://github.com/{username}",
            $"https://pinterest.com/{username}",
            $"https://www.tumblr.com/{username}",
            $"https://www.youtube.com/@{username}",
            $"https://soundcloud.com/{username}",
            $"https://www.snapchat.com/add/{username}",
            $"https://www.tiktok.com/@{username}",
            $"https://www.behance.net/{username}",
            $"https://medium.com/@{username}",
            $"https://www.quora.com/profile/{username}",
            $"https://www.flickr.com/photos/{username}",
            $"https://www.twitch.tv/{username}",
        };

                string result = "";

                foreach (string url in platformUrls)
                {
                    try
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(url);

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            string pageContent = await response.Content.ReadAsStringAsync();

                            if (pageContent.Contains("This page isn't available"))
                            {
                                result += $"User does not exist on {GetPlatformName(url)}\n";
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                result += $"User exists on {GetPlatformName(url)}\n";
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            result += $"User does not exist on {GetPlatformName}\n";
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        result += $"Error checking {GetPlatformName(url)}: {ex.Message}\n";
                    }
                }

                return result;
            }
        }

    static string GetPlatformName(string url)
        {
            if (url.Contains("facebook")) return $"Facebook | {url}";
            if (url.Contains("twitter")) return $"Twitter | {url}";
            if (url.Contains("instagram")) return $"Instagram | {url}";
            if (url.Contains("linkedin")) return $"LinkedIn | {url}";
            if (url.Contains("github")) return $"GitHub | {url}";
            if (url.Contains("pinterest")) return $"Pinterest | {url}";
            if (url.Contains("tumblr")) return $"Tumblr | {url}";
            if (url.Contains("youtube")) return $"YouTube | {url}";
            if (url.Contains("soundcloud")) return $"SoundCloud | {url}";
            if (url.Contains("snapchat")) return $"Snapchat | {url}";
            if (url.Contains("tiktok")) return $"TikTok | {url}";
            if (url.Contains("behance")) return $"Behance | {url}";
            if (url.Contains("medium")) return $"Medium | {url}";
            if (url.Contains("quora")) return $"Quora | {url}";
            if (url.Contains("flickr")) return $"Flickr | {url}";
            if (url.Contains("twitch")) return $"Twitch | {url}";
            return url;
        }

    static async Task<string> EnumerateSubdomains(string domain)
    {
        string apiKey = GetApiKey();

        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("Please enter your API key:");
            apiKey = Console.ReadLine();
            SaveApiKey(apiKey);
        }

        try
        {
            string result = await QueryGoogleDNS(domain);
            string subdomainResult = await QuerySecurityTrails(domain, apiKey);

            if (result.StartsWith("Error"))
            {
                return result;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(FormatDnsResponse(result));

            if (subdomainResult.StartsWith("Error"))
            {
                sb.AppendLine(subdomainResult);
            }
            else
            {
                sb.AppendLine(FormatSecurityTrailsResponse(subdomainResult));
            }

            sb.AppendLine("\n=== SUBDOMAIN ENUMERATION END ===");
            return sb.ToString();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            return "Error: " + ex.Message;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }




    static async Task<string> QueryGoogleDNS(string domain)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://dns.google.com/resolve?name={domain}&type=A";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                return "Error: Unable to enumerate subdomains.";
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    static async Task<string> QuerySecurityTrails(string domain, string apiKey)
    {
        using (HttpClient clientS = new HttpClient())
        {
            clientS.DefaultRequestHeaders.Add("apikey", apiKey);
            string apiUrl = $"https://api.securitytrails.com/v1/domain/{domain}/subdomains";
            HttpResponseMessage responseS = await clientS.GetAsync(apiUrl);

            if (responseS.IsSuccessStatusCode)
            {
                return await responseS.Content.ReadAsStringAsync();
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            return "Error fetching subdomains.";
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    static string FormatDnsResponse(string responseJson)
        {
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(responseJson);

            int status = jsonResponse.Value<int>("Status");
            bool tc = jsonResponse.Value<bool>("TC");
            bool rd = jsonResponse.Value<bool>("RD");
            bool ra = jsonResponse.Value<bool>("RA");
            bool ad = jsonResponse.Value<bool>("AD");
            bool cd = jsonResponse.Value<bool>("CD");

            string questionName = jsonResponse["Question"][0].Value<string>("name");

            JArray answerArray = jsonResponse["Answer"] as JArray;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"[+] Status: {status}");
            sb.AppendLine($"[+] TC: {tc}");
            sb.AppendLine($"[+] RD: {rd}");
            sb.AppendLine($"[+] RA: {ra}");
            sb.AppendLine($"[+] AD: {ad}");
            sb.AppendLine($"[+] CD: {cd}");
            sb.AppendLine($"[+] Question: Name={questionName}");

            if (answerArray != null && answerArray.Count > 0)
            {
                foreach (JObject answer in answerArray)
                {
                    int ttl = answer.Value<int>("TTL");
                    string data = answer.Value<string>("data");
                    sb.AppendLine($"[+] TTL: {ttl} | DATA: {data}");
                }
            }
            else
            {
                sb.AppendLine("No DNS answers found.");
            }

            return sb.ToString();
        }

    static  string FormatSecurityTrailsResponse(string responseJson)
        {
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(responseJson);

            int subdomainCount = jsonResponse.Value<int>("subdomain_count");
            JArray subdomainsArray = jsonResponse["subdomains"] as JArray;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n=== SUBDOMAIN ENUMERATION START ===\n");
            sb.AppendLine($"Subdomains({subdomainCount}):");

            if (subdomainsArray != null && subdomainsArray.Count > 0)
            {
                foreach (string subdomain in subdomainsArray)
                {
                    sb.AppendLine($"  \"{subdomain}\",");
                }
            }
            else
            {
                sb.AppendLine("No subdomains found.");
            }

            return sb.ToString();
        }
}