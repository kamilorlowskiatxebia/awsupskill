namespace Upskill.Contracts.Models
{
    public class RawImage
    {
        public const uint MaxSize = 4096U;

        private byte[] _data;

        public RawImage(uint width, uint height, byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("Data is null");

            else if (width > MaxSize || height > MaxSize || (width & height) == 0)
                throw new ArgumentException($"Invalid size - width & height should be greater than 0 and no higher than 4096");
            
            else if(width * height != data.Length)
            {
                throw new ArgumentException($"Width & height does not match total data count: {width}x{height} != {data.Length}");
            }

            Width = width;
            Height = height;
            _data = data.Clone() as byte[];
        }

        public uint Width { get; }
        public uint Height { get; }
        public byte[] Data { get { return _data.Clone() as byte[]; } }
    }
}
