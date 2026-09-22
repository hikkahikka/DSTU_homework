using System;
using System.Collections.Generic;
using System.Text;

namespace FP_lab1
{
    public readonly struct IPv4Cidr
    {
        public readonly IPv4Address Network;
        public readonly int PrefixLength;
        public IPv4Cidr(IPv4Address address, int prefixLenght)
        {
            if (prefixLenght < 0 || prefixLenght > 32) throw new ArgumentOutOfRangeException("Argument must be from 0 to 32");
            PrefixLength = prefixLenght;
            uint maskRaw = prefixLenght == 0 ? 0 : (uint)(0xFFFFFFFFF << (32 - prefixLenght));
            Network = IPv4Address.FromUInt32(address.Raw & maskRaw);
        }
        public IPv4Address Mask
        {
            get
            {
                uint maskRaw = PrefixLength == 0 ? 0 : (uint)(0xFFFFFFFFF << (32 - PrefixLength));
                return IPv4Address.FromUInt32(maskRaw);
            }
        }
        public IPv4Address Broadcast
        {
            get
            {
                if (PrefixLength == 31 || PrefixLength == 32) return Network;
                uint wildcardMask = ~Mask.Raw;
                return IPv4Address.FromUInt32(Network.Raw | wildcardMask);
            }
        }
        public uint HostCount
        {
            get
            {
                switch (PrefixLength)
                {
                    case 0:
                        return uint.MaxValue - 1;
                    case 31:
                        return 2;
                    case 32:
                        return 1;
                    default:
                        int hostBits = 32 - PrefixLength;
                        return ((uint)1 << hostBits) - 2;
                }
                
            }
        }
        public bool Contains(IPv4Address address) => (address.Raw & Mask.Raw) == Network.Raw;
        public static IPv4Cidr Parse(string cidrString)
        {
            if (string.IsNullOrWhiteSpace(cidrString)) throw new ArgumentNullException(cidrString);
            string[] parts = cidrString.Split('/');
            if (parts.Length != 2)throw new FormatException("Incorrect CIDR format");
            IPv4Address address = IPv4Address.Parse(parts[0]);
            if (!int.TryParse(parts[1], out int prefixLength)) throw new FormatException("Prefix must be integer");
            return new IPv4Cidr(address, prefixLength);
        }
        public override string ToString() => $"{Network}/{PrefixLength}";
    }
}
