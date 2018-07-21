using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkSharp.Bot.Models;
using WorkSharp.Enums.Bot;


namespace WorkSharp.Bot.Implementation
{

    public interface ISender
    {
        Task<EnumRespondes> Send(int chatId, string MessageText);
        Task<EnumRespondes> Send(int chatId, List<SenderFileModel> Files);
        Task<EnumRespondes> Send(int chatId, List<SenderFileModel> Files, string MessageText);
    }
}
