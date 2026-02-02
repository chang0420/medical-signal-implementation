using System;

namespace linebotdemo
{
    class Program
    {
        public static void Gotext(string num)
        {
            int n = int.Parse(num);
            if(n<95)
            {
                isRock.LineBot.Bot bot =
         new isRock.LineBot.Bot("your key!");
                bot.PushMessage("your key!", "您的血氧值偏低請盡速就醫!");
                bot.PushMessage("your key!", 1, 2);
            }
          
        }
        static void Main(string[] args)
        {
            isRock.LineBot.Bot bot=
            new isRock.LineBot.Bot("your key!");
            bot.PushMessage("your key!","Hello World!");
            bot.PushMessage("your key!",1 , 2);
        }
    }
}
