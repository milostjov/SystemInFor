using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class ActiveWindowHelper
{
    public static string GetActiveWindowTitle()
    {
        try
        {
            // Dobijanje ID-a aktivne sesije
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c query user";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // Parsiranje sesije iz query user
            string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string activeSessionId = null;

            foreach (string line in lines)
            {
                if (line.Contains("console"))  // "console" označava aktivnu korisničku sesiju
                {
                    string[] columns = Regex.Split(line, @"\s+");
                    activeSessionId = columns[2]; // Treća kolona je Session ID
                    break;
                }
            }

            if (activeSessionId == null)
                return "Nije pronađena aktivna sesija.";

            // Pokretanje tasklist u korisničkoj sesiji pomoću PsExec
            process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/c psexec -i {activeSessionId} tasklist /v";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // Parsiranje izlaza tasklist da se pronađe naziv aktivnog prozora
            lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line.Contains("chrome.exe") || line.Contains("msedge.exe") || line.Contains("firefox.exe"))
                {
                    string[] columns = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    return columns.Last();
                }
            }

            return "Nepoznato";
        }
        catch (Exception ex)
        {
            return "Greška u GetActiveWindowTitle: " + ex.Message;
        }
    }
}
