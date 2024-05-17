using Microsoft.AspNetCore.SignalR;

namespace WebEmThuong.SignalR
{
    public class MyHub : Hub
    {
        public async Task SendReservationNotification(int reservationId)
        {
            await Clients.All.SendAsync("ReceiveReservationNotification", reservationId);
        }
    }
}
