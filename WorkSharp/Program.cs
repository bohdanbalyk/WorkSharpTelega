using System;
using System.IO;
using WorkSharp.Bot;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using System.Linq;
using Telegram.Bot.Types;
using WorkSharp.Bot.Models;
using System.Collections.Generic;

namespace WorkSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //MainAsync(args).Wait();
            Run().Wait();
            Console.ReadKey();
        }

        static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Sending Message...");
            List<SenderFileModel> senderFileModels = new List<SenderFileModel>();
            SenderFileModel fileModel = new SenderFileModel
            {
                URL = "https://www.istockphoto.com/resources/images/PhotoFTLP/img_67920257.jpg",
                SenderEnum = Enums.Bot.SenderEnum.Picture
            };
            senderFileModels.Add(fileModel);
            Sender sender = new Sender();
            var result = await sender.Send(185651998, "Hello Bratan!");
            var res2 = await sender.Send(185651998, senderFileModels);

            Console.WriteLine("Message sent...");
            Console.WriteLine(result);
            Console.WriteLine(res2);
        }
        static async Task Run()
        {
            Sender sender = new Sender();
            var offset = 0;
            while (true)
            {
                
                var updates = await Sender.bot.GetUpdatesAsync(offset);

                foreach (var update in updates)
                {
                    if (update.Message.Type == MessageType.Text)
                    {
                        Console.WriteLine("Echo Message: {0}", update.Message.Text);
                    }

                    if (update.Message.Type == MessageType.Photo)
                    {
                        var file = await Sender.bot.GetFileAsync(update.Message.Photo.LastOrDefault()?.FileId);

                        var filename = file.FileId + "." + file.FilePath.Split('.').Last();

                        using (var saveImageStream = System.IO.File.Open(filename, FileMode.Create))
                        {
                            await Sender.bot.DownloadFileAsync(file.FilePath, saveImageStream);
                        }
                        
                    }

                    offset = update.Id + 1;
                }

                await Task.Delay(1000);
            }
            
        }
        //public async static Task Load()
        //{
        //    StorageFolder folder = ApplicationData.Current.LocalFolder;
        //    StorageFile file;
        //    bool fileExists = true;

        //    try
        //    {
        //        // The following line (often) never returns
        //        file = await folder.GetFileAsync("filename.xml");
        //    }
        //    catch
        //    {
        //        fileExists = false;
        //    }

        //    // Do stuff with loaded file
        //}



    }
}
