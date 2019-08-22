using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace VirtualWhiteBoard3.Hubs
{
    public class DrawHub : Hub<IDrawClient>
    {
        public void Draw(int prevX, int prevY, int currentX, int currentY, string color)
        {
            Clients.Others.Draw(prevX, prevY, currentX, currentY, color);
        }
    }

    public interface IDrawClient
    {
        Task Draw(int prevX, int prevY, int currentX, int currentY, string color);
    }
}
