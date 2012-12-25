using System;
using System.Media;

class Whatever
{
    static void Main()
    {
        Console.WriteLine("\nAsterisk ");
        SystemSounds.Asterisk.Play();
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("\nExclamation ");
        SystemSounds.Exclamation.Play();
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("\nBeep ");
        SystemSounds.Beep.Play();
        System.Threading.Thread.Sleep(2000);
        Console. WriteLine("\nHand ");
        SystemSounds.Hand.Play();
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("\nQuestion ");
        SystemSounds.Question.Play();
        System.Threading.Thread.Sleep(2000);

    }

}
