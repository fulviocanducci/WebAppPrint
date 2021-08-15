using System.Threading.Tasks;

namespace WebAppPrint.Models
{
    public interface IViewRender
    {
        Task<string> RenderToStringAsync(string viewName, object model);
    }
}
