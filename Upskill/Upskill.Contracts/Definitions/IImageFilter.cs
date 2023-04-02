using Upskill.Contracts.Models;

namespace Upskill.Contracts.Definitions
{
    public interface IImageFilter
    {
        RawImage Apply(RawImage image);
    }
}
