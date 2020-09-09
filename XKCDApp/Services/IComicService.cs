using System.Threading.Tasks;
using XKCDApp.Models;

namespace XKCDApp.Services
{
    public interface IComicService
    {
        Task<Comic> GetComic(int id);
    }
}
