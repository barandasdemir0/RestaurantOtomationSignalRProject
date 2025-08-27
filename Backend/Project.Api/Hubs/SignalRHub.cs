using Microsoft.AspNetCore.SignalR;
using Project.DataAccessLayer.Concrete;

namespace Project.Api.Hubs
{
    public class SignalRHub : Hub
    {

        SignalRContext context = new SignalRContext();
        public async Task SendCategoryCount()
        {
            var values = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", values);
        }
    }
}
//hub burada sunucu görevi görür değitim işlemi buradan olacak