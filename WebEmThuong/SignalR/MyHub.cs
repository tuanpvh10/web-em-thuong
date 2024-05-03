using Microsoft.AspNetCore.SignalR;

namespace WebEmThuong.SignalR
{
    public class MyHub : Hub
    {
        public async Task SendReservationNotification()
        {
            await Clients.All.SendAsync("ReceiveReservationNotification");
        }
    }
}
