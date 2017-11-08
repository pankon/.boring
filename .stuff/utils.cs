/*
 *  utils.cs
 *  various utils for analysis
 */

using System;
using System.Diagnostics;

namespace boring
{
    public class Utils
    {
        // From: https://askubuntu.com/questions/506985/c-opening-the-terminal-process-and-pass-commands
        public static void Spawn(string command, bool open_terminal)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "/bin/bash";
            proc.StartInfo.Arguments = "-c \" " + command + "\"";
            proc.StartInfo.UseShellExecute = open_terminal;
            
            // Could return stream with result here
            proc.StartInfo.RedirectStandardOutput = false;
            
            // start the process
            proc.Start();
        }
    }
}
