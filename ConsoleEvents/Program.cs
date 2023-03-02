// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using ConsoleEvents;

var ps = new ParSummator(2000000000);
var sw = new Stopwatch();
void ShowResult()
{
    sw.Stop();
    Console.WriteLine("{0} за {1} мс.", ps.Result, sw.ElapsedMilliseconds);
}

var ss = new SeqSummator(2000000000);

sw.Start();
ss.Sum();
sw.Stop();
Console.WriteLine("{0} за {1} мс.", ss.Result, sw.ElapsedMilliseconds);

ps.Finish += ShowResult;
sw.Restart();
ps.Sum();